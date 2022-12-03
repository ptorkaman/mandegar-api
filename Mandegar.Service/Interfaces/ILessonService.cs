using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ILessonService
    {
        Task<Result<bool>> Add(LessonVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(LessonVM model);

        Task<Result<LessonVM>> GetById(int id);

        Task<Result<List<LessonVM>>> GetAll();

    }
}
