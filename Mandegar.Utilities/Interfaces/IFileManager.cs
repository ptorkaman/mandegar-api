using Microsoft.AspNetCore.Http;
using Mandegar.Utilities.Enums;
using System.Threading.Tasks;
using Mandegar.Utilities.Models;

namespace Mandegar.Utilities.Interfaces
{
    public interface IFileManager
    {
        Task<Result> ImageResizer(string fileName, DefaultPath imgDefaultPath, int imgWidth, Server server = Server.Localhost);
        Task<Result> UploadFile(IFormFile file, DefaultPath defaultPath, FileType uploadType, Server server = Server.Localhost);
        Task<Result> UploadFile(byte[] file, DefaultPath defaultPath, FileType uploadType, Server server = Server.Localhost);
        Task RemoveFile(string filename, DefaultPath defaultPath, FileType uploadType, Server server = Server.Localhost);
        Task<string> GeneratePath(string filename, DefaultPath defaultPath, Server server = Server.Localhost);
        Task<string> GetImageAsBase64String(string fileName, DefaultPath defaultPath, Server server = Server.Localhost);
    }
}
