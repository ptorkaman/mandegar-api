using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
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
    public class PositionService : IPositionService
    {
        private readonly IUow _uow;
        public PositionService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(PositionVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<Position>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                Position model = new Position()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name,
                    ParentId=modelVm.ParentId.HasValue? modelVm.ParentId:null
                };
                await _uow.GetRepository<Position>().AddAsync(model);
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
                var existmodel = _uow.GetRepository<AssignTask>().GetWithInclude(c => c.Position).Where(x => x.PositionId == id).FirstOrDefault();
                if (existmodel != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var existmodel2 = _uow.GetRepository<DepartmentMember>().GetWithInclude(c => c.Department).Where(x => x.DepartmentId == id).FirstOrDefault();
                if (existmodel2 != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }
                var model = await _uow.GetRepository<Position>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.IsDeleted = true;
                _uow.GetRepository<Position>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<PositionVM>>> GetAll()
        {
            var data = await _uow.GetRepository<Position>()
               .Get(c => c.IsActive && !c.IsDeleted)
               .OrderByDescending(c => c.CreatedOn)
               .AsNoTracking()
               .Select(c => new PositionVM
               {
                   Id = c.Id,
                   Name = c.Name,
                   ParentName = c.Parent.Name,
                   ParentId = c.ParentId
               })
               .ToListAsync();

            return new Result<List<PositionVM>>(data);
        }

        public async Task<Result<bool>> Update(PositionVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<Position>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id && !c.IsDeleted).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var model = await _uow.GetRepository<Position>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.ParentId = modelVm.ParentId;
                _uow.GetRepository<Position>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<PositionVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<PositionVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<Position>().Get(id);
                if (model == null)
                    return new Result<PositionVM>(Messages.NotExistsData);
                
                PositionVM modelVm=new PositionVM();
                modelVm.Id = model.Id;    
                modelVm.Name = model.Name;
                modelVm.ParentId = model.ParentId;
                return new Result<PositionVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<PositionVM>(false);
            }
        }

        public async Task<Result<List<Position>>> GetAllPositions()
        {
            try
            {
                var data = await _uow.GetRepository<Position>().Get(c => c.IsActive && !c.IsDeleted).ToListAsync();
                return new Result<List<Position>>(data);
            }
            catch (Exception)
            {
                return new Result<List<Position>>(false);
            }
        }
    }
}
