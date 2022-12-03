using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IAcademicYearService
    {
        Task<Result<bool>> Add(AcademicYearVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(AcademicYearVM model);

        Task<Result<AcademicYearVM>> GetById(int id);

        Task<Result<List<AcademicYear>>> GetAll();

    }
}
