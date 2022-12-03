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
    public class TaskGroupService : ITaskGroupService
    {
        private readonly IUow _uow;
        private readonly IPermissionService _permissionService;
        public TaskGroupService(IUow uow, IPermissionService permissionService)
        {
            _uow = uow;
            _permissionService = permissionService;
        }

        public async Task<Result<bool>> Add(TaskGroupVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
               
                var isExist = await _uow.GetRepository<TaskGroup>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                TaskGroup model = new TaskGroup()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name = modelVm.Name
                };
                await _uow.GetRepository<TaskGroup>().AddAsync(model);
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
                var assignTask = _uow.GetRepository<Tasks>().GetWithInclude(c => c.TaskGroup).Where(x => x.TaskGroupId == id).FirstOrDefault();
                if (assignTask != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                #endregion
                var model = await _uow.GetRepository<TaskGroup>().Get(id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.IsDeleted = true;
                _uow.GetRepository<TaskGroup>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<TaskGroup>>> GetAll()
        {
            var data = await _uow.GetRepository<TaskGroup>().Get(c => c.IsActive && !c.IsDeleted).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();
            return new Result<List<TaskGroup>>(data);
        }

        public async Task<Result<bool>> Update(TaskGroupVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
              
                var isExists = await _uow.GetRepository<TaskGroup>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id && !c.IsDeleted).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<TaskGroup>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now; 
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                _uow.GetRepository<TaskGroup>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<TaskGroupVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<TaskGroupVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<TaskGroup>().Get(id);
                if (model == null)
                    return new Result<TaskGroupVM>(Messages.NotExistsData);
                var permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<TaskGroupVM>(false);
                TaskGroupVM modelVm = new TaskGroupVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                return new Result<TaskGroupVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<TaskGroupVM>(false);
            }
        }
    }
}
