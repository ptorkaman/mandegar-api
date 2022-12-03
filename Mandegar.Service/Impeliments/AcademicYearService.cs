using Mandegar.Models.Entities.BaseInfo;
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
    public class AcademicYearService : IAcademicYearService
    {
        private readonly IUow _uow;
        public AcademicYearService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(AcademicYearVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                if (modelVm.FromDate>=modelVm.ToDate )
                {
                    return new Result<bool>(Messages.InvalidDate);
                }
                #endregion
                var isExist = await _uow.GetRepository<AcademicYear>().Get(c => c.Name == modelVm.Name && c.FromDate==modelVm.FromDate && c.ToDate==modelVm.ToDate && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                AcademicYear model = new AcademicYear()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name = modelVm.Name,
                    FromDate = modelVm.FromDate,
                    ToDate = modelVm.ToDate
                };
                await _uow.GetRepository<AcademicYear>().AddAsync(model);
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
               
                var model = await _uow.GetRepository<AcademicYear>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                var executiveCalendar = _uow.GetRepository<ExecutiveCalendar>().GetWithInclude(c => c.AcademicYear).Where(x => x.AcademicYearId == id).FirstOrDefault();
                if (executiveCalendar != null)
                {
                    return new Result<bool>(Messages.ExistrelationItem);
                }

                model.IsDeleted = true;

                _uow.GetRepository<AcademicYear>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<AcademicYear>>> GetAll()
        {
            var data = await _uow.GetRepository<AcademicYear>().Get(c => c.IsActive && !c.IsDeleted).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();

            return new Result<List<AcademicYear>>(data);
        }

        public async Task<Result<bool>> Update(AcademicYearVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                if (modelVm.FromDate >= modelVm.ToDate)
                {
                    return new Result<bool>(Messages.InvalidDate);
                }
                #endregion
                var isExists = await _uow.GetRepository<AcademicYear>().Get(c => c.Name == modelVm.Name && c.FromDate==modelVm.FromDate && c.ToDate==modelVm.ToDate && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var model = await _uow.GetRepository<AcademicYear>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.FromDate = modelVm.FromDate;
                model.ToDate = modelVm.ToDate;
                _uow.GetRepository<AcademicYear>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<AcademicYearVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<AcademicYearVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<AcademicYear>().Get(id);
                if (model == null)
                    return new Result<AcademicYearVM>(Messages.NotExistsData);
                
                AcademicYearVM modelVm=new AcademicYearVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.FromDate = model.FromDate;
                modelVm.ToDate = model.ToDate;

                return new Result<AcademicYearVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<AcademicYearVM>(false);
            }
        }
    }
}
