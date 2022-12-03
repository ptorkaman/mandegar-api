using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ILessonTypeService
    {
        Task<Result<bool>> Add(LessonTypeVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(LessonTypeVM model);

        Task<Result<LessonTypeVM>> GetById(int id);

        Task<Result<List<LessonType>>> GetAll();

    }
}
