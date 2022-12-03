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
    public class StudyDegreeService : IStudyDegreeService
    {
        private readonly IUow _uow;
        public StudyDegreeService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(StudyDegreeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<StudyDegree>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                StudyDegree model = new StudyDegree()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name=modelVm.Name
                };
                await _uow.GetRepository<StudyDegree>().AddAsync(model);
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
                //var existmodel = _uow.GetRepository<StudyField>().GetWithInclude(c => c.StudyDegree).Where(x => x.StudyDefreeId == id).FirstOrDefault();
                //if (existmodel != null)
                //{
                //    return new Result<bool>(Messages.ExistrelationItem);
                //}
                var model = await _uow.GetRepository<StudyDegree>().Get(id);

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                model.IsDeleted = true;

                _uow.GetRepository<StudyDegree>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<StudyDegree>>> GetAll()
        {
            var data = await _uow.GetRepository<StudyDegree>().Get(c => c.IsActive && !c.IsDeleted).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();

            return new Result<List<StudyDegree>>(data);
        }

        public async Task<Result<bool>> Update(StudyDegreeVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                
                var isExists = await _uow.GetRepository<StudyDegree>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id && !c.IsDeleted).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<StudyDegree>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                _uow.GetRepository<StudyDegree>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<StudyDegreeVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<StudyDegreeVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<StudyDegree>().Get(id);
                if (model == null)
                    return new Result<StudyDegreeVM>(Messages.NotExistsData);
                
                StudyDegreeVM modelVm=new StudyDegreeVM();
                modelVm.Id = model.Id;    
                modelVm.Name = model.Name;  

                return new Result<StudyDegreeVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<StudyDegreeVM>(false);
            }
        }
    }
}
