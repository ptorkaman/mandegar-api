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
    public class ProceedingsDepartmentService : IProceedingsDepartmentService
    {
        private readonly IUow _uow;

        public ProceedingsDepartmentService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(ProceedingsDepartmentVM request)
        {
            try
            {
                if (request.DepartmentMeetingId == 0)
                    return new Result<bool>(Messages.FillRequredValues);

                var exist = await _uow.GetRepository<ProceedingsDepartment>()
                    .Get(x => !x.IsDeleted && x.DepartmentMeetingId == request.DepartmentMeetingId)
                    .AnyAsync();

                if (exist)
                    return new Result<bool>(Messages.DuplicateMeetingName);

                //TODO:Check Duplicate
                ProceedingsDepartment model = new ProceedingsDepartment();

                model.CreatedById = ClaimHelper.GetUserId();
                model.DepartmentMeetingId = request.DepartmentMeetingId;

                TimeSpan time = TimeSpan.Parse(request.ProceedingStartTime);
                request.StartDate = request.StartDate.Add(time);
                model.StartDate = request.StartDate;

                time = TimeSpan.Parse(request.ProceedingEndTime);
                request.EndDate = request.EndDate.Add(time);
                model.EndDate = request.EndDate;

                model.Programs = request.Programs;
                model.Comments = request.Comments;
                model.Description = request.Description;

                if (model.EndDate < model.StartDate)
                    return new Result<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = Messages.InvalidEndDate
                    };

                if (model.StartDate > model.EndDate)
                    return new Result<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = Messages.InvalidStartDate
                    };

                await _uow.GetRepository<ProceedingsDepartment>().AddAsync(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception)
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

                ProceedingsDepartment entity = await _uow.GetRepository<ProceedingsDepartment>().Get(id);

                if (null == entity)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                entity.IsDeleted = true;

                _uow.GetRepository<ProceedingsDepartment>().Update(entity);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<PagingResultVM<ProceedingsDepartmentVM>>> GetAll(ProceedingsDepartmentSearchVM model)
        {
            IQueryable<ProceedingsDepartment> query = _uow.GetRepository<ProceedingsDepartment>()
                .Get(x => !x.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking();

            int recordsTotal = await query.CountAsync();


            if (string.IsNullOrWhiteSpace(model.Comments) == false)
            {
                query = query.Where(x => x.Comments.Contains(model.Comments));
            }

            if (string.IsNullOrWhiteSpace(model.Programs) == false)
            {
                query = query.Where(x => x.Programs.Contains(model.Programs));
            }

            if (string.IsNullOrWhiteSpace(model.Description) == false)
            {
                query = query.Where(x => x.Description.Contains(model.Description));
            }

            if (model.DepartmentMeetingId.HasValue)
            {
                query = query.Where(x => x.DepartmentMeetingId == model.DepartmentMeetingId);
            }

            if (null == model.EndDate && string.IsNullOrWhiteSpace(model.EndTime))
            {
                if (!string.IsNullOrWhiteSpace(model.StartTime) && null != model.StartDate)
                {
                    TimeSpan ts = TimeSpan.Parse(model.StartTime);
                    model.StartDate = model.StartDate.Value.Add(ts);
                    query = query.Where(x => x.StartDate <= model.StartDate);
                }

                if (null != model.StartDate && string.IsNullOrWhiteSpace(model.StartTime))
                {
                    model.StartDate = model.StartDate.Value.AddDays(1);
                    query = query.Where(x => x.StartDate <= model.StartDate);
                }
            }

            if (null == model.StartDate && string.IsNullOrWhiteSpace(model.StartTime))
            {
                if (!string.IsNullOrWhiteSpace(model.EndTime) && null != model.EndDate)
                {
                    TimeSpan ts = TimeSpan.Parse(model.EndTime);
                    model.EndDate = model.EndDate.Value.Add(ts);
                    query = query.Where(x => x.EndDate <= model.EndDate);
                }

                if (null != model.EndDate && string.IsNullOrWhiteSpace(model.EndTime))
                {
                    model.EndDate = model.EndDate.Value.AddDays(1);
                    query = query.Where(x => x.EndDate <= model.EndDate);
                }
            }

            if (null != model.StartDate && !string.IsNullOrWhiteSpace(model.StartTime) && null != model.EndDate && !string.IsNullOrWhiteSpace(model.EndTime))
            {
                TimeSpan ts = TimeSpan.Parse(model.StartTime);
                model.StartDate = model.StartDate.Value.Add(ts);

                ts = TimeSpan.Parse(model.EndTime);
                model.EndDate = model.EndDate.Value.Add(ts);

                query = query.Where(x => x.StartDate >= model.StartDate && x.EndDate <= model.EndDate);
            }

            int recordsFiltered = await query.CountAsync();

            IQueryable<ProceedingsDepartment> paged = query.ToPagedList(model.PageIndex, model.PageCount);
            List<ProceedingsDepartmentVM> data = await paged.Select(x => new ProceedingsDepartmentVM
            {
                Id = x.Id,
                DepartmentMeetingId = x.DepartmentMeetingId,
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                DepartmentMeetingTitle = x.DepartmentMeeting.Name
            }).ToListAsync();

            PagingResultVM<ProceedingsDepartmentVM> result = new PagingResultVM<ProceedingsDepartmentVM> { Rows = data, Total = recordsTotal };

            return new Result<PagingResultVM<ProceedingsDepartmentVM>>(result);
        }

        public async Task<Result<ProceedingsDepartmentVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<ProceedingsDepartmentVM>(Messages.NotExistsData);
                }

                ProceedingsDepartment entity = await _uow.GetRepository<ProceedingsDepartment>().Get(id);

                if (null == entity)
                {
                    return new Result<ProceedingsDepartmentVM>(Messages.NotExistsData);
                }
                return new Result<ProceedingsDepartmentVM>(new ProceedingsDepartmentVM
                {
                    Comments = entity.Comments,
                    DepartmentMeetingId = entity.DepartmentMeetingId,
                    EndDate = entity.EndDate,
                    StartDate = entity.StartDate,
                    Id = entity.Id,
                    Programs = entity.Programs,
                    Description = entity.Description
                });
            }
            catch (Exception)
            {
                return new Result<ProceedingsDepartmentVM>(false);
            }
        }

        public async Task<Result<bool>> Update(ProceedingsDepartmentVM model)
        {
            try
            {
                //TODO: Check Duplicate
                var exist = await _uow.GetRepository<ProceedingsDepartment>()
                   .Get(x => !x.IsDeleted && x.DepartmentMeetingId == model.DepartmentMeetingId && x.Id != model.Id)
                   .AnyAsync();

                if (exist)
                    return new Result<bool>(Messages.DuplicateMeetingName);


                ProceedingsDepartment entity = await _uow.GetRepository<ProceedingsDepartment>()
                    .Get(x => x.Id == model.Id)
                    .SingleOrDefaultAsync();

                if (null == entity)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                entity.ModifiedOn = DateTime.Now;
                entity.Programs = model.Programs;

                TimeSpan time = TimeSpan.Parse(model.ProceedingStartTime);
                model.StartDate = model.StartDate.Add(time);
                entity.StartDate = model.StartDate;

                time = TimeSpan.Parse(model.ProceedingEndTime);
                model.EndDate = model.EndDate.Add(time);
                entity.EndDate = model.EndDate;

                entity.DepartmentMeetingId = model.DepartmentMeetingId;
                entity.Comments = model.Comments;
                entity.Description = model.Description;
                entity.ModifiedById = ClaimHelper.GetUserId();

                if (model.EndDate < model.StartDate)
                    return new Result<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = Messages.InvalidEndDate
                    };

                if (model.StartDate > model.EndDate)
                    return new Result<bool>
                    {
                        Data = false,
                        Success = false,
                        Message = Messages.InvalidStartDate
                    };

                _uow.GetRepository<ProceedingsDepartment>().Update(entity);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception)
            {
                return new Result<bool>(false);
            }
        }
    }
}
