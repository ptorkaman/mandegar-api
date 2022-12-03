using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class DepartmentActivityService : IDepartmentActivityService
    {
        private readonly IUow _uow;
        private readonly IFileManager _fileManager;

        public DepartmentActivityService(IUow uow, IFileManager fileManager)
        {
            _uow = uow;
            _fileManager = fileManager;
        }

        public async Task<Result<bool>> Add(DepartmentActivityVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<DepartmentActivity>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #region AttachmentFile
                if (string.IsNullOrWhiteSpace(modelVm.AttachmentFile) == false)
                {
                    Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                    modelVm.AttachmentFile = regex.Replace(modelVm.AttachmentFile, string.Empty);

                    byte[] imageBytes = Convert.FromBase64String(modelVm.AttachmentFile);

                    var upload = await _fileManager.UploadFile(imageBytes, DefaultPath.AttachmentFile, FileType.Images);
                    if (upload.Success)
                    {
                        _fileManager.ImageResizer(upload.Data.ToString(), DefaultPath.UserAvatar, 80);
                        modelVm.AttachmentFile = upload.Data.ToString();
                    }
                    else
                    {
                        return new Result<bool>(upload.Message);
                    }
                }
                else
                {
                    modelVm.AttachmentFile = "/Images/AttachmentFile/Default.jpg";
                }
                #endregion
                DepartmentActivity model = new DepartmentActivity()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name,
                    ActivityDescription=modelVm.ActivityDescription,
                    Description=modelVm.Description,
                    DepartmentId=modelVm.DepartmentId,
                    
                };
                await _uow.GetRepository<DepartmentActivity>().AddAsync(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
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

                var model = await _uow.GetRepository<DepartmentActivity>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<DepartmentActivity>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<DepartmentActivityVM>>> GetAll()
        {
            var data = await _uow.GetRepository<DepartmentActivity>()
               .Get(c => c.IsActive && !c.IsDeleted)
               .OrderByDescending(c => c.CreatedOn)
               .AsNoTracking()
               .Select(c => new DepartmentActivityVM
               {
                   Id = c.Id,
                   Name = c.Name,
                   DepartmentName = c.Department.Name,
                   DepartmentId = c.DepartmentId,
                   Description=c.Description,
                   ActivityDescription=c.ActivityDescription,
                   AttachmentFile=c.AttachmentFile
               })
               .ToListAsync();

            return new Result<List<DepartmentActivityVM>>(data);

            
        }

        public async Task<Result<bool>> Update(DepartmentActivityVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<DepartmentActivity>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var model = await _uow.GetRepository<DepartmentActivity>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                #region AttachmentFile
                if (string.IsNullOrWhiteSpace(modelVm.AttachmentFile) == false)
                {
                    Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                    modelVm.AttachmentFile = regex.Replace(modelVm.AttachmentFile, string.Empty);

                    byte[] imageBytes = Convert.FromBase64String(modelVm.AttachmentFile);

                    var upload = await _fileManager.UploadFile(imageBytes, DefaultPath.AttachmentFile, FileType.Images);
                    if (upload.Success)
                    {
                        _fileManager.ImageResizer(upload.Data.ToString(), DefaultPath.UserAvatar, 80);
                        modelVm.AttachmentFile = upload.Data.ToString();
                    }
                    else
                    {
                        return new Result<bool>(upload.Message);
                    }
                }
                else
                {
                    modelVm.AttachmentFile = "/Images/AttachmentFile/Default.jpg";
                }
                #endregion
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.DepartmentId = modelVm.DepartmentId;
                model.Description = modelVm.Description;
                model.ActivityDescription = modelVm.ActivityDescription;

                _uow.GetRepository<DepartmentActivity>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<DepartmentActivityVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentActivityVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<DepartmentActivity>().Get(id);
                if (model == null)
                    return new Result<DepartmentActivityVM>(Messages.NotExistsData);
                
                DepartmentActivityVM modelVm=new DepartmentActivityVM();
                modelVm.Id = model.Id;    
                modelVm.Name = model.Name;
                modelVm.ActivityDescription = model.ActivityDescription;
                modelVm.Description = model.Description;
                modelVm.DepartmentId = model.DepartmentId;
              
                return new Result<DepartmentActivityVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<DepartmentActivityVM>(false);
            }
        }
    }
}
