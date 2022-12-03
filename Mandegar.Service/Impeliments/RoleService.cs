using Mandegar.Models.Entities.User;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Account;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Roles;
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
    public class RoleService : IRoleService
    {
        private readonly IUow _uow;
        private readonly IPermissionService _permissionService;
        public RoleService(IUow uow, IPermissionService permissionService)
        {
            _uow = uow;
            _permissionService = permissionService;
        }

        public async Task<Result<bool>> Add(Role model)
        {
            try
            {
                #region Validation
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }

                if (model.RolePermissions == null || model.RolePermissions.Count() == 0)
                {
                    return new Result<bool>(Messages.PermissionRequired);

                }
                #endregion

                #region Permissions
                foreach (var item in model.RolePermissions.ToArray())
                {
                    item.Role = model;
                }
                #endregion

                var isExist = await _uow.GetRepository<Role>().Get(c => c.Name == model.Name).AnyAsync();
                if (isExist)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }

                model.CreatedById = ClaimHelper.GetUserId();

                await _uow.GetRepository<Role>().AddAsync(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        private List<TreeNode> getChild(List<Permission> permissions)
        {

            List<TreeNode> nodes = new List<TreeNode>();
            foreach (var item in permissions)
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

        public async Task<Result<Root>> GetAllPermissionsAsync()
        {
            try
            {
                Result<List<Permission>> permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<Root>(false);


                Root root = new Root();
                foreach (Permission item in permissions.Data)
                {
                    if (item.ParentId == null)
                        root.data.Add(new TreeNode
                        {
                            data = item.Id,
                            expandedIcon = "pi pi-user",
                            collapsedIcon = "pi pi-user",
                            label = item.Name,
                            children = item.Permissions != null ? getChild(item.Permissions.ToList()) : null
                        });
                }

                return new Result<Root>(root);
            }
            catch (Exception)
            {
                return new Result<Root>(false);
            }
        }

        public async Task<Result<CreateRoleVM>> CreatePreparation()
        {
            try
            {
                var permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<CreateRoleVM>(false);


                var data = new CreateRoleVM { Permissions = permissions.Data.Select(c => (PermissionVM)c).ToList() };

                return new Result<CreateRoleVM>(data);
            }
            catch (Exception)
            {
                return new Result<CreateRoleVM>(false);
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

                var role = await _uow.GetRepository<Role>().Get(id);

                if (role == null)
                {
                    return new Result<bool>(Messages.NotExistsData);

                }

                role.IsDeleted = true;

                _uow.GetRepository<Role>().Update(role);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
        }

        public async Task<Result<List<Role>>> GetAll()
        {
            var data = await _uow.GetRepository<Role>().Get(c => c.IsActive && c.ShowInList).OrderByDescending(c => c.CreatedOn).AsNoTracking().ToListAsync();

            return new Result<List<Role>>(data);
        }

        public async Task<Result<bool>> Update(Role model)
        {
            try
            {
                #region Validation

                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }

                if (model.RolePermissions == null || model.RolePermissions.Count() == 0)
                {
                    return new Result<bool>(Messages.PermissionRequired);
                }

                #endregion

                #region Roles

                foreach (var item in model.RolePermissions.ToArray())
                {
                    item.Role = model;
                }

                #endregion

                var isExists = await _uow.GetRepository<Role>().Get(c => c.Name == model.Name && c.Id != model.Id).AnyAsync();
                if (isExists)
                {
                    return new Result<bool>(Messages.DuplicateName);
                }

                var role = await _uow.GetRepository<Role>().GetWithInclude(c => c.RolePermissions).Where(c => c.Id == model.Id).FirstOrDefaultAsync();
                if (role == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                role.ModifiedOn = DateTime.Now;
                role.Name = model.Name;
                role.RolePermissions = model.RolePermissions;

                _uow.GetRepository<Role>().Update(role);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<CreateRoleVM>> UpdatePreparation(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<CreateRoleVM>(Messages.NotExistsData);
                }

                var model = new CreateRoleVM();
                var role = await _uow.GetRepository<Role>().GetWithInclude(c => c.RolePermissions).Where(c => c.Id == id).FirstOrDefaultAsync();

                if (role == null)
                    return new Result<CreateRoleVM>(Messages.NotExistsData);

                var permissions = await _permissionService.GetAllPermissions();
                if (!permissions.Success)
                    return new Result<CreateRoleVM>(false);

                model.Role = role;
                model.Permissions = permissions.Data.Select(c => (PermissionVM)c).ToList();

                foreach (Permission item in permissions.Data)
                {
                    if (item.ParentId == null)
                        model.Root.data.Add(new TreeNode
                        {
                            data = item.Id,
                            expandedIcon = "pi pi-user",
                            collapsedIcon = "pi pi-user",
                            label = item.Name,
                            children = item.Permissions != null ? getChild(item.Permissions.ToList()) : null
                        });
                }

                return new Result<CreateRoleVM>(model);

            }
            catch (Exception)
            {
                return new Result<CreateRoleVM>(false);
            }
        }
    }
}
