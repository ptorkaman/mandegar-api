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
    public class DepartmentActivityTypeService : IDepartmentActivityTypeService
    {
        private readonly IUow _uow;
        public DepartmentActivityTypeService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(DepartmentActivityTypeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<DepartmentActivityType>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                DepartmentActivityType model = new DepartmentActivityType()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name
                };
                await _uow.GetRepository<DepartmentActivityType>().AddAsync(model);
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

                var model = await _uow.GetRepository<DepartmentActivityType>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<DepartmentActivityType>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<DepartmentActivityType>>> GetAll()
        {
            var data = await _uow.GetRepository<DepartmentActivityType>().Get(c => c.IsActive && !c.IsDeleted).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();

            return new Result<List<DepartmentActivityType>>(data);
        }

        public async Task<Result<bool>> Update(DepartmentActivityTypeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<DepartmentActivityType>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var model = await _uow.GetRepository<DepartmentActivityType>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                _uow.GetRepository<DepartmentActivityType>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<DepartmentActivityTypeVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentActivityTypeVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<DepartmentActivityType>().Get(id);
                if (model == null)
                    return new Result<DepartmentActivityTypeVM>(Messages.NotExistsData);
               
                DepartmentActivityTypeVM modelVm=new DepartmentActivityTypeVM();
                modelVm.Id = model.Id;    
                modelVm.Name = model.Name;  

                return new Result<DepartmentActivityTypeVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<DepartmentActivityTypeVM>(false);
            }
        }
    }
}
