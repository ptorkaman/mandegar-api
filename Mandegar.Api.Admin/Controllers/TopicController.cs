using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.ActionFilters;
using Mandegar.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// پایه تحصیلی 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TopicController : ApiBaseController
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        /// <summary>
        /// حذف پایه تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.TopicDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _topicService.Delete(id);
        }

       

        /// <summary>
        /// افزودن پایه تحصیلی جدید
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] TopicVM topic)
        {
            return await _topicService.Add(topic);
        }

        /// <summary>
        /// آماده سازی ویرایش پایه تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.TopicEdit)]
        public async Task<Result<TopicVM>> GetById([FromBody] int id)
        {
            var result = await _topicService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی پایه تحصیلی
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.TopicEdit)]
        public async Task<Result<bool>> Update([FromBody] TopicVM topic)
        {
            var result = await _topicService.Update(topic);
            return result;
        }

        /// <summary>
        /// لیست پایه تحصیلی ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.TopicManagement)]
        public async Task<Result<List<TopicVM>>> GetAll()
        {
            return await _topicService.GetAll();
        }
    }
}
