using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class StudyFieldService : IStudyFieldService
    {
        private readonly IUow _uow;
        private readonly IPermissionService _permissionService;
        public StudyFieldService(IUow uow, IPermissionService permissionService)
        {
            _uow = uow;
            _permissionService = permissionService;
        }

        public async Task<Result<bool>> Add(StudyFieldVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                         
                var isExist = await _uow.GetRepository<StudyField>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                StudyField model = new StudyField()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name,
                    //StudyDefreeId=modelVm.StudyDefreeId

                };
                await _uow.GetRepository<StudyField>().AddAsync(model);
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
                #region Validation
                var existmodel = _uow.GetRepository<StudyGrade>().GetWithInclude(c => c.StudyField).Where(x => x.StudyFieldId == id).FirstOrDefault();
                if (existmodel != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                #endregion
                var model = await _uow.GetRepository<StudyField>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }
                model.IsDeleted = true;
                _uow.GetRepository<StudyField>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<StudyFieldVM>>> GetAll()
        {

            var data = await _uow.GetRepository<StudyField>()
                          .Get(c => c.IsActive && !c.IsDeleted)
                          .OrderByDescending(c => c.CreatedOn)
                          .AsNoTracking()
                          .Select(c => new StudyFieldVM
                          {
                              Id = c.Id,
                              Name = c.Name,
                              //StudyDefreeId = c.StudyDefreeId,
                              //StudyDegreeName = c.StudyDegree.Name
                          })
                          .ToListAsync();

            return new Result<List<StudyFieldVM>>(data);
        }

        public async Task<Result<bool>> Update(StudyFieldVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
               
                var isExists = await _uow.GetRepository<StudyField>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<StudyField>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                //model.StudyDefreeId = modelVm.StudyDefreeId;
                _uow.GetRepository<StudyField>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<StudyFieldVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<StudyFieldVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<StudyField>().Get(id);
                if (model == null)
                    return new Result<StudyFieldVM>(Messages.NotExistsData);
                var permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<StudyFieldVM>(false);
                StudyFieldVM modelVm=new StudyFieldVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                //modelVm.StudyDefreeId = model.StudyDefreeId;

                return new Result<StudyFieldVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<StudyFieldVM>(false);
            }
        }
    }
}
