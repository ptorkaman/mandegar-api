using Mandegar.Models.Entities.BaseInfo;
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
    public class DepartmentMemberService : IDepartmentMemberService
    {
        private readonly IUow _uow;
        public DepartmentMemberService(IUow uow, IPermissionService permissionService)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Add(DepartmentMemberVM modelVm)
        {
            try
            {
                #region Validation
                if (modelVm.DepartmentId==0)
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }               
                #endregion            
                var isExist = await _uow.GetRepository<DepartmentMember>().Get(c => c.DepartmentId == modelVm.DepartmentId && c.PositionId==modelVm.PositionId && c.StaffId==modelVm.StaffId && !c.IsDeleted).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }
                DepartmentMember model = new DepartmentMember()
                {
                    CreatedById = ClaimHelper.GetUserId(),
                    DepartmentId = modelVm.DepartmentId,
                    PositionId = modelVm.PositionId,
                    StaffId = modelVm.StaffId
                };
                await _uow.GetRepository<DepartmentMember>().AddAsync(model);
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
                //var assignTask = _uow.GetRepository<Tasks>().GetWithInclude(c=>c.TaskGroupId).Where(x=>x.TaskGroupId == id).FirstOrDefault();
                //if (assignTask != null)
                //{
                //    return new Result<bool>(Messages.AssigntaskGroupTotask);
                //}
                var task = await _uow.GetRepository<DepartmentMember>().Get(id);

                if (task == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                task.IsDeleted = true;

                _uow.GetRepository<DepartmentMember>().Update(task);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<DepartmentMemberVM>>> GetAll()
        {
            var data = await _uow.GetRepository<DepartmentMember>()
                          .Get(c => c.IsActive && !c.IsDeleted)
                          .OrderByDescending(c => c.CreatedOn)
                          .AsNoTracking()
                          .Select(c => new DepartmentMemberVM
                          {
                              Id = c.Id,
                              DepartmentId = c.DepartmentId,
                              DepartmentName =c.Department.ParentId!=null? c.Department.Name + " (" + c.Department.Parent.Name + ")": c.Department.Name,
                              PositionId = c.PositionId,
                              PositionName = c.Position.Name,
                              StaffId = c.StaffId,
                              StaffName = c.Staff.Name +" "+c.Staff.Family
                          })
                          .ToListAsync();

            return new Result<List<DepartmentMemberVM>>(data);

           
        }

        public async Task<Result<bool>> Update(DepartmentMemberVM model)
        {
            try
            {
                #region Validation
                if (model.DepartmentId==0)
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var isExists = await _uow.GetRepository<DepartmentMember>().Get(c => c.DepartmentId == model.DepartmentId && c.Id != model.Id && c.StaffId==model.StaffId && c.PositionId==model.PositionId && !c.IsDeleted).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateData);
                }
                var task = await _uow.GetRepository<DepartmentMember>().Get(model.Id);
                if (task == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                task.ModifiedOn = DateTime.Now;
                task.DepartmentId = model.DepartmentId;
                task.PositionId = model.PositionId;
                task.StaffId = model.StaffId;
                _uow.GetRepository<DepartmentMember>().Update(task);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<DepartmentMemberVM>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<DepartmentMemberVM>(Messages.NotExistsData);
                }
                var model = new DepartmentMemberVM();
                var task = await _uow.GetRepository<DepartmentMember>().Get(id);
                if (task == null)
                    return new Result<DepartmentMemberVM>(Messages.NotExistsData);
                
                DepartmentMemberVM modelVm=new DepartmentMemberVM();
                modelVm.Id = task.Id;
                modelVm.DepartmentId = task.DepartmentId;
                modelVm.PositionId = task.PositionId;
                modelVm.StaffId = task.StaffId;

                return new Result<DepartmentMemberVM>(modelVm);
            }
            catch (Exception)
            {
                return new Result<DepartmentMemberVM>(false);
            }
        }
    }
}
