using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Models.ViewModels.Shared;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class DepartmentMeetingAttendeesService : IDepartmentMeetingAttendeesService
    {
        private readonly IUow _uow;

        public DepartmentMeetingAttendeesService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(DepartmentMeetingAttendeesVM model)
        {
            try
            {
                bool isExist = await _uow.GetRepository<DepartmentMeetingAttendees>()
                    .Get(x => !x.IsDeleted && x.DepartmentMeetingId == model.DepartmentMeetingId)
                    .AnyAsync();

                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateAttendees);
                }

                foreach (var item in model.MemberIds)
                {
                    await _uow.GetRepository<DepartmentMeetingAttendees>().AddAsync(new DepartmentMeetingAttendees
                    {
                        DepartmentMeetingId = model.DepartmentMeetingId,
                        DepartmentMemberId = item,
                        CreatedById = ClaimHelper.GetUserId(),
                        CreatedOn = DateTime.Now
                    });
                }
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (System.Exception)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<CollectionVM>>> Collection(int? id)
        {
            List<CollectionVM> result = new List<CollectionVM>();
            List<AttendeesMembersVM> data = await _uow.ExecuteReader<AttendeesMembersVM>("dbo", "GetAllAttendeesMembers", new { Id = id.Value });

            foreach (var item in data)
            {
                result.Add(new CollectionVM
                {
                    Code = item.Id.ToString(),
                    Name = item.FullName,
                    Id = item.DepartmentMeetingId
                });
            }

            return new Result<List<CollectionVM>>(result);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            try
            {
                List<DepartmentMeetingAttendees> entites = await _uow
                    .GetRepository<DepartmentMeetingAttendees>()
                    .Get(x => x.DepartmentMeetingId == id && !x.IsDeleted)
                    .ToListAsync();

                foreach (var item in entites)
                {
                    item.IsDeleted = true;
                    item.ModifiedById = ClaimHelper.GetUserId();
                    item.ModifiedOn = DateTime.Now;
                    _uow.GetRepository<DepartmentMeetingAttendees>().Update(item);
                }

                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (System.Exception)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<PagingResultVM<DepartmentMeetingAttendeesResultVM>>> GetAll(DepartmentMeetingAttendeesSearchVM request)
        {
            try
            {
                DataTable dt = new DataTable();
                DepartmentMeetingAttendeesQueryVM model = new DepartmentMeetingAttendeesQueryVM();
                dt.Columns.AddRange(new DataColumn[1] { new DataColumn("DepartmentMemberId", typeof(int)) });

                if (!string.IsNullOrWhiteSpace(request.MemberIds))
                {
                    int[] ids = request.MemberIds.Split(',').Select(Int32.Parse).ToArray();
                    foreach (var memberId in ids)
                    {
                        dt.Rows.Add(memberId);
                    }
                }

                model.PageCount = request.PageCount;
                model.PageIndex = request.PageIndex;
                model.OrderAsc = request.OrderAsc;
                model.OrderBy = request.OrderBy;
                model.MemberIds = dt;
                model.DepartmentMeetingId = request.DepartmentMeetingId;
                model.IsCount = true;

                var total = await _uow.ExecuteScalar(null, "GetAllDepartmentMeetingAttendees", model);
                model.IsCount = false;
                List<DepartmentMeetingAttendeesResultVM> data = await _uow.ExecuteReader<DepartmentMeetingAttendeesResultVM>(null, "GetAllDepartmentMeetingAttendees", model);
                data = data.GroupBy(x => x.DepartmentMeetingId).Select(x => x.First()).ToList();
                PagingResultVM<DepartmentMeetingAttendeesResultVM> result = new PagingResultVM<DepartmentMeetingAttendeesResultVM> { Rows = data, Total = (int)total };


                return new Result<PagingResultVM<DepartmentMeetingAttendeesResultVM>>(result);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<Result<List<DepartmentMeetingAttendeesResultVM>>> GetAllMembers(int id)
        {
            List<DepartmentMeetingAttendeesResultVM> data = await _uow.ExecuteReader<DepartmentMeetingAttendeesResultVM>(null, "GetAllAttendees", new { Id = id });
            return new Result<List<DepartmentMeetingAttendeesResultVM>>() { Data = data, Success = true };
        }

        public async Task<Result<DepartmentMeetingAttendeesVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentMeetingAttendeesVM>(Messages.NotExistsData);
                }
                DepartmentMeetingAttendeesVM entity = new DepartmentMeetingAttendeesVM();
                var data = await _uow.GetRepository<DepartmentMeetingAttendees>()
                    .Get(x => !x.IsDeleted && x.DepartmentMeetingId == id)
                    .ToListAsync();

                if (null != data)
                {
                    entity.DepartmentMeetingId = id;
                    foreach (var item in data)
                    {
                        entity.Id = item.Id;
                        entity.MemberIds.Add(item.DepartmentMemberId);
                    }
                }

                return new Result<DepartmentMeetingAttendeesVM>(entity);
            }
            catch (System.Exception)
            {
                return new Result<DepartmentMeetingAttendeesVM>(false);
            }
        }

        public async Task<Result<bool>> Update(DepartmentMeetingAttendeesVM model)
        {
            try
            {
                
                if(model.Id != model.DepartmentMeetingId)
                {
                    return new Result<bool>(Messages.DuplicateAttendees);
                }

                List<DepartmentMeetingAttendees> entites = await _uow.GetRepository<DepartmentMeetingAttendees>()
                    .Get(x => !x.IsDeleted && x.DepartmentMeetingId == model.DepartmentMeetingId)
                    .ToListAsync();

                foreach (var item in entites)
                {
                    item.IsDeleted = true;
                    item.ModifiedById = ClaimHelper.GetUserId();
                    item.ModifiedOn = DateTime.Now;
                    _uow.GetRepository<DepartmentMeetingAttendees>().Update(item);
                }

                foreach (var item in model.MemberIds)
                {
                    await _uow.GetRepository<DepartmentMeetingAttendees>().AddAsync(new DepartmentMeetingAttendees
                    {
                        DepartmentMeetingId = model.DepartmentMeetingId,
                        DepartmentMemberId = item,
                        CreatedById = ClaimHelper.GetUserId(),
                        CreatedOn = DateTime.Now
                    });
                }

                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (System.Exception)
            {
                return new Result<bool>(false);
            }
        }
    }
}
