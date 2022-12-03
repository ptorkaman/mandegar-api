using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Models.ViewModels.Shared;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Mandegar.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class DepartmentMeetingMemberService : IDepartmentMeetingMember
    {
        private readonly IUow _uow;

        public DepartmentMeetingMemberService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(MeetingMemberVM request)
        {
            using (IDatabaseTransaction transaction = _uow.BeginTransaction())
            {
                try
                {
                    //TODO : Check Duplicate Department Meeting Member

                    var exists = await _uow.GetRepository<DepartmentMeetingMember>()
                    .Get(x => !x.IsDeleted && x.DepartmentMeetingId == request.DepartmentMeetingId).AnyAsync();

                    if (exists)
                        return new Result<bool>(Messages.DuplicateMeetingMemeber);

                    DepartmentMeetingMember model = new DepartmentMeetingMember();

                    model.DepartmentId = request.DepartmentId;
                    model.DepartmentMeetingId = request.DepartmentMeetingId;
                    model.CreatedById = ClaimHelper.GetUserId();

                    await _uow.GetRepository<DepartmentMeetingMember>().AddAsync(model);
                    await _uow.SaveChangesAsync();

                    foreach (var item in request.MemberIds)
                    {
                        await _uow.GetRepository<MeetingMember>().AddAsync(new MeetingMember
                        {
                            DepartmentMeetingMemberId = model.Id,
                            DepartmentMemberId = item,
                            CreatedById = ClaimHelper.GetUserId()
                        });
                    }

                    await _uow.SaveChangesAsync();
                    transaction.Commit();
                    return new Result<bool>(true);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return new Result<bool>(false);
                }
            }
        }

        public async Task<Result<List<CollectionVM>>> Collection(int? id)
        {
            List<CollectionVM> result = new List<CollectionVM>();

            var data = _uow.GetRepository<DepartmentMember>()
                .GetWithInclude(x => x.Staff);
            //.DistinctBy(x => x.Staff.Id);

            if (id != 0)
            {
                result = data.Where(x => x.DepartmentId == id.Value && !x.IsDeleted)

                .Select(x => new CollectionVM
                {
                    Id = x.DepartmentId,
                    Name = x.Staff.Name + " " + x.Staff.Family,
                    Code = x.Staff.Id.ToString()
                }).ToList();
            }
            else
            {
                result = data.Where(x => !x.IsDeleted).Select(x => new CollectionVM
                {
                    Id = x.DepartmentId,
                    Name = x.Staff.Name + " " + x.Staff.Family,
                    Code = x.Staff.Id.ToString()
                }).ToList();
            }
            return new Result<List<CollectionVM>>(result);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                DepartmentMeetingMember entity = await _uow.GetRepository<DepartmentMeetingMember>().Get(id);

                if (null == entity)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                entity.IsDeleted = true;

                List<MeetingMember> members = await _uow.GetRepository<MeetingMember>()
                    .Get(x => x.DepartmentMeetingMemberId == id && !x.IsDeleted)
                    .ToListAsync();

                foreach (var item in members)
                {
                    item.IsDeleted = true;
                }

                _uow.GetRepository<DepartmentMeetingMember>().Update(entity);

                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<DepartmentStaffVM>>> GetAllMembers(int id)
        {
            DepartmentMemberSearchVM search = new DepartmentMemberSearchVM { Id = id };
            List<DepartmentStaffVM> data = await _uow.ExecuteReader<DepartmentStaffVM>("dbo", "GetAllMembersInMeeting", search);
            return new Result<List<DepartmentStaffVM>>() { Data = data, Success = true };
        }

        public async Task<Result<PagingResultVM<DepartmentMeetingMemberVM>>> GetAll(DepartmentMeetingMemberSearchVM request)
        {
            try
            {
                DataTable dt = new DataTable();
                DepartmentMeetingMemberQueryVM model = new DepartmentMeetingMemberQueryVM();
                dt.Columns.AddRange(new DataColumn[1] { new DataColumn("DepartmentMemberId", typeof(int)) });

                if (!string.IsNullOrWhiteSpace(request.DepartmentMemberIds))
                {
                    int[] ids = request.DepartmentMemberIds.Split(',').Select(Int32.Parse).ToArray();
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
                model.DepartmentId = request.DepartmentId;
                model.IsCount = true;

                var total = await _uow.ExecuteScalar(null, "GetAllDepartmentMeetingMember", model);

                model.IsCount = false;
                List<DepartmentMeetingMemberVM> data = await _uow.ExecuteReader<DepartmentMeetingMemberVM>(null, "GetAllDepartmentMeetingMember", model);

                PagingResultVM<DepartmentMeetingMemberVM> result = new PagingResultVM<DepartmentMeetingMemberVM> { Rows = data, Total = (int)total };

                return new Result<PagingResultVM<DepartmentMeetingMemberVM>>(result);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<Result<MeetingMemberVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<MeetingMemberVM>(Messages.NotExistsData);
                }

                DepartmentMeetingMember entity = await _uow.GetRepository<DepartmentMeetingMember>()
                    .GetWithInclude(new string[] { "MeetingMembers", "DepartmentMeeting" })
                    .Where(c => c.Id == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var items = entity.MeetingMembers
                .Where(x => x.DepartmentMeetingMemberId == entity.Id && !x.IsDeleted)
                .Select(x => x.DepartmentMember).ToList();

                if (null == entity)
                {
                    return new Result<MeetingMemberVM>(Messages.NotExistsData);
                }
                return new Result<MeetingMemberVM>(new MeetingMemberVM
                {
                    Id = entity.Id,
                    DepartmentId = entity.DepartmentId,
                    DepartmentMeetingId = entity.DepartmentMeetingId,
                    MemberIds = entity.MeetingMembers.Where(x => x.DepartmentMeetingMemberId == entity.Id && !x.IsDeleted).Select(x => x.DepartmentMemberId).ToList()
                });
            }
            catch (Exception)
            {
                return new Result<MeetingMemberVM>(false);
            }
        }

        public async Task<Result<bool>> Update(MeetingMemberVM model)
        {
            try
            {
                var exists = _uow.GetRepository<DepartmentMeetingMember>()
                    .Get(c => !c.IsDeleted)
                    .AsNoTracking();

                var ckeckDepartmentMeeting = exists.Where(x => x.DepartmentMeetingId == model.DepartmentMeetingId).FirstOrDefault();

                if (null != ckeckDepartmentMeeting)
                    if (ckeckDepartmentMeeting.Id != model.Id)
                    {
                        return new Result<bool>(Messages.DuplicateMeetingMemeber);
                    }

                DepartmentMeetingMember entity = await _uow.GetRepository<DepartmentMeetingMember>()
                     .GetWithInclude(new string[] { "MeetingMembers" })
                    .Where(c => c.Id == model.Id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (null == entity)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                entity.ModifiedOn = DateTime.Now;
                entity.DepartmentId = model.DepartmentId;
                entity.DepartmentMeetingId = model.DepartmentMeetingId;

                List<MeetingMember> members = entity.MeetingMembers.Where(x => !x.IsDeleted).ToList();

                foreach (var item in members)
                {
                    item.IsDeleted = true;
                    _uow.GetRepository<MeetingMember>().Update(item);
                }

                foreach (var item in model.MemberIds)
                {
                    await _uow.GetRepository<MeetingMember>().AddAsync(new MeetingMember
                    {
                        DepartmentMeetingMemberId = model.Id,
                        DepartmentMemberId = item,
                        CreatedById = ClaimHelper.GetUserId()
                    });
                }

                _uow.GetRepository<DepartmentMeetingMember>().Update(entity);
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
