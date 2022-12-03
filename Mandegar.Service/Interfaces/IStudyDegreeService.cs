using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStudyDegreeService
    {
        Task<Result<bool>> Add(StudyDegreeVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(StudyDegreeVM model);

        Task<Result<StudyDegreeVM>> GetById(int id);

        Task<Result<List<StudyDegree>>> GetAll();

    }
}
