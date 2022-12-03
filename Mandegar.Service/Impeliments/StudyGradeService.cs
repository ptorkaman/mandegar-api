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
    public class StudyGradeService : IStudyGradeService
    {
        private readonly IUow _uow;
        private readonly IPermissionService _permissionService;
        public StudyGradeService(IUow uow, IPermissionService permissionService)
        {
            _uow = uow;
            _permissionService = permissionService;
        }

        public async Task<Result<bool>> Add(StudyGradeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                var isExistBasecode = await _uow.GetRepository<StudyGrade>().Get(c => c.Name == modelVm.Name && c.EducationBasicCode == modelVm.EducationBasicCode  && !c.IsDeleted).AnyAsync();
                if (isExistBasecode)
                {
                    return new Result<bool>(Messages.DuplicateInfo);
                }
                        
                //var isExist = await _uow.GetRepository<StudyGrade>().Get(c => c.Name == modelVm.Name && c.EducationBasicCode == modelVm.EducationBasicCode && !c.IsDeleted).AnyAsync();
                //if (isExist)
                //{
                //    return new Result<bool>(Messages.DuplicateInfo);
                //}
                #endregion
                StudyGrade model = new StudyGrade()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name = modelVm.Name,
                    StudyFieldId = modelVm.StudyFieldId,
                    EducationBasicCode = modelVm.EducationBasicCode
                };
                await _uow.GetRepository<StudyGrade>().AddAsync(model);
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
                var existmodel = _uow.GetRepository<Lesson>().GetWithInclude(c => c.StudyGrade).Where(x => x.StudyGradeId == id).FirstOrDefault();
                if (existmodel != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                #endregion
                var model = await _uow.GetRepository<StudyGrade>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.IsDeleted = true;
                _uow.GetRepository<StudyGrade>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<StudyGradeVM>>> GetAll()
        {
            var data = await _uow.GetRepository<StudyGrade>()
                          .Get(c => c.IsActive && !c.IsDeleted)
                          .OrderByDescending(c => c.CreatedOn)
                          .AsNoTracking()
                          .Select(c => new StudyGradeVM
                          {
                              Id = c.Id,
                              Name = c.Name,
                              StudyFieldId = c.StudyFieldId,
                              StudyFieldName = c.StudyField.Name,
                              EducationBasicCode = c.EducationBasicCode
                              
                          })
                          .ToListAsync();

            return new Result<List<StudyGradeVM>>(data);           
        }

        public async Task<Result<bool>> Update(StudyGradeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
               
                var isExists = await _uow.GetRepository<StudyGrade>().Get(c => c.Name == modelVm.Name && c.EducationBasicCode==modelVm.EducationBasicCode && !c.IsDeleted).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateInfo);
                }
                #endregion
                var model = await _uow.GetRepository<StudyGrade>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.StudyFieldId = modelVm.StudyFieldId;
                model.EducationBasicCode = modelVm.EducationBasicCode;
                _uow.GetRepository<StudyGrade>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<StudyGradeVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<StudyGradeVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<StudyGrade>().Get(id);
                if (model == null)
                    return new Result<StudyGradeVM>(Messages.NotExistsData);
                var permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<StudyGradeVM>(false);
                StudyGradeVM modelVm=new StudyGradeVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.EducationBasicCode = model.EducationBasicCode;
                modelVm.StudyFieldId = model.StudyFieldId;

                return new Result<StudyGradeVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<StudyGradeVM>(false);
            }
        }
    }
}
