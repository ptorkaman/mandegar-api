using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Mandegar.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class DepartmentScheduleService : IDepartmentScheduleService
    {
        private readonly IUow _uow;
        public DepartmentScheduleService(IUow uow)
        {
            _uow = uow;
        }
        public async Task<Result<List<DepartmentScheduleVM>>> Collection()
        {
            List<DepartmentScheduleVM> data = await _uow.GetRepository<DepartmentSchedule>()
                .Get(x => !x.IsDeleted)
                .Select(x => new DepartmentScheduleVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return new Result<List<DepartmentScheduleVM>>(data);
        }



        public async Task<Result<bool>> Add(DepartmentScheduleVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                if (modelVm.FromDate >= modelVm.ToDate)
                {
                    return new Result<bool>(Messages.InvalidDate);
                }
                #endregion
                var isExist = await _uow.GetRepository<DepartmentSchedule>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                DepartmentSchedule model = new DepartmentSchedule()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name = modelVm.Name,
                    ExecutiveCalendarId = modelVm.ExecutiveCalendarId,
                    TimeLimit = modelVm.TimeLimit,
                    FromDate = modelVm.FromDate,
                    ToDate = modelVm.ToDate
                };
                await _uow.GetRepository<DepartmentSchedule>().AddAsync(model);
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

                var model = await _uow.GetRepository<DepartmentSchedule>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<DepartmentSchedule>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<PagingResultVM<DepartmentScheduleVM>>>   GetAll(DepartmentScheduleVM search)
        {
            var query = _uow.GetRepository<DepartmentSchedule>()
                               .Get(c => c.IsActive && !c.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking();
            #region filter
            var recordsTotal = await query.CountAsync();
            if (string.IsNullOrWhiteSpace(search.Name) == false)
            {
                query = query.Where(c => c.Name.Contains(search.Name));
            }
            if (string.IsNullOrWhiteSpace(search.TimeLimit) == false)
            {
                query = query.Where(c => c.TimeLimit.Contains(search.TimeLimit));
            }
            if (search.ExecutiveCalendarId!= null && search.ExecutiveCalendarId !=0)
            {
                query = query.Where(c => c.ExecutiveCalendarId==search.ExecutiveCalendarId);
            }
            if (search.FromDate!= null)
            {
                query = query.Where(c => c.FromDate.Value.Date>=search.FromDate.Value.Date);
            }
            if (search.ToDate != null)
            {
                query = query.Where(c => c.ToDate.Value.Date <= search.ToDate.Value.Date);
            }
            #endregion
            var recordsFiltered = await query.CountAsync();

            var paged = query.ToPagedList(search.PageIndex, search.PageCount);
            var data = await paged.Select(c => new DepartmentScheduleVM
            {
                Id = c.Id,
                Name = c.Name,
                ExecutiveCalendarId = c.ExecutiveCalendarId,
                TimeLimit = c.TimeLimit,
                ToDate = c.ToDate,
                FromDate = c.FromDate,
                ExecutiveCalendarName = c.ExecutiveCalendar.Name,
            }).ToListAsync();

            var result = new PagingResultVM<DepartmentScheduleVM> { Rows = data, Total = recordsTotal };

            return new Result<PagingResultVM<DepartmentScheduleVM>>(result);
        }

        public async Task<Result<bool>> Update(DepartmentScheduleVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<DepartmentSchedule>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var task = await _uow.GetRepository<DepartmentSchedule>().Get(modelVm.Id);
                if (task == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                task.ModifiedOn = DateTime.Now;
                task.ModifiedById = ClaimHelper.GetUserId();
                task.Name = modelVm.Name;
                task.FromDate = modelVm.FromDate;
                task.ToDate = modelVm.ToDate;
                task.ExecutiveCalendarId = modelVm.ExecutiveCalendarId;
                task.TimeLimit = modelVm.TimeLimit;
                _uow.GetRepository<DepartmentSchedule>().Update(task);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<DepartmentScheduleVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentScheduleVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<DepartmentSchedule>().Get(id);
                if (model == null)
                    return new Result<DepartmentScheduleVM>(Messages.NotExistsData);

                DepartmentScheduleVM modelVm = new DepartmentScheduleVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.FromDate = model.FromDate;
                modelVm.ToDate = model.ToDate;
                modelVm.TimeLimit = model.TimeLimit;
                modelVm.ExecutiveCalendarId = model.ExecutiveCalendarId;

                return new Result<DepartmentScheduleVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<DepartmentScheduleVM>(false);
            }
        }


    }
}
