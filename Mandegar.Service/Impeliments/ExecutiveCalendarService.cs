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
    public class ExecutiveCalendarService : IExecutiveCalendarService
    {
        private readonly IUow _uow;
        public ExecutiveCalendarService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(ExecutiveCalendarVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<ExecutiveCalendar>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                ExecutiveCalendar model = new ExecutiveCalendar()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name = modelVm.Name,
                    AcademicYearId = modelVm.AcademicYearId,
                };
                await _uow.GetRepository<ExecutiveCalendar>().AddAsync(model);
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
               
                var model = await _uow.GetRepository<ExecutiveCalendar>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<ExecutiveCalendar>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<ExecutiveCalendarVM>>> GetAll()
        {
            var data = await _uow.GetRepository<ExecutiveCalendar>()
               .Get(c => c.IsActive && !c.IsDeleted)
               .OrderByDescending(c => c.CreatedOn)
               .AsNoTracking()
               .Select(c => new ExecutiveCalendarVM
               {
                   Id = c.Id,
                   Name = c.Name,
                   AcademicYearName = c.AcademicYear.Name,
                   AcademicYearId = c.AcademicYearId
               })
               .ToListAsync();

            return new Result<List<ExecutiveCalendarVM>>(data);           
        }

        public async Task<Result<bool>> Update(ExecutiveCalendarVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<ExecutiveCalendar>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                var model = await _uow.GetRepository<ExecutiveCalendar>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.AcademicYearId = modelVm.AcademicYearId;
                _uow.GetRepository<ExecutiveCalendar>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<ExecutiveCalendarVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<ExecutiveCalendarVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<ExecutiveCalendar>().Get(id);
                if (model == null)
                    return new Result<ExecutiveCalendarVM>(Messages.NotExistsData);
                
                ExecutiveCalendarVM modelVm=new ExecutiveCalendarVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.AcademicYearId = model.AcademicYearId;

                return new Result<ExecutiveCalendarVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<ExecutiveCalendarVM>(false);
            }
        }
    }
}
