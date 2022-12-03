using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Departments;
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
    public class LessonService : ILessonService
    {
        private readonly IUow _uow;
        private readonly IPermissionService _permissionService;
        public LessonService(IUow uow, IPermissionService permissionService)
        {
            _uow = uow;
            _permissionService = permissionService;
        }

        public async Task<Result<bool>> Add(LessonVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<Lesson>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var isExistEducationCourseCode = await _uow.GetRepository<Lesson>().Get(c => c.EducationCourseCode == modelVm.EducationCourseCode && !c.IsDeleted).AnyAsync();
                if (isExistEducationCourseCode)
                {
                    return new Result<bool>(Messages.IsExistBasecode);
                }
                Lesson model = new Lesson()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name = modelVm.Name,
                    EducationCourseCode = modelVm.EducationCourseCode,
                    LessonTypeId = modelVm.LessonTypeId,
                    StudyGradeId = modelVm.StudyGradeId,
                    CourseUnits = modelVm.CourseUnits,

                };
                await _uow.GetRepository<Lesson>().AddAsync(model);
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
                var existModel = _uow.GetRepository<Tasks>().GetWithInclude(c=>c.TaskGroup).Where(x=>x.Id==id).FirstOrDefault();
                if (existModel != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var existmodel1 = _uow.GetRepository<DepartmentLesson>().GetWithInclude(c => c.Lesson).Where(x => x.LessonId == id).FirstOrDefault();
                if (existmodel1 != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var model = await _uow.GetRepository<Lesson>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<Lesson>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<LessonVM>>> GetAll()
        {
            var data = await _uow.GetRepository<Lesson>()
                         .Get(c => c.IsActive && !c.IsDeleted)
                         .OrderByDescending(c => c.CreatedOn)
                         .AsNoTracking()
                         .Select(c => new LessonVM
                         {
                             Id = c.Id,
                             EducationCourseCode = c.EducationCourseCode,
                             LessonTypeId = c.LessonTypeId,
                             LessonTypeName = c.LessonType.Name,
                             Name = c.Name,
                             StudyGradeId = c.StudyGradeId,
                             StudyGradeName = c.StudyGrade.Name,
                             CourseUnits = c.CourseUnits,

                         })
                         .ToListAsync();
            return new Result<List<LessonVM>>(data);            
        }

        public async Task<Result<bool>> Update(LessonVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                
                var isExists = await _uow.GetRepository<Lesson>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id && !c.IsDeleted).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<Lesson>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.EducationCourseCode = modelVm.EducationCourseCode;
                model.LessonTypeId = modelVm.LessonTypeId;
                model.StudyGradeId = modelVm.StudyGradeId;
                model.CourseUnits = modelVm.CourseUnits;
                _uow.GetRepository<Lesson>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<LessonVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<LessonVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<Lesson>().Get(id);
                if (model == null)
                    return new Result<LessonVM>(Messages.NotExistsData);
                var permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<LessonVM>(false);
                LessonVM modelVm=new LessonVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.EducationCourseCode = model.EducationCourseCode;
                modelVm.LessonTypeId = model.LessonTypeId;
                modelVm.CourseUnits = model.CourseUnits;
                modelVm.StudyGradeId = model.StudyGradeId;
                return new Result<LessonVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<LessonVM>(false);
            }
        }
    }
}
