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
    public class DepartmentLessonService : IDepartmentLessonService
    {
        private readonly IUow _uow;
        public DepartmentLessonService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(DepartmentLesson model)
        {
            try
            {
                #region Validation
                if (model.LessonId == 0|| model.DepartmentId == 0)
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExist = await _uow.GetRepository<DepartmentLesson>().Get(c => c.LessonId == model.LessonId && c.DepartmentId == model.DepartmentId && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                //model.CreatedById = ClaimHelper.GetUserId();
                await _uow.GetRepository<DepartmentLesson>().AddAsync(model);
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

                var model = await _uow.GetRepository<DepartmentLesson>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<DepartmentLesson>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<DepartmentLessonVM>>> GetAll()
        {
            var data = await _uow.GetRepository<DepartmentLesson>()
               .Get(c => c.IsActive && !c.IsDeleted)
               .AsNoTracking()
               .Select(c => new DepartmentLessonVM
               {
                   Id=c.Id,
                   DepartmentId = c.DepartmentId,
                   LessonId = c.LessonId,
                   LessonName = c.Lesson.Name,
                   DepartmentName = c.Department.Name
               })
               .ToListAsync();

            return new Result<List<DepartmentLessonVM>>(data);
        }



        public async Task<Result<DepartmentLessonVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentLessonVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<DepartmentLesson>().Get(id);
                if (model == null)
                    return new Result<DepartmentLessonVM>(Messages.NotExistsData);

                DepartmentLessonVM modelVm = new DepartmentLessonVM();
                modelVm.DepartmentId = model.DepartmentId;
                modelVm.LessonId = model.LessonId;
                return new Result<DepartmentLessonVM>(modelVm);
            }
            catch (Exception ex)
            {
                return new Result<DepartmentLessonVM>(false);
            }
        }

        public async Task<Result<bool>> Update(DepartmentLessonVM modelVm)
        {
            try
            {
                #region Validation
                if (modelVm.DepartmentId==0)
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<DepartmentLesson>().Get(c => c.DepartmentId == modelVm.DepartmentId && c.LessonId==modelVm.LessonId && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var model = await _uow.GetRepository<DepartmentLesson>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.DepartmentId = modelVm.DepartmentId;
                model.LessonId = modelVm.LessonId;
                _uow.GetRepository<DepartmentLesson>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }
    }
}
