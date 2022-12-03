using Mandegar.Models.Entities.User;

namespace Mandegar.Models.ViewModels.Roles
{
    public class PermissionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public int? ParentId { get; set; }


        #region Explicit
        public static explicit operator PermissionVM(Permission entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new PermissionVM
            {
                Id = entity.Id,
                Name = entity.Name,
                Index = entity.Index,
                ParentId = entity.ParentId
            };
        }
        #endregion
    }
}
