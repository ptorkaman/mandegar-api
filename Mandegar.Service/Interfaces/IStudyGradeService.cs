using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStudyGradeService
    {
        Task<Result<bool>> Add(StudyGradeVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(StudyGradeVM model);

        Task<Result<StudyGradeVM>> GetById(int id);

        Task<Result<List<StudyGradeVM>>> GetAll();

    }
}
