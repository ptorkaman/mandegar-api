using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStudyFieldService
    {
        Task<Result<bool>> Add(StudyFieldVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(StudyFieldVM model);

        Task<Result<StudyFieldVM>> GetById(int id);

        Task<Result<List<StudyFieldVM>>> GetAll();

    }
}
