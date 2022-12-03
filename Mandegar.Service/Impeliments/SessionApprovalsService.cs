using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.SessionApproval;
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
using System.Web;

namespace Mandegar.Services.Impeliments
{
    public class SessionApprovalsService : ISessionApprovalsService
    {
        private readonly IUow _uow;

        public SessionApprovalsService(IUow uow)
        {
            _uow = uow;
        }
        public async Task<Result<PagingResultVM<SessionApprovalResultVM>>> GetAll(SessionApprovalSearchVM request)
        {
            try
            {
                DataTable dt = new DataTable();
                SessionApprovalQueryVM model = new SessionApprovalQueryVM();
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
                model.Test = request.Test;
                model.DeadlineFrom = request.DeadlineFrom;
                model.DeadlineTo = request.DeadlineTo;
                model.IsCount = true;

                var total = await _uow.ExecuteScalar(null, "GetAllSessionApproval", model);

                model.IsCount = false;

                List<SessionApprovalResultVM> data = await _uow.ExecuteReader<SessionApprovalResultVM>(null, "GetAllSessionApproval", model);
                PagingResultVM<SessionApprovalResultVM> result = new PagingResultVM<SessionApprovalResultVM> { Rows = data, Total = (int)total };
                return new Result<PagingResultVM<SessionApprovalResultVM>>(result);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task<Result<SessionApprovalVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<SessionApprovalVM>(Messages.NotExistsData);
                }

                SessionApprovalVM entity = new SessionApprovalVM();

                var data = await _uow.GetRepository<SessionApprovals>()
                    .GetWithInclude(new string[] { "SessionApprovalMembers" })
                    .SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == id);

                if (null != data)
                {
                    entity.Id = data.Id;
                    entity.DepartmentMeetingId = data.DepartmentMeetingId;
                    entity.Deadline = data.Deadline;
                    entity.Test = HttpUtility.HtmlDecode(data.Test);
                    entity.MemberIds = data.SessionApprovalMembers
                        .Where(x => !x.IsDeleted)
                        .Select(x => x.DepartmentMeetingMemberId)
                        .ToList();
                }

                return new Result<SessionApprovalVM>(entity);
            }
            catch (System.Exception)
            {
                return new Result<SessionApprovalVM>(false);
            }
        }
        public async Task<Result<bool>> Add(SessionApprovalVM model)
        {
            try
            {
                using (IDatabaseTransaction transaction = _uow.BeginTransaction())
                {
                    try
                    {
                        bool isExist = await _uow.GetRepository<SessionApprovals>()
                            .Get(x => !x.IsDeleted && x.DepartmentMeetingId == model.DepartmentMeetingId)
                            .AnyAsync();

                        if (isExist)
                        {
                            return new Result<bool>(Messages.DuplicateSessionApproval);
                        }

                        SessionApprovals entity = new SessionApprovals
                        {
                            DepartmentMeetingId = model.DepartmentMeetingId,
                            Deadline = model.Deadline,
                            Test = HttpUtility.HtmlEncode(model.Test),
                            CreatedById = ClaimHelper.GetUserId(),
                            CreatedOn = DateTime.Now
                        };
                        await _uow.GetRepository<SessionApprovals>().AddAsync(entity);
                        await _uow.SaveChangesAsync();

                        foreach (var item in model.MemberIds)
                        {
                            await _uow.GetRepository<SessionApprovalMembers>().AddAsync(new SessionApprovalMembers
                            {
                                DepartmentMeetingMemberId = item,
                                SessionApprovalsId = entity.Id,
                                CreatedById = ClaimHelper.GetUserId(),
                                CreatedOn = DateTime.Now
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
            catch (System.Exception)
            {
                return new Result<bool>(false);
            }
        }
        public async Task<Result<bool>> Update(SessionApprovalVM model)
        {
            try
            {
                bool isExist = await _uow.GetRepository<SessionApprovals>()
                    .Get(x => !x.IsDeleted && x.Id != model.Id && x.DepartmentMeetingId == model.DepartmentMeetingId)
                    .AnyAsync();

                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateSessionApproval);
                }

                SessionApprovals entity = await _uow.GetRepository<SessionApprovals>()
                    .GetWithInclude(new string[] { "SessionApprovalMembers" })
                    .SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == model.Id);

                entity.DepartmentMeetingId = model.DepartmentMeetingId;
                entity.Deadline = model.Deadline;
                entity.Test = HttpUtility.HtmlEncode(model.Test);
                entity.ModifiedById = ClaimHelper.GetUserId();
                entity.ModifiedOn = DateTime.Now;

                List<SessionApprovalMembers> sessionApprovalMembers = entity.SessionApprovalMembers.ToList();
                int length = sessionApprovalMembers.Count;
                for (int i = 0; i < length; i++)
                {
                    sessionApprovalMembers[i].IsDeleted = true;
                    sessionApprovalMembers[i].ModifiedById = ClaimHelper.GetUserId();
                    sessionApprovalMembers[i].ModifiedOn = DateTime.Now;
                }

                _uow.GetRepository<SessionApprovals>().Update(entity);

                foreach (var item in model.MemberIds)
                {
                    await _uow.GetRepository<SessionApprovalMembers>().AddAsync(new SessionApprovalMembers
                    {
                        DepartmentMeetingMemberId = item,
                        SessionApprovalsId = entity.Id,
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
        public async Task<Result<bool>> Delete(int id)
        {
            try
            {
                SessionApprovals entity = await _uow.GetRepository<SessionApprovals>()
                    .GetWithInclude(new string[] { "SessionApprovalMembers" })
                    .SingleOrDefaultAsync(x => !x.IsDeleted && x.Id == id);

                if (entity == null)
                    return new Result<bool>(Messages.NotExistsData);

                entity.IsDeleted = true;

                List<SessionApprovalMembers> sessionApprovalMembers = entity.SessionApprovalMembers.ToList();
                int length = sessionApprovalMembers.Count;
                for (int i = 0; i < length; i++)
                {
                    sessionApprovalMembers[i].IsDeleted = true;
                }

                _uow.GetRepository<SessionApprovals>().Update(entity);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Result<List<SessionApprovalResultVM>>> GetAllMembers(int id)
        {
            List<SessionApprovalResultVM> data = await _uow.ExecuteReader<SessionApprovalResultVM>("dbo", "GetAllMemebersInSessionApprovals", new { SessionApprovalsId = id });
            return new Result<List<SessionApprovalResultVM>>() { Data = data, Success = true };
        }
    }
}
