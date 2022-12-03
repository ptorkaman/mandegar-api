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
    public class LessonTypeService : ILessonTypeService
    {
        private readonly IUow _uow;
        public LessonTypeService(IUow uow)
        {
            _uow = uow;
        }
        public async Task<Result<bool>> Add(LessonTypeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                           
                var isExist = await _uow.GetRepository<LessonType>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion 
                LessonType model = new LessonType()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name
                };
                await _uow.GetRepository<LessonType>().AddAsync(model);
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
                var existmodel = _uow.GetRepository<Lesson>().GetWithInclude(c => c.LessonType).Where(x => x.LessonTypeId == id).FirstOrDefault();
                if (existmodel != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                #endregion
                var model = await _uow.GetRepository<LessonType>().Get(id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.IsDeleted = true;

                _uow.GetRepository<LessonType>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<LessonType>>> GetAll()
        {
            var data = await _uow.GetRepository<LessonType>().Get(c => c.IsActive && !c.IsDeleted).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();

            return new Result<List<LessonType>>(data);
        }

        public async Task<Result<bool>> Update(LessonTypeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
            
                var isExists = await _uow.GetRepository<LessonType>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<LessonType>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                _uow.GetRepository<LessonType>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<LessonTypeVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<LessonTypeVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<LessonType>().Get(id);
                if (model == null)
                    return new Result<LessonTypeVM>(Messages.NotExistsData);
                LessonTypeVM modelVm=new LessonTypeVM();
                modelVm.Id = model.Id;    
                modelVm.Name = model.Name;  

                return new Result<LessonTypeVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<LessonTypeVM>(false);
            }
        }
    }
}
