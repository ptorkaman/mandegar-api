using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentLesson_Config : IEntityTypeConfiguration<DepartmentLesson>
    {
        public void Configure(EntityTypeBuilder<DepartmentLesson> builder)
        {
            //builder.HasKey(ur => new { ur.LessonId, ur.DepartmentId });
        }
    }
}