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
    public class ActivityCaseService : IActivityCaseService
    {
        private readonly IUow _uow;
        public ActivityCaseService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(ActivityCaseVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<ActivityCase>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                ActivityCase model = new ActivityCase()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name
                };
                await _uow.GetRepository<ActivityCase>().AddAsync(model);
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

                var model = await _uow.GetRepository<ActivityCase>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<ActivityCase>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<ActivityCase>>> GetAll()
        {
            var data = await _uow.GetRepository<ActivityCase>().Get(c => c.IsActive && !c.IsDeleted).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();

            return new Result<List<ActivityCase>>(data);
        }

        public async Task<Result<bool>> Update(ActivityCaseVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<ActivityCase>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var model = await _uow.GetRepository<ActivityCase>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                _uow.GetRepository<ActivityCase>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<ActivityCaseVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<ActivityCaseVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<ActivityCase>().Get(id);
                if (model == null)
                    return new Result<ActivityCaseVM>(Messages.NotExistsData);

                ActivityCaseVM modelVm=new ActivityCaseVM();
                modelVm.Id = model.Id;    
                modelVm.Name = model.Name;  

                return new Result<ActivityCaseVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<ActivityCaseVM>(false);
            }
        }
    }
}
