using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class SecretaryEvaluation_Config : IEntityTypeConfiguration<SecretaryEvaluation>
    {
        public void Configure(EntityTypeBuilder<SecretaryEvaluation> builder)
        {
            //builder.HasKey(ur => new { ur.DepartmentMemberId, ur.DepartmentEvaluationGroupId, ur.EvaluationCourseId });
        }
    }
}