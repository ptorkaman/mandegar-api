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
    public class CooperationTypeService : ICooperationTypeService
    {
        private readonly IUow _uow;
        public CooperationTypeService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(CooperationTypeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<CooperationType>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                CooperationType model = new CooperationType()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name
                };
                await _uow.GetRepository<CooperationType>().AddAsync(model);
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

                var model = await _uow.GetRepository<CooperationType>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<CooperationType>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<CooperationType>>> GetAll()
        {
            var data = await _uow.GetRepository<CooperationType>().Get(c => c.IsActive && !c.IsDeleted).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();

            return new Result<List<CooperationType>>(data);
        }

        public async Task<Result<bool>> Update(CooperationTypeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<CooperationType>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var mdoel = await _uow.GetRepository<CooperationType>().Get(modelVm.Id);
                if (mdoel == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                mdoel.ModifiedOn = DateTime.Now;
                mdoel.ModifiedById = ClaimHelper.GetUserId();
                mdoel.Name = modelVm.Name;
                _uow.GetRepository<CooperationType>().Update(mdoel);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<CooperationTypeVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<CooperationTypeVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<CooperationType>().Get(id);
                if (model == null)
                    return new Result<CooperationTypeVM>(Messages.NotExistsData);

                CooperationTypeVM modelVm=new CooperationTypeVM();
                modelVm.Id = model.Id;    
                modelVm.Name = model.Name;  

                return new Result<CooperationTypeVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<CooperationTypeVM>(false);
            }
        }
    }
}
