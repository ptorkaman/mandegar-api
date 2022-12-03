using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Staffs;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class AssignPositionService : IAssignPositionService
    {
        private readonly IUow _uow;
        private readonly IPositionService _positionService;
        public AssignPositionService(IUow uow, IPositionService positionService)
        {
            _positionService = positionService;
            _uow = uow;
        }

        public async Task<Result<bool>> Add(AssignPositionVM model)
        {
            try
            {
                #region Validation
                if (model.Positions.Count == 0)
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                foreach (var item in model.Positions.ToArray())
                {
                    model.PositionId = item;
                    var isExist = await _uow.GetRepository<AssignPosition>().Get(c => c.PositionId == model.PositionId && c.StaffId == model.StaffId).AnyAsync();
                    if (!isExist)
                    {
                        AssignPosition assignPosition = new AssignPosition()
                        {
                            PositionId = model.PositionId,
                            StaffId = model.StaffId
                        };
                        await _uow.GetRepository<AssignPosition>().AddAsync(assignPosition);
                    }
                }

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

                var model = await _uow.GetRepository<AssignPosition>().Get(x => x.StaffId == id).ToListAsync();

                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }
                foreach (var item in model)
                {
                    _uow.GetRepository<AssignPosition>().Delete(item);

                }

                //_uow.GetRepository<AssignPosition>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<AssignPositionVM>>> GetAll()
        {

            var data = await _uow.GetRepository<AssignPosition>()
               .Get()
               .AsNoTracking()
               .Select(c => new AssignPositionVM
               {
                   PositionId = c.PositionId,
                   StaffId = c.StaffId,
                   PositionName = c.Position.Name,
                   StuffName = c.Staff.Name + " " + c.Staff.Family
               })
               .ToListAsync();

            return new Result<List<AssignPositionVM>>(data);
        }

        public async Task<Result<Root>> GetAllPositions()
        {
            try
            {
                Result<List<Position>> Positions = await _positionService.GetAllPositions();
                if (!Positions.Success)
                    return new Result<Root>(false);

                Root root = new Root();
                foreach (Position item in Positions.Data)
                {
                    if (item.ParentId == null)
                        root.data.Add(new TreeNode
                        {
                            data = item.Id,
                            expandedIcon = "pi pi-user",
                            collapsedIcon = "pi pi-user",
                            label = item.Name,
                            children = item.Positions != null ? getChild(item.Positions.ToList()) : null
                        });
                }

                return new Result<Root>(root);
            }
            catch (Exception)
            {
                return new Result<Root>(false);
            }
        }
        private List<TreeNode> getChild(List<Position> positions)
        {

            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var item in positions)
            {
                nodes.Add(new TreeNode
                {
                    data = item.Id,
                    expandedIcon = "pi pi-key",
                    collapsedIcon = "pi pi-key",
                    label = item.Name,
                    children = null
                });
            }

            return nodes;
        }
        public async Task<Result<List<AssignPositionVM>>> GetById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<List<AssignPositionVM>>(Messages.NotExistsData);
                }
                var model = await _uow.GetRepository<AssignPosition>().GetWithInclude(x => x.Position).Where(x => x.StaffId == id).ToListAsync();
                if (model == null)
                    return new Result<List<AssignPositionVM>>(Messages.NotExistsData);

                List<AssignPositionVM> list = new List<AssignPositionVM>();
                foreach (var item in model)
                {
                    AssignPositionVM modelVm = new AssignPositionVM();
                    modelVm.PositionId = item.PositionId;
                    modelVm.StaffId = item.StaffId;

                    list.Add(modelVm);
                }

                return new Result<List<AssignPositionVM>>(list);
            }
            catch (Exception ex)
            {
                return new Result<List<AssignPositionVM>>(false);
            }
        }

        public async Task<Result<bool>> Update(AssignPositionVM modelVm)
        {
            try
            {
                #region Validation
                if (modelVm.Positions.Count == 0)
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }
                #endregion
                var allPosition = _uow.GetRepository<AssignPosition>().Get(x => x.StaffId == modelVm.StaffId).ToList();
                foreach (var item in allPosition)
                {
                    _uow.GetRepository<AssignPosition>().DeleteRange(allPosition);
                    _uow.SaveChanges();
                }
                foreach (var position in modelVm.Positions.ToArray())
                {
                    modelVm.PositionId = position;
                    var isExist = _uow.GetRepository<AssignPosition>().Get(c => c.PositionId == modelVm.PositionId && c.StaffId == modelVm.StaffId).Any();
                    if (!isExist)
                    {
                        AssignPosition assignPosition = new AssignPosition()
                        {
                            PositionId = modelVm.PositionId,
                            StaffId = modelVm.StaffId
                        };
                        await _uow.GetRepository<AssignPosition>().AddAsync(assignPosition);
                    }
                }

                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }
    }
}
