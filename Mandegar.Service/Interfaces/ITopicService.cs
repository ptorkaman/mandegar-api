using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ITopicService
    {
        Task<Result<bool>> Add(TopicVM model);

        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(TopicVM model);

        Task<Result<TopicVM>> GetById(int id);

        Task<Result<List<TopicVM>>> GetAll();

    }
}
