using Mandegar.Models.Entities.Departments;
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
    public class DepartmentService : IDepartmentService
    {
        private readonly IUow _uow;
        public DepartmentService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(DepartmentVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<Department>().Get(c => c.Name == modelVm.Name && c.ParentId==modelVm.ParentId && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                Department model = new Department()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name,
                    ParentId=modelVm.ParentId
                };
                await _uow.GetRepository<Department>().AddAsync(model);
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
                #region validation
                var isExist = await _uow.GetRepository<Department>().Get(c => c.ParentId == id ).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var existmodel1 = _uow.GetRepository<DepartmentLesson>().GetWithInclude(c => c.Lesson).Where(x => x.LessonId == id).FirstOrDefault();
                if (existmodel1 != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var existmodel2 = _uow.GetRepository<DepartmentMember>().GetWithInclude(c => c.Department).Where(x => x.DepartmentId == id).FirstOrDefault();
                if (existmodel2 != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var existmodel3 = _uow.GetRepository<DepartmentActivity>().GetWithInclude(c => c.Department).Where(x => x.DepartmentId == id).FirstOrDefault();
                if (existmodel3 != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                #endregion
                var model = await _uow.GetRepository<Department>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<Department>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<DepartmentVM>>> GetAll()
        {
            var data = await _uow.GetRepository<Department>()
               .Get(c => c.IsActive && !c.IsDeleted)
               .OrderByDescending(c => c.CreatedOn)
               .AsNoTracking()
               .Select(c => new DepartmentVM
               {
                   Id = c.Id,
                   Name =c.ParentId!=null? c.Name +" ("+ c.Parent.Name+")":c.Name,
                   ParentName = c.Parent.Name,
                   ParentId = c.ParentId
               })
               .ToListAsync();

            return new Result<List<DepartmentVM>>(data);           
        }

        public async Task<Result<bool>> Update(DepartmentVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
             
                var isExists = await _uow.GetRepository<Department>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<Department>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.ParentId = modelVm.ParentId;
                _uow.GetRepository<Department>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<DepartmentVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<Department>().Get(id);
                if (model == null)
                    return new Result<DepartmentVM>(Messages.NotExistsData);
               
                DepartmentVM modelVm=new DepartmentVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.ParentId = model.ParentId;

                return new Result<DepartmentVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<DepartmentVM>(false);
            }
        }
    }
}
