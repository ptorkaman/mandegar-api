using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ILogExceptionService
    {
        Task Log(Exception exception);
    }
}
