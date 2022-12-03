using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Staffs;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Mandegar.Utilities.Enums;
using Mandegar.Utilities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class StaffService : IStaffService
    {
        private readonly IUow _uow;
        private readonly IFileManager _fileManager;
        private readonly IPositionService _positionService;

        public StaffService(IUow uow, IFileManager fileManager, IPositionService positionService)
        {
            _positionService = positionService;
            _uow = uow;
            _fileManager = fileManager;
        }

        public async Task<Result<int>> Add(UpsertStaffVM model)
        {
            var validation = Validate(model);
            if (!validation.success)
            {
                return new Result<int>(message: validation.message);
            }

            var isExistsNationalCocde = await _uow.GetRepository<Staff>().Get(c => c.NationalCode == model.NationalCode).AnyAsync();

            if (isExistsNationalCocde)
            {
                return new Result<int>(Messages.DuplicateNationalCode);
            }

            try
            {
                #region Upload Avatar
                if (string.IsNullOrWhiteSpace(model.Image) == false)
                {
                    model.Image = model.Image.ReplaceBase64();

                    byte[] imageBytes = Convert.FromBase64String(model.Image);

                    var upload = await _fileManager.UploadFile(imageBytes, DefaultPath.PersonnelImages, FileType.Images);
                    if (upload.Success)
                    {
                        _fileManager.ImageResizer(upload.Data.ToString(), DefaultPath.PersonnelImages, 80);
                        model.Image = upload.Data.ToString();
                    }
                }
                else
                {
                    model.Image = "/Images/UserAvatar/Default.jpg";
                }
                #endregion

                var entity = (Staff)model;
                entity.CreatedById = ClaimHelper.GetUserId();

                await _uow.GetRepository<Staff>().AddAsync(entity);
                await _uow.SaveChangesAsync();

                return new Result<int>(entity.Id, true);
            }
            catch (Exception ex)
            {
                _fileManager.RemoveFile(model.Image, DefaultPath.PersonnelImages, FileType.Images);
                return new Result<int>(false);
            }
        }

        public async Task<Result<bool>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                var existmodel = _uow.GetRepository<DepartmentMember>().GetWithInclude(c => c.Staff).Where(x => x.StaffId == id).FirstOrDefault();
                if (existmodel != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var model = _uow.GetRepository<Staff>().Get(c => c.Id == id).FirstOrDefault();
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                //TODO: چک شود هیچگونه فعالیت و همکاری و سابقه برای شخص وجود نداشته باشد

                model.IsDeleted = true;
                _uow.GetRepository<Staff>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<bool>> ExistsStaff(int id)
        {
            var isExistsStaff = await _uow.GetRepository<Staff>().Get(c => c.Id == id).AnyAsync();

            return new Result<bool>(data: isExistsStaff);
        }

        public async Task<Result<UpsertStaffVM>> Get(int id)
        {
            var model = await _uow.GetRepository<Staff>().Get(c => c.Id == id).FirstOrDefaultAsync();

            if (model == null)
            {
                return new Result<UpsertStaffVM>(Messages.NotExistsData);
            }

            if (string.IsNullOrWhiteSpace(model.Image) || model.Image.EndsWith("Default.jpg"))
            {
                model.Image = await _fileManager.GeneratePath("Default.jpg", DefaultPath.DefultUserAvatar);
            }
            else
            {
                model.Image = await _fileManager.GeneratePath(model.Image, DefaultPath.PersonnelImages);
            }

            return new Result<UpsertStaffVM>((UpsertStaffVM)model);
        }

        public async Task<Result<PagingResultVM<StaffListResultVM>>> GetAll(StaffSearchVM searchVM)
        {

            searchVM.IsCount = true;
            var total = await _uow.ExecuteScalar(null, "Staff_GetAll", searchVM);

            searchVM.IsCount = false;
            var data = await _uow.ExecuteReader<StaffListResultVM>(null, "Staff_GetAll", searchVM);

            var result = new PagingResultVM<StaffListResultVM> { Rows = data, Total = (int)total };

            if (result.Rows.Count() > 0)
            {
                foreach (var item in result.Rows.ToList())
                {
                    if (string.IsNullOrWhiteSpace(item.Image) || item.Image.EndsWith("Default.jpg"))
                    {
                        item.Image = await _fileManager.GeneratePath("ThunbDefault.jpg", DefaultPath.DefultUserAvatar);
                    }
                    else
                    {
                        item.Image = await _fileManager.GeneratePath(item.Image, DefaultPath.Thumbnails);
                    }
                }
            }

            return new Result<PagingResultVM<StaffListResultVM>>(result);
        }

        public async Task<Result<List<Staff>>> GetAllStaff()
        {
            var data = await _uow.GetRepository<Staff>()
                .Get(c => c.IsActive)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking().ToListAsync();

            return new Result<List<Staff>>(data);
        }

        public async Task<Result<List<StaffListResultVM>>> GetAllStaffBaseInfo()
        {
            var data = await _uow.GetRepository<Staff>()
                           .Get(c => c.IsActive && !c.IsDeleted).Include(x => x.AssignPositions).ThenInclude(x => x.Position)
                           .OrderByDescending(c => c.CreatedOn)
                           .AsNoTracking()
                           .Select(c => new StaffListResultVM
                           {
                               Id = c.Id,
                               Name = c.Name,
                               Family = c.Family,
                               NationalCode = c.NationalCode,
                               PersonneliCode = c.PersonneliCode,
                               AssignPositions = c.AssignPositions
                           })
                           .ToListAsync();
            List<StaffListResultVM> list = new List<StaffListResultVM>();
            foreach (var item in data)
            {
                if (item.AssignPositions.Count > 0)
                {
                    foreach (var itm in item.AssignPositions)
                    {
                        if (itm.Position.ParentId == null)
                            if (string.IsNullOrEmpty(item.PositionTitle))
                                item.PositionTitle = itm.Position.Name;
                            else
                                item.PositionTitle = item.PositionTitle + " , " + itm.Position.Name;
                    }
                    list.Add(item);
                }
            }
            return new Result<List<StaffListResultVM>>(list);
        }
        public async Task<Result<List<StaffListResultVM>>> GetAll()
        {
            var data = await _uow.GetRepository<Staff>()
                           .Get(c => c.IsActive && !c.IsDeleted).Include(x => x.AssignPositions).ThenInclude(x => x.Position)
                           .OrderByDescending(c => c.CreatedOn)
                           .AsNoTracking()
                           .Select(c => new StaffListResultVM
                           {
                               Id = c.Id,
                               Name = c.Name,
                               Family = c.Family,
                               NationalCode = c.NationalCode,
                               PersonneliCode = c.PersonneliCode,
                               AssignPositions = c.AssignPositions
                           })
                           .ToListAsync();
           
            return new Result<List<StaffListResultVM>>(data);
        }

        public async Task<Result<bool>> Update(UpsertStaffVM model)
        {
            var validation = Validate(model);
            if (!validation.success)
            {
                return new Result<bool>(message: validation.message);
            }

            if (model.Id == 0)
            {
                return new Result<bool>(Messages.NotExistsData);
            }

            var dbModel = await _uow.GetRepository<Staff>().Get(c => c.Id == model.Id).FirstOrDefaultAsync();

            if (dbModel == null)
            {
                return new Result<bool>(Messages.NotExistsData);
            }

            var isExistsNationalCode = await _uow.GetRepository<Staff>().Get(c => c.Id != model.Id && c.NationalCode == model.NationalCode).AnyAsync();

            if (isExistsNationalCode)
            {
                return new Result<bool>(Messages.DuplicateNationalCode);

            }

            try
            {
                string oldImage = dbModel.Image;
                #region Upload Avatar
                if (string.IsNullOrWhiteSpace(model.Image) == false)
                {
                    model.Image = model.Image.ReplaceBase64();

                    byte[] imageBytes = Convert.FromBase64String(model.Image);

                    var upload = await _fileManager.UploadFile(imageBytes, DefaultPath.PersonnelImages, FileType.Images);
                    if (upload.Success)
                    {
                        _fileManager.ImageResizer(upload.Data.ToString(), DefaultPath.PersonnelImages, 80);
                        model.Image = upload.Data.ToString();
                    }
                }

                #endregion

                dbModel.NationalCode = model.NationalCode;
                dbModel.Name = model.Name;
                dbModel.Family = model.Family;
                dbModel.FatherName = model.FatherName;
                dbModel.BirthCityId = model.BirthCityId;
                dbModel.IdentityIssueCityId = model.IdentityIssueCityId;
                dbModel.BirthDate = model.BirthDate;
                dbModel.IdentityIssueDate = model.IdentityIssueDate;
                dbModel.PersonneliCode = model.PersonneliCode;
                dbModel.Gender = model.Gender;
                dbModel.IsActive = model.IsActive;
                dbModel.IdentityNumber = model.IdentityNumber;
                dbModel.Image = string.IsNullOrWhiteSpace(model.Image) ? dbModel.Image : model.Image;
                dbModel.ModifiedById = ClaimHelper.GetUserId();
                dbModel.ModifiedOn = DateTime.Now;

                await _uow.SaveChangesAsync();

                if (string.IsNullOrWhiteSpace(oldImage) == false && string.IsNullOrWhiteSpace(model.Image) == false)
                {
                    _fileManager.RemoveFile(oldImage, DefaultPath.PersonnelImages, FileType.Images);
                }

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                _fileManager.RemoveFile(model.Image, DefaultPath.PersonnelImages, FileType.Images);
                return new Result<bool>(false);
            }
        }

        public async Task<Result<StaffListResultVM>> UpdatePreparation(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<StaffListResultVM>(Messages.NotExistsData);
                }

                var model = new StaffListResultVM();
                var staff = await _uow.GetRepository<Staff>().GetWithInclude(c => c.AssignPositions).Where(c => c.Id == id).FirstOrDefaultAsync();

                if (staff == null)
                    return new Result<StaffListResultVM>(Messages.NotExistsData);

                var position = await _positionService.GetAllPositions();
                if (!position.Success)
                    return new Result<StaffListResultVM>(false);

                model.Staff = staff;
                model.Positions = position.Data.Select(c => (Position)c).ToList();
                model.Root = new Root();
                model.Root.data = new List<TreeNode>();
                foreach (Position item in position.Data)
                {
                    if (item.ParentId == null)
                        model.Root.data.Add(new TreeNode
                        {
                            data = item.Id,
                            expandedIcon = "pi pi-user",
                            collapsedIcon = "pi pi-user",
                            label = item.Name,
                            children = item.Positions != null ? getChild(item.Positions.ToList()) : null
                        });
                }

                return new Result<StaffListResultVM>(model);

            }
            catch (Exception)
            {
                return new Result<StaffListResultVM>(false);
            }
        }
        private List<TreeNode> getChild(List<Position> positions)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var item in positions)
            {
                nodes.Add(new TreeNode
                {
                    data = item.Id,
                    expandedIcon = "pi pi-key",
                    collapsedIcon = "pi pi-key",
                    label = item.Name,
                    children = null
                });
            }
            return nodes;
        }
        private (bool success, string message) Validate(UpsertStaffVM model)
        {
            if (model == null)
            {
                return (false, Messages.NotExistsData);
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model?.Name.Length > 100)
            {
                return (false, Messages.InvalidName);
            }

            if (string.IsNullOrWhiteSpace(model.Family) || model?.Family.Length > 100)
            {
                return (false, Messages.InvalidFamily);
            }

            if (string.IsNullOrWhiteSpace(model.FatherName) || model?.FatherName.Length > 100)
            {
                return (false, Messages.InvalidFamily);
            }

            if (string.IsNullOrWhiteSpace(model.NationalCode) || model?.NationalCode.Length != 10 || Validations.IsValidNationaCode(model?.NationalCode) == false)
            {
                return (false, Messages.InvalidNationalCode);
            }

            if (model.BirthDate == DateTime.MinValue)
            {
                return (false, Messages.InvalidBirthDate);
            }

            return (true, "");
        }
    }
}
