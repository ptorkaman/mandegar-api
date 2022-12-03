using Mandegar.Models.Entities.Personeli;

namespace Mandegar.Models.ViewModels.StaffAddresses
{
    public class StaffAddressVM
    {


        public StaffAddressVM()
        {

        }

        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Phone { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address { get; set; }
        public int? AddressTypeId { get; set; }
        public string OtherWorkName { get; set; }
        public string OtherWorkPhone { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }


        #region explicit

        public static explicit operator StaffAddress(StaffAddressVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new StaffAddress
            {
                Address = vm.Address,
                AddressTypeId = vm.AddressTypeId,
                Description = vm.Description,
                Email = vm.Email,
                Phone = vm.Phone,
                Mobile1 = vm.Mobile1,
                Mobile2 = vm.Mobile2,
                OtherWorkName = vm.OtherWorkName,
                OtherWorkPhone = vm.OtherWorkPhone,
                StaffId = vm.StaffId
            };
        }

        public static explicit operator StaffAddressVM(StaffAddress entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new StaffAddressVM
            {
                Address = entity.Address,
                AddressTypeId = entity.AddressTypeId,
                Description = entity.Description,
                Email = entity.Email,
                Phone = entity.Phone,
                Mobile1 = entity.Mobile1,
                Mobile2 = entity.Mobile2,
                OtherWorkName = entity.OtherWorkName,
                OtherWorkPhone = entity.OtherWorkPhone,
                StaffId = entity.StaffId
            };
        }

        #endregion
    }
}
