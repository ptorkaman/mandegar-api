using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Services.Attachments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace Mandegar.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AttachmentController : ApiBaseController
    {
        private readonly IFileStorage _fileStorage;

        /// <summary>
        /// سازنده
        /// </summary>
        /// <param name="fileStorage"></param>
        public AttachmentController(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        /// <summary>
        /// بارگذاری یک فایل
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("FileUpload")]
        public Result<object> FileUpload(IFormFile file)
        {
            byte[] data = new byte[file.Length];

            using (Stream stream = file.OpenReadStream())
            {
                stream.Read(data);
            }

            var result = new
            {
                Id = _fileStorage.Add(file.FileName, data),
                Name = file.FileName,
                Size = file.Length / 1024
            };

            return new Result<object>(result);
        }

        /// <summary>
        /// بارگذاری چند فایل
        /// </summary>
        /// <returns></returns>
        [HttpPost("UploadMultiple")]
        public Result<List<object>> UploadMultiple()
        {
            IFormFileCollection files = Request.Form.Files;

            var result = new List<object>();
            foreach (var item in files)
            {
                byte[] data = new byte[item.Length];

                using (Stream stream = item.OpenReadStream())
                {
                    stream.Read(data);
                }

                result.Add(new
                {
                    Id = _fileStorage.Add(item.FileName, data),
                    Name = item.FileName,
                    Size = item.Length / 1024
                });
            }

            return new Result<List<object>>(result);
        }

    }
}
