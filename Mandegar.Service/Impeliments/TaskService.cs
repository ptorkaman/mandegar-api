using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Models.ViewModels.Common;
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
    public class TaskService : ITaskService
    {
        private readonly IUow _uow;
        private readonly IPermissionService _permissionService;
        public TaskService(IUow uow, IPermissionService permissionService)
        {
            _uow = uow;
            _permissionService = permissionService;
        }

        public async Task<Result<bool>> Add(Models.Entities.Personeli.Tasks model)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
              
                var isExist = await _uow.GetRepository<Models.Entities.Personeli.Tasks>().Get(c => c.Name == model.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                model.CreatedById = ClaimHelper.GetUserId();
                await _uow.GetRepository<Models.Entities.Personeli.Tasks>().AddAsync(model);
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
                var existmodel = _uow.GetRepository<AssignTask>().GetWithInclude(c => c.Task).Where(x => x.TaskId == id).FirstOrDefault();
                if (existmodel != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                #endregion
                var model = await _uow.GetRepository<Tasks>().Get(id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.IsDeleted = true;
                _uow.GetRepository<Tasks>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<TaskVM>>> GetAll()
        {
            var data = await _uow.GetRepository<Tasks>()
                .Get(c => c.IsActive && !c.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .Include(c => c.TaskGroup)
                .AsNoTracking()
                .Select(c => new TaskVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    TaskGroupId = c.TaskGroupId,
                    TaskGroupName = c.TaskGroup.Name
                })
                .ToListAsync();

            return new Result<List<TaskVM>>(data);
        }

        public async Task<Result<bool>> Update(Tasks modelVm)
        {
            try
            {
                #region Validation

                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                var isExists = await _uow.GetRepository<Tasks>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<Tasks>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.TaskGroupId = modelVm.TaskGroupId;

                _uow.GetRepository<Tasks>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<TaskVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<TaskVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<Models.Entities.Personeli.Tasks>().Get(id);
                if (model == null)
                    return new Result<TaskVM>(Messages.NotExistsData);
                var permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<TaskVM>(false);
                TaskVM modelVm = new TaskVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.TaskGroupId = model.TaskGroupId;
                return new Result<TaskVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<TaskVM>(false);
            }
        }

       
        public async Task<Result<List<Tasks>>> GetAllTasks()
        {
            try
            {
                var data = await _uow.GetRepository<Tasks>().Get(c => c.IsActive && !c.IsDeleted).ToListAsync();
                return new Result<List<Tasks>>(data);
            }
            catch (Exception)
            {
                return new Result<List<Tasks>>(false);
            }
        }

        public async Task<Result<List<TaskVM>>> GetAllByTaskGroupId(int taskGroupId)
        {
            try
            {
                var data = await _uow.GetRepository<Tasks>()
                .Get(c => c.IsActive && !c.IsDeleted && c.TaskGroupId==taskGroupId)
                .OrderByDescending(c => c.CreatedOn)
                .Include(c => c.TaskGroup)                
                .AsNoTracking()
                .Select(c => new TaskVM
                {
                    Id = c.Id,
                    Name = c.Name,
                    TaskGroupId = c.TaskGroupId,
                    TaskGroupName = c.TaskGroup.Name
                })
                .ToListAsync();

                return new Result<List<TaskVM>>(data);
            }
            catch (Exception)
            {
                return new Result<List<TaskVM>>(false);
            }
        }
    }
}
