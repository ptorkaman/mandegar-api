using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffResumes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IResumeService
    {
        Task<Result<ResumeVM>> Get(int id);
        Task<Result<bool>> Update(Resume model);
        Task<Result<bool>> Add(Resume model);
        Task<Result<bool>> Delete(int id);
        Task<Result<List<ResumeVM>>> GetAll(int staffId);
    }
}
