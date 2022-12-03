using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.EvaluationIndicator;
using Mandegar.Models.ViewModels.Shared;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Mandegar.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class EvaluationIndicatorService : IEvaluationIndicatorService
    {
        private readonly IUow _uow;

        public EvaluationIndicatorService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<PagingResultVM<EvaluationIndicatorResultVM>>> GetAll(EvaluationIndicatorSearchVM model)
        {
            IQueryable<EvaluationIndicator> query = _uow.GetRepository<EvaluationIndicator>()
                .GetWithInclude(new string[] { "DepartmentEvaluationGroup", "DepartmentLesson" })
                .Where(x=>!x.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking();

            int recordsTotal = await query.CountAsync();


            if (model.DepartmentEvaluationGroupId.HasValue)
            {
                query = query.Where(x => x.DepartmentEvaluationGroupId.Equals(model.DepartmentEvaluationGroupId));
            }

            if (model.DepartmentLessonId.HasValue)
            {
                query = query.Where(x => x.DepartmentLessonId.Equals(model.DepartmentLessonId));
            }

            if (!string.IsNullOrWhiteSpace(model.Question))
            {
                query = query.Where(x => x.Question.Contains(model.Question));
            }

            if (model.ScoreCeiling.HasValue)
            {
                query = query.Where(x => x.ScoreCeiling.Equals(model.ScoreCeiling));
            }

            int recordsFiltered = await query.CountAsync();

            IQueryable<EvaluationIndicator> paged = query.ToPagedList(model.PageIndex, model.PageCount);
            List<EvaluationIndicatorResultVM> data = await paged.Select(x => new EvaluationIndicatorResultVM
            {
                Id = x.Id,
                EvaluationGroup = x.DepartmentEvaluationGroup.Name,
                Lesson = x.DepartmentLesson.Lesson.Name,
                Question = x.Question,
                ScoreCeiling = x.ScoreCeiling

            }).ToListAsync();

            PagingResultVM<EvaluationIndicatorResultVM> result = new PagingResultVM<EvaluationIndicatorResultVM> { Rows = data, Total = recordsFiltered };

            return new Result<PagingResultVM<EvaluationIndicatorResultVM>>(result);
        }

        public async Task<Result<EvaluationIndicator>> GetById(int id)
        {
            if (id == 0)
                return new Result<EvaluationIndicator>(Messages.NotExistsData);

            EvaluationIndicator entity = await _uow.GetRepository<EvaluationIndicator>().Get(id);

            if (null == entity)
                return new Result<EvaluationIndicator>(Messages.NotExistsData);

            return new Result<EvaluationIndicator>(entity);
        }

        public async Task<Result<bool>> Add(EvaluationIndicatorVM request)
        {
            bool isExist = await _uow.GetRepository<EvaluationIndicator>()
                    .Get(x => x.DepartmentEvaluationGroupId == request.DepartmentEvaluationGroupId && x.DepartmentLessonId == request.DepartmentLessonId && !x.IsDeleted)
                    .AnyAsync();

            if (isExist)
            {
                return new Result<bool>(Messages.DuplicateScheduleMeeting);
            }

            EvaluationIndicator model = new EvaluationIndicator();

            model.CreatedOn = DateTime.Now;
            model.DepartmentEvaluationGroupId = request.DepartmentEvaluationGroupId;
            model.CreatedById = ClaimHelper.GetUserId();
            model.DepartmentLessonId = request.DepartmentLessonId;
            model.Question = request.Question;
            model.ScoreCeiling = request.ScoreCeiling;

            await _uow.GetRepository<EvaluationIndicator>().AddAsync(model);
            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<bool>> Update(EvaluationIndicatorVM request)
        {
            try
            {
                bool isExist = await _uow.GetRepository<EvaluationIndicator>()
                    .Get(x => x.Id != request.Id && x.DepartmentEvaluationGroupId == request.DepartmentEvaluationGroupId && x.DepartmentLessonId == request.DepartmentLessonId && !x.IsDeleted)
                    .AnyAsync();

                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateScheduleMeeting);
                }

                var entity = await _uow.GetRepository<EvaluationIndicator>().Get(request.Id);

                EvaluationIndicator model = new EvaluationIndicator();


                entity.DepartmentEvaluationGroupId = request.DepartmentEvaluationGroupId;
                entity.ModifiedById = ClaimHelper.GetUserId();
                entity.ModifiedOn = DateTime.Now;
                entity.DepartmentLessonId = request.DepartmentLessonId;
                entity.Question = request.Question;
                entity.ScoreCeiling = request.ScoreCeiling;

                _uow.GetRepository<EvaluationIndicator>().Update(entity);
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
                    return new Result<bool>(Messages.NotExistsData);

                EvaluationIndicator entity = await _uow.GetRepository<EvaluationIndicator>()
                    .Get(id);

                if (null == entity)
                    return new Result<bool>(Messages.NotExistsData);

                entity.IsDeleted = true;

                _uow.GetRepository<EvaluationIndicator>().Update(entity);
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
            List<CollectionVM> data = await _uow.GetRepository<Lesson>()
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
