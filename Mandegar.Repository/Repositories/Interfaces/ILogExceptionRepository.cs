using Mandegar.Models.Entities.Log;
using System.Threading.Tasks;

namespace Mandegar.Repository.Repositories.Interfaces
{
    public interface ILogExceptionRepository
    {
        Task Log(ExceptionLog exceptionLog);
    }
}
