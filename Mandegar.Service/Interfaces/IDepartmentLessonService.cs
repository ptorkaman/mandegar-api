using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentLessonService
    {
        Task<Result<bool>> Add(DepartmentLesson model);


        Task<Result<bool>> Delete(int id);

        Task<Result<DepartmentLessonVM>> GetById(int id);

        Task<Result<List<DepartmentLessonVM>>> GetAll();
        Task<Result<bool>> Update(DepartmentLessonVM departmentLesson);
    }
}
