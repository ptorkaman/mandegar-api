using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.EvaluationGroup;
using Mandegar.Models.ViewModels.Shared;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
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
    public class EvaluationGroupService: IEvaluationGroupService
    {
        private readonly IUow _uow;

        public EvaluationGroupService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(EvaluationGroupVM request)
        {
            try
            {
                var exist = await _uow.GetRepository<DepartmentEvaluationGroup>()
                    .Get(x => !x.IsDeleted && x.Name == request.Name)
                    .AnyAsync();

                if (exist)
                    return new Result<bool>(Messages.DuplicateData);

                DepartmentEvaluationGroup model = new DepartmentEvaluationGroup();
                model.CreatedById = ClaimHelper.GetUserId();
                model.Name = request.Name;

                await _uow.GetRepository<DepartmentEvaluationGroup>().AddAsync(model);
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

                DepartmentEvaluationGroup entity = await _uow.GetRepository<DepartmentEvaluationGroup>().Get(id);

                if (null == entity)
                    return new Result<bool>(Messages.NotExistsData);

                entity.IsDeleted = true;

                _uow.GetRepository<DepartmentEvaluationGroup>().Update(entity);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<PagingResultVM<EvaluationGroupResultVM>>> GetAll(EvaluationGroupSearchVM model)
        {
            IQueryable<DepartmentEvaluationGroup> query = _uow.GetRepository<DepartmentEvaluationGroup>()
                .Get(x => !x.IsDeleted)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking();

            int recordsTotal = await query.CountAsync();


            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains(model.Name));
            }

            int recordsFiltered = await query.CountAsync();

            IQueryable<DepartmentEvaluationGroup> paged = query.ToPagedList(model.PageIndex, model.PageCount);
            List<EvaluationGroupResultVM> data = await paged.Select(x => new EvaluationGroupResultVM
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            PagingResultVM<EvaluationGroupResultVM> result = new PagingResultVM<EvaluationGroupResultVM> { Rows = data, Total = recordsFiltered };

            return new Result<PagingResultVM<EvaluationGroupResultVM>>(result);
        }

        public async Task<Result<EvaluationGroupResultVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                    return new Result<EvaluationGroupResultVM>(Messages.NotExistsData);

                DepartmentEvaluationGroup entity = await _uow.GetRepository<DepartmentEvaluationGroup>().Get(id);

                if (null == entity)
                    return new Result<EvaluationGroupResultVM>(Messages.NotExistsData);

                return new Result<EvaluationGroupResultVM>(new EvaluationGroupResultVM
                {
                    Id = entity.Id,
                    Name = entity.Name
                });
            }
            catch (Exception)
            {
                return new Result<EvaluationGroupResultVM>(false);
            }
        }

        public async Task<Result<bool>> Update(EvaluationGroupVM model)
        {
            try
            {
                var exist = await _uow.GetRepository<DepartmentEvaluationGroup>()
                   .Get(x => !x.IsDeleted && x.Name == model.Name && x.Id != model.Id)
                   .AnyAsync();

                if (exist)
                    return new Result<bool>(Messages.DuplicateData);

                DepartmentEvaluationGroup entity = await _uow.GetRepository<DepartmentEvaluationGroup>()
                    .Get(x => x.Id == model.Id)
                    .SingleOrDefaultAsync();

                if (null == entity)
                    return new Result<bool>(Messages.NotExistsData);

                entity.ModifiedOn = DateTime.Now;
                entity.Name = model.Name;

                _uow.GetRepository<DepartmentEvaluationGroup>().Update(entity);
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
            List<CollectionVM> data = await _uow.GetRepository<DepartmentEvaluationGroup>()
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
