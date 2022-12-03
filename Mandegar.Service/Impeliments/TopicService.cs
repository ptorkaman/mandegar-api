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
    public class TopicService : ITopicService
    {
        private readonly IUow _uow;
        public TopicService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(TopicVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                var isExist = await _uow.GetRepository<Topic>().Get(c => c.Name == modelVm.Name && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                Topic model = new Topic()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    Name = modelVm.Name,
                    LessonId = modelVm.LessonId,
                    TopicCode = modelVm.TopicCode
                };
                await _uow.GetRepository<Topic>().AddAsync(model);
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
                var model = await _uow.GetRepository<Topic>().Get(id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.IsDeleted = true;
                _uow.GetRepository<Topic>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<List<TopicVM>>> GetAll()
        {
            var data = await _uow.GetRepository<Topic>()
                          .Get(c => c.IsActive && !c.IsDeleted)
                          .OrderByDescending(c => c.CreatedOn)
                          .AsNoTracking()
                          .Select(c => new TopicVM
                          {
                              Id = c.Id,
                              Name = c.Name,
                              LessonId = c.LessonId,
                              TopicCode = c.TopicCode,
                              LessonName=c.Lesson.Name
                          })
                          .ToListAsync();

            return new Result<List<TopicVM>>(data);           
        }

        public async Task<Result<bool>> Update(TopicVM modelVm)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(modelVm.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
               
                var isExists = await _uow.GetRepository<Topic>().Get(c => c.Name == modelVm.Name && c.Id != modelVm.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                #endregion
                var model = await _uow.GetRepository<Topic>().Get(modelVm.Id);
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                model.ModifiedOn = DateTime.Now;
                model.ModifiedById = ClaimHelper.GetUserId();
                model.Name = modelVm.Name;
                model.LessonId = modelVm.LessonId;
                model.TopicCode = modelVm.TopicCode;
                _uow.GetRepository<Topic>().Update(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<TopicVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<TopicVM>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<Topic>().Get(id);
                if (model == null)
                    return new Result<TopicVM>(Messages.NotExistsData);

                TopicVM modelVm=new TopicVM();
                modelVm.Id = model.Id;
                modelVm.Name = model.Name;
                modelVm.LessonId = model.LessonId;
                modelVm.TopicCode = model.TopicCode;
                return new Result<TopicVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<TopicVM>(false);
            }
        }
    }
}
