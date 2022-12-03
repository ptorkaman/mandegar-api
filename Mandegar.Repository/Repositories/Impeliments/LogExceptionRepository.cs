using Mandegar.DataAccess;
using Mandegar.Models.Entities.Log;
using Mandegar.Repository.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Mandegar.Repository.Repositories.Impeliments
{
    public class LogExceptionRepository : ILogExceptionRepository
    {
        private readonly MandegarLogDbContext _mandegarLogDbContext;

        public LogExceptionRepository(MandegarLogDbContext mandegarLogDbContext)
        {
            _mandegarLogDbContext = mandegarLogDbContext;
        }

        public async Task Log(ExceptionLog exceptionLog)
        {
            await _mandegarLogDbContext.ExceptionLogs.AddAsync(exceptionLog);
            await _mandegarLogDbContext.SaveChangesAsync();
        }
    }
}
