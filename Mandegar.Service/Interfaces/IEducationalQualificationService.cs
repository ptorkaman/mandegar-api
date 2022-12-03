using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.EducationalQualifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IEducationalQualificationService
    {
        Task<Result<EducationalQualificationVM>> Get(int id);
        Task<Result<bool>> Update(EducationalQualification model);
        Task<Result<bool>> Add(EducationalQualification model);
        Task<Result<bool>> Delete(int id);
        Task<Result<List<EducationalQualificationVM>>> GetAll(int staffId);
    }
}
