using Mandegar.Models.Entities.User;
using Mandegar.Models.HelperModels;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class PermissionService : IPermissionService
    {
        private readonly IUow _uow;
        public PermissionService(IUow uow)
        {
            _uow = uow;
        }


        public async Task<Result<List<Permission>>> GetAllPermissions()
        {
            try
            {
                var data = await _uow.GetRepository<Permission>().Get(c => c.ShowInList && c.IsActive).ToListAsync();
                return new Result<List<Permission>>(data);
            }
            catch (Exception)
            {
                return new Result<List<Permission>>(false);
            }
        }
    }
}
