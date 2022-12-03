using Mandegar.Utilities.Enums;
using System.Threading.Tasks;

namespace Mandegar.Utilities.Interfaces
{
    public interface IHttpHelper
    {
        Task<T> Post<T>(string api, object parms, ApiProjects apiProjects = ApiProjects.Admin);
        Task<T> Get<T>(string api, object parms, ApiProjects apiProjects = ApiProjects.Admin);

    }
}
