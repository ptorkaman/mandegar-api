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
    public class AssignTaskService : IAssignTaskService
    {
        private readonly IUow _uow;
        private readonly ITaskService _taskService;
        public AssignTaskService(IUow uow, ITaskService taskService)
        {
            _uow = uow;
            _taskService = taskService;
        }

        public async Task<Result<bool>> Add(AssignTaskVM modelVM)
        {
            try
            {
                #region Validation
                if (modelVM.SelectTaskList.Count == 0)
                {
                    return new Result<bool>(Messages.HasNotSelectTask);
                }

                #endregion

                foreach (var item in modelVM.SelectTaskList)
                {
                    var isExist1 = await _uow.GetRepository<AssignTask>().Get(c => c.TaskId == item.Id && c.PositionId == modelVM.PositionId).AnyAsync();
                    if (!isExist1)
                    {
                        AssignTask model = new AssignTask()
                        {
                            PositionId = modelVM.PositionId,
                            TaskId = item.Id
                        };
                        await _uow.GetRepository<AssignTask>().AddAsync(model);
                    }
                }
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
                var model = await _uow.GetRepository<AssignTask>().Get(ClosedXML => ClosedXML.PositionId == id).ToListAsync();
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                _uow.GetRepository<AssignTask>().DeleteRange(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<AssignTaskVM>>> GetAll()
        {
            try
            {
                var data = _uow.GetRepository<AssignTask>()
                   .Get().Include("Position")
                   .Include("Task")
                   .AsEnumerable().GroupBy(m => m.PositionId)
                   .Select(g => new AssignTaskVM
                   {
                       Id = g.Key,
                       PositionId = g.Key,
                       PositionName = g.FirstOrDefault().Position.Name,
                       Task = g.FirstOrDefault().Task
                   })
                      .ToList();
                foreach (var item in data)
                {
                   var tasklist =  _uow.GetRepository<AssignTask>()
                    .Get(x=>x.PositionId==item.PositionId)
                    .Include("Task")
                    .AsEnumerable()                    
                       .ToList();
                    string title = "";

                    foreach (var itm in tasklist)
                    {
                        if (itm.PositionId == item.PositionId)
                        {
                            if (title == "")
                                title = item.Task.Name;
                            else
                                title = title + " , " + itm.Task.Name;
                        }                        
                    }
                    item.TaskName = title;
                }
                return new Result<List<AssignTaskVM>>(data);
            }
            catch (Exception ex)
            {

                return new Result<List<AssignTaskVM>>();
            }

        }

        public async Task<Result<List<AssignTaskVM>>> GetAllByPositionId(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<List<AssignTaskVM>>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<AssignTask>().Get().Include("Task").Where(x => x.PositionId == id)
                     .Select(g => new AssignTaskVM
                     {
                         PositionId = g.PositionId,
                         PositionName = g.Position.Name,
                         TaskId = g.TaskId,
                         TaskName = g.Task.Name,
                         Id = g.TaskId,
                         Name = g.Task.Name,
                         TaskGroupId = g.Task.TaskGroupId

                     })
                    .ToListAsync();
                if (model == null)
                    return new Result<List<AssignTaskVM>>(Messages.NotExistsData);

                return new Result<List<AssignTaskVM>>(model);
            }
            catch (Exception ex)
            {
                return new Result<List<AssignTaskVM>>(false);
            }
        }

        public async Task<Result<Root>> GetAllTasks()
        {
            try
            {
                Result<List<Tasks>> tasks = await _taskService.GetAllTasks();
                if (!tasks.Success)
                    return new Result<Root>(false);

                Root root = new Root();
                foreach (Tasks item in tasks.Data)
                {
                    // if (item.TaskGroupId == null)
                    root.data.Add(new TreeNode
                    {
                        data = item.Id,
                        expandedIcon = "pi pi-user",
                        collapsedIcon = "pi pi-user",
                        label = item.Name,
                        //children = item.AssignTasks != null ? getChild(item.Positions.ToList()) : null
                    });
                }

                return new Result<Root>(root);
            }
            catch (Exception)
            {
                return new Result<Root>(false);
            }
        }

        public async Task<Result<AssignTaskVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<AssignTaskVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<AssignTask>().Get(id);
                if (model == null)
                    return new Result<AssignTaskVM>(Messages.NotExistsData);

                AssignTaskVM modelVm = new AssignTaskVM();
                modelVm.TaskId = model.TaskId;
                modelVm.PositionId = model.PositionId;
                return new Result<AssignTaskVM>(modelVm);
            }
            catch (Exception ex)
            {
                return new Result<AssignTaskVM>(false);
            }
        }

        public async Task<Result<bool>> Update(AssignTaskVM modelVM)
        {
            try
            {
                #region Validation
                #endregion
                var alltask = _uow.GetRepository<AssignTask>().Get(x => x.PositionId == modelVM.PositionId).ToList(); _uow.GetRepository<AssignTask>().DeleteRange(alltask);
                _uow.SaveChanges();
                if (modelVM.SelectTaskList.Count > 0)
                {
                    foreach (var task in modelVM.SelectTaskList.ToArray())
                    {
                        modelVM.TaskId = task.Id;
                        var isExist = _uow.GetRepository<AssignTask>().Get(c => c.PositionId == modelVM.PositionId && c.TaskId == modelVM.TaskId).Any();
                        if (!isExist)
                        {
                            AssignTask assignTask = new AssignTask()
                            {
                                PositionId = modelVM.PositionId,
                                TaskId = task.Id
                            };
                            await _uow.GetRepository<AssignTask>().AddAsync(assignTask);
                        }
                    }
                    await _uow.SaveChangesAsync();
                }
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

    }
}
