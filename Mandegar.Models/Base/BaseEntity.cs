using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.Base
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {
            CreatedOn = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }

        [Key]
        public T Id { get; set; }
        public DateTime CreatedOn { get; set; }


        [Display(Name = "وضعیت")]
        [DisplayName("وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "حذف")]
        [DisplayName("حذف")]
        public bool IsDeleted { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
