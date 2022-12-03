using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
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
using System.Linq.Dynamic.Core;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Utilities.Extensions;
using System.Text.RegularExpressions;
using Mandegar.Models.ViewModels.Shared;

namespace Mandegar.Services.Impeliments
{
    public class DepartmentMeetingService : IDepartmentMeetingService
    {
        private readonly IUow _uow;

        public DepartmentMeetingService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(DepartmentMeetingVM request)
        {
            try
            {
                bool isExist = await _uow.GetRepository<DepartmentMeeting>()
                    .Get(x => x.Name == request.Name && x.DepartmentScheduleId == request.DepartmentScheduleId && !x.IsDeleted)
                    .AnyAsync();

                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateScheduleMeeting);
                }

                DepartmentMeeting model = new DepartmentMeeting();

                TimeSpan time = TimeSpan.Parse(request.Time);
                request.MeetingDate = request.MeetingDate.Add(time);
                model.CreatedById = ClaimHelper.GetUserId();
                model.Name = request.Name;
                model.MeetingDate = request.MeetingDate;
                model.DepartmentScheduleId = request.DepartmentScheduleId;

                await _uow.GetRepository<DepartmentMeeting>().AddAsync(model);
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

                DepartmentMeeting entity = await _uow.GetRepository<DepartmentMeeting>()
                    .GetWithInclude(new string[] { "DepartmentMeetingMembers" })
                    .Where(x => x.Id == id)
                    .SingleOrDefaultAsync();

                if (null == entity)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                if(entity.DepartmentMeetingMembers.Count >0)
                {
                    return new Result<bool>(Messages.AccessDeniedMeeting);
                }

                entity.IsDeleted = true;

                _uow.GetRepository<DepartmentMeeting>().Update(entity);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<DepartmentMeeting>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentMeeting>(Messages.NotExistsData);
                }

                DepartmentMeeting entity = await _uow.GetRepository<DepartmentMeeting>().Get(id);

                if (null == entity)
                {
                    return new Result<DepartmentMeeting>(Messages.NotExistsData);
                }

                return new Result<DepartmentMeeting>(entity);
            }
            catch (Exception)
            {
                return new Result<DepartmentMeeting>(false);
            }
        }

        public async Task<Result<PagingResultVM<DepartmentMeeting>>> GetAll(DepartmentMeetingSearchVM search)
        {
            IQueryable<DepartmentMeeting> query = _uow.GetRepository<DepartmentMeeting>()
                .Get(x => !x.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking();

            int recordsTotal = await query.CountAsync();


            if (string.IsNullOrWhiteSpace(search.Name) == false)
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            if (!string.IsNullOrWhiteSpace(search.Time) && null != search.MeetingDate)
            {
                TimeSpan ts = TimeSpan.Parse(search.Time);
                search.MeetingDate = search.MeetingDate.Value.Add(ts);
                query = query.Where(x => x.MeetingDate <= search.MeetingDate);
            }

            if (null != search.MeetingDate && string.IsNullOrWhiteSpace(search.Time))
            {
                search.MeetingDate = search.MeetingDate.Value.AddDays(1);
                query = query.Where(x => x.MeetingDate <= search.MeetingDate);
            }

            if (search.DepartmentScheduleId.HasValue)
            {
                query = query.Where(x => x.DepartmentScheduleId == search.DepartmentScheduleId);
            }

            int recordsFiltered = await query.CountAsync();

            IQueryable<DepartmentMeeting> paged = query.ToPagedList(search.PageIndex, search.PageCount);
            List<DepartmentMeeting> data = await paged.Select(x => new DepartmentMeeting
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name,
                MeetingDate = x.MeetingDate,
                DepartmentScheduleName = x.DepartmentSchedule.Name
            }).ToListAsync();

            PagingResultVM<DepartmentMeeting> result = new PagingResultVM<DepartmentMeeting> { Rows = data, Total = recordsFiltered };

            return new Result<PagingResultVM<DepartmentMeeting>>(result);
        }

        public async Task<Result<bool>> Update(DepartmentMeetingVM model)
        {
            try
            {
                bool isExists = await _uow.GetRepository<DepartmentMeeting>()
                    .Get(x => x.Name == model.Name && x.Id != model.Id && x.DepartmentScheduleId == model.DepartmentScheduleId)
                    .AnyAsync();

                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateScheduleMeeting);
                }

                DepartmentMeeting entity = await _uow.GetRepository<DepartmentMeeting>()
                    .Get(x => x.Id == model.Id)
                    .SingleOrDefaultAsync();

                if (null == entity)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                entity.ModifiedOn = DateTime.Now;
                entity.Name = model.Name;
                TimeSpan time = TimeSpan.Parse(model.Time);
                model.MeetingDate = model.MeetingDate.Add(time);
                entity.MeetingDate = model.MeetingDate;
                entity.DepartmentScheduleId = model.DepartmentScheduleId;

                _uow.GetRepository<DepartmentMeeting>().Update(entity);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<CollectionVM>>> Collection()
        {
            List<CollectionVM> data = await _uow.GetRepository<DepartmentMeeting>()
                .Get(x => !x.IsDeleted)
                .Select(x => new CollectionVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();

            return new Result<List<CollectionVM>>(data);
        }
    }
}
