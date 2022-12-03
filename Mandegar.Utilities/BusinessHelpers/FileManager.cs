using FluentFTP;
using Mandegar.Utilities.Enums;
using Mandegar.Utilities.Interfaces;
using Mandegar.Utilities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mandegar.Utilities.BusinessHelpers
{
    public class FileManager : IFileManager
    {

        #region  Fields 

        private const string ForbiddenUpload = "js jsp jsb mhtml mht html xhtml xht php php2 phtml php3 php4 php5 phps shtml jhtml pl sh py cgi exe application gadget hta cpl msc jar vb jse ws wsf wsc wsh ps1 ps2 psc1 psc2 msh msh1 msh2 inf reg scf msp scr dll msi vbs bat com pif cmd vxd cpl htpasswd htaccess asp aspx asax asmx cs config ts tsx";
        private const string RootUploadPath = "Uploads";
        private const int MaxSizeFileUpload = 1000000;
        private IHostingEnvironment _he;
        private IConfiguration _configuration;
        #endregion

        public FileManager(IHostingEnvironment he, IConfiguration configuration)
        {
            _he = he;
            _configuration = configuration;
        }

        #region Helper Methods
        private void CreateDirectory(string path, Server server = Server.Localhost)
        {
            if (server == Server.Localhost)
            {
                if (!Directory.Exists(Path.Combine(_he.WebRootPath, path)))
                    Directory.CreateDirectory(Path.Combine(_he.WebRootPath, path));
            }

        }
        private string RootDirectory(Server server = Server.Localhost)
        {
            if (server == Server.Localhost)
            {
                return Path.Combine(_he.WebRootPath, RootUploadPath);
            }
            else
            {
                var ftp = GetFtpConfig();
                return ftp.RootFolder;
            }
        }
        private string ImagesRootDirectory(Server server = Server.Localhost)
        {
            if (server == Server.Localhost)
            {
                CreateDirectory(Path.Combine(RootDirectory(), "Images"));

                return Path.Combine(RootDirectory(), "Images");
            }
            else
            {
                return "Images";
            }
        }
        private string FilesRootDirectory(Server server = Server.Localhost)
        {
            if (server == Server.Localhost)
            {

                CreateDirectory(Path.Combine(RootDirectory(), "Files"));

                return Path.Combine(RootDirectory(), "Files");
            }
            else
            {
                return "Files";
            }
        }
        private string DocumentRootDirectory(Server server = Server.Localhost)
        {
            if (server == Server.Localhost)
            {
                CreateDirectory(Path.Combine(RootDirectory(), "Documents"));

                return Path.Combine(RootDirectory(), "Documents");
            }

            else
            {
                return "Documents";
            }
        }
        private string GetRootFileFolder(FileType FileType, Server server = Server.Localhost)
        {
            var folderForUpload = "";

            switch (FileType)
            {
                case FileType.Images:
                    folderForUpload = ImagesRootDirectory(server);
                    break;
                case FileType.Files:
                    folderForUpload = FilesRootDirectory(server);

                    break;
                case FileType.Documents:
                    folderForUpload = DocumentRootDirectory(server);

                    break;
                default:
                    folderForUpload = "";
                    break;
            }
            return folderForUpload;
        }
        private string GetThumbnailSavePath(Server server = Server.Localhost)
        {
            var savePath = "";
            savePath = Path.Combine(GetRootFileFolder(FileType.Images, server), DefaultPath.Thumbnails.ToString());
            CreateDirectory(savePath, server);
            return savePath;
        }
        private string GetMomentDateTimeString()
        {
            var now = DateTime.Now;
            return $"{now.Year}{now.Month}{now.Day}{now.Hour}{now.Minute}{now.Second}{now.Millisecond}";
        }
        private (string Url, string Server, string Port, string RootFolder, string UserName, string Password) GetFtpConfig()
        {
            var Url = _configuration["Ftp:Url"];
            var server = _configuration["Ftp:Server"];
            var port = _configuration["Ftp:Port"];
            var rootFolder = _configuration["Ftp:RootFolder"];
            var UserName = _configuration["Ftp:UserName"];
            var Password = _configuration["Ftp:Password"];

            return (Url, server, port, rootFolder, UserName, Password);
        }
        private FtpClient CreateFtp()
        {
            var ftp = GetFtpConfig();

            return new FtpClient(ftp.Server, ftp.UserName, ftp.Password);
        }
        private string GetImageExtension(byte[] byteArray)
        {
            using (MemoryStream stream = new MemoryStream(byteArray))
            using (Image image = Image.FromStream(stream))
            {
                return ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == image.RawFormat.Guid).FilenameExtension;
            }
        }
        private string GetDefaultPath(DefaultPath defaultPath)
        {
            switch (defaultPath)
            {
                case DefaultPath.DefultUserAvatar:
                    return $"Images/{DefaultPath.UserAvatar}";

                case DefaultPath.UserAvatar:
                    return $"Uploads/Images/{DefaultPath.UserAvatar}";

                case DefaultPath.Thumbnails:
                    return $"Uploads/Images/{DefaultPath.Thumbnails}";

                case DefaultPath.AttachmentFile:
                    return $"Uploads/Images/{DefaultPath.AttachmentFile}";

                case DefaultPath.PersonnelImages:
                    return $"Uploads/Images/{DefaultPath.PersonnelImages}";
                default:
                    return "";
            }
        }
        #endregion

        public async Task<Result> ImageResizer(string fileName, DefaultPath imgDefaultPath, int imgWidth, Server server = Server.Localhost)
        {
            var res = new Result();

            #region Fields
            const long quality = 100L;
            var folderForUpload = GetRootFileFolder(FileType.Images, server);
            var imageAddress = "";
            var savePath = Path.Combine(GetThumbnailSavePath(server), fileName);
            if (server == Server.Localhost)
            {
                imageAddress = Path.Combine(folderForUpload, imgDefaultPath.ToString(), fileName);
            }
            else
            {
                var tmp = Path.Combine(_he.WebRootPath, "tmp", fileName);

                CreateDirectory("tmp", Server.Localhost);

                var token = new CancellationToken();

                using var ftpClient = CreateFtp();
                await ftpClient.ConnectAsync(token);


                try
                {

                    await ftpClient.DownloadFileAsync(tmp, fileName);
                }
                catch (Exception ex)
                {

                    throw;
                }
                imageAddress = Path.Combine(tmp, fileName);

            }

            Bitmap source_Bitmap = new Bitmap(imageAddress);
            double dblWidth_origial = source_Bitmap.Width;
            double dblHeigth_origial = source_Bitmap.Height;
            double relation_heigth_width = dblHeigth_origial / dblWidth_origial;
            int new_Height = (int)(imgWidth * relation_heigth_width);
            #endregion

            try
            {
                var new_DrawArea = new Bitmap(imgWidth, new_Height);

                using (var graphic_of_DrawArea = Graphics.FromImage(new_DrawArea))
                {

                    //< setup >

                    graphic_of_DrawArea.CompositingQuality = CompositingQuality.HighSpeed;

                    graphic_of_DrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    graphic_of_DrawArea.CompositingMode = CompositingMode.SourceCopy;

                    //</ setup >



                    //< draw into placeholder >

                    //*imports the image into the drawarea

                    graphic_of_DrawArea.DrawImage(source_Bitmap, 0, 0, imgWidth, new_Height);

                    //</ draw into placeholder >



                    //--< Output as .Jpg >--

                    if (server == Server.Localhost)
                    {
                        using (var output = System.IO.File.Open(savePath, FileMode.Create))

                        {

                            //< setup jpg >

                            var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                            var encoderParameters = new EncoderParameters(1);

                            encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                            //</ setup jpg >



                            //< save Bitmap as Jpg >

                            var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                            new_DrawArea.Save(output, codec, encoderParameters);

                            //resized_Bitmap.Dispose ();

                            output.Close();

                            //</ save Bitmap as Jpg >

                        }
                    }
                    else
                    {
                        using (var output = System.IO.File.Open(savePath, FileMode.Create))

                        {

                            //< setup jpg >

                            var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                            var encoderParameters = new EncoderParameters(1);

                            encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                            //</ setup jpg >



                            //< save Bitmap as Jpg >

                            var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                            new_DrawArea.Save(output, codec, encoderParameters);

                            //resized_Bitmap.Dispose ();

                            output.Close();

                            //</ save Bitmap as Jpg >

                        }

                    }

                    //--</ Output as .Jpg >--

                    graphic_of_DrawArea.Dispose();

                }

                source_Bitmap.Dispose();

                //---------------</ Image_resize() >---------------

                source_Bitmap.Dispose();
                res.Success = true;
                res.Data = "تصویر با موفقیت ریسایز شد";
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }

        public async Task<Result> UploadFile(IFormFile file, DefaultPath defaultPath, FileType FileType, Server server = Server.Localhost)
        {
            var result = new Result();
            result.Success = false;

            #region Check Input Parameters

            if (file == null)
            {
                result.Message = "فایلی جهت آپلود وحود ندارد";
                return result;
            }
            #endregion

            try
            {
                if (file.Length > 0)
                {
                    if (file.Length <= MaxSizeFileUpload)
                    {
                        var fileExtension = Path.GetExtension(file.FileName);
                        var orginalFileName = Path.GetFileNameWithoutExtension(file.FileName);

                        bool isForbiddenUpload = ForbiddenUpload.Contains(fileExtension.Substring(1));

                        var folderForUpload = GetRootFileFolder(FileType, server);

                        if (!isForbiddenUpload)
                        {
                            var fileName = $"{orginalFileName}_{GetMomentDateTimeString()}{fileExtension}";

                            if (server == Server.Localhost)
                            {
                                CreateDirectory(Path.Combine(folderForUpload, defaultPath.ToString()));
                                using (var stream = new FileStream(Path.Combine(folderForUpload, defaultPath.ToString(), fileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(stream);
                                    result.Success = true;
                                    result.Message = "فایل با موفقیت آپلود شد";
                                    //var fileAddress = Path.Combine(folderForUpload, defaultPath.ToString(), fileName);
                                    result.Data = fileName;
                                }
                            }
                            else
                            {
                                var token = new CancellationToken();

                                using var ftpClient = CreateFtp();
                                await ftpClient.ConnectAsync(token);

                                using var ms = new MemoryStream();

                                file.CopyTo(ms);
                                var ftp = GetFtpConfig();
                                var fileNameToUplpad = string.IsNullOrWhiteSpace(ftp.RootFolder) == false ?
                                    $"/{ftp.RootFolder}/{folderForUpload}/{defaultPath}/{fileName}" :
                                    $"{folderForUpload}/{defaultPath}/{fileName}";

                                var status = await ftpClient.UploadAsync(ms, fileNameToUplpad, FtpRemoteExists.Overwrite, true);
                                result.Data = fileNameToUplpad;
                                result.Success = (status == FtpStatus.Success ? true : false);
                            }
                        }
                        else
                        {
                            result.Message = "آپلود فایل با پسوند مورد نظر ممنوع است.";
                        }
                    }
                    else
                    {
                        result.Message = "حجم فایل بیشتر از حد مجاز می باشد.";
                    }
                }
                else
                {
                    result.Message = "فایل انتخاب شده دارای اشکال است";
                }
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<Result> UploadFile(byte[] file, DefaultPath defaultPath, FileType FileType, Server server = Server.Localhost)
        {
            var result = new Result();
            result.Success = false;

            #region Check Input Parameters

            if (file == null)
            {
                result.Message = "فایلی جهت آپلود وحود ندارد";
                return result;
            }
            #endregion

            try
            {
                if (file.Length > 0)
                {
                    if (file.Length <= MaxSizeFileUpload)
                    {
                        if (FileType == FileType.Images)
                        {
                            var fileExtensions = GetImageExtension(file);
                            var fileExtension = fileExtensions.Split(';')?.FirstOrDefault()?.ToLower()?.Replace("*.", string.Empty);
                            var orginalFileName = Guid.NewGuid().ToString("N");

                            bool isForbiddenUpload = ForbiddenUpload.Contains(fileExtension);

                            var folderForUpload = GetRootFileFolder(FileType, server);

                            if (!isForbiddenUpload)
                            {
                                var fileName = $"{orginalFileName}.{fileExtension}";

                                if (server == Server.Localhost)
                                {
                                    CreateDirectory(Path.Combine(folderForUpload, defaultPath.ToString()));

                                    await File.WriteAllBytesAsync(Path.Combine(folderForUpload, defaultPath.ToString(), fileName), file);
                                    result.Success = true;
                                    result.Message = "فایل با موفقیت آپلود شد";
                                    //var fileAddress = Path.Combine(folderForUpload, defaultPath.ToString(), fileName);
                                    result.Data = fileName;
                                }
                                else
                                {
                                    var token = new CancellationToken();

                                    using var ftpClient = CreateFtp();
                                    await ftpClient.ConnectAsync(token);

                                    using var ms = new MemoryStream();

                                    //file.CopyTo(ms);
                                    var ftp = GetFtpConfig();
                                    var fileNameToUplpad = string.IsNullOrWhiteSpace(ftp.RootFolder) == false ?
                                        $"/{ftp.RootFolder}/{folderForUpload}/{defaultPath}/{fileName}" :
                                        $"{folderForUpload}/{defaultPath}/{fileName}";

                                    var status = await ftpClient.UploadAsync(ms, fileNameToUplpad, FtpRemoteExists.Overwrite, true);
                                    result.Data = fileNameToUplpad;
                                    result.Success = (status == FtpStatus.Success ? true : false);
                                }
                            }
                            else
                            {
                                result.Message = "آپلود فایل با پسوند مورد نظر ممنوع است.";
                            }
                        }

                    }
                    else
                    {
                        result.Message = "حجم فایل بیشتر از حد مجاز می باشد.";
                    }
                }
                else
                {
                    result.Message = "فایل انتخاب شده دارای اشکال است";
                }
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }

        public async Task RemoveFile(string filename, DefaultPath defaultPath, FileType FileType, Server server = Server.Localhost)
        {
            if (server == Server.Localhost)
            {
                var folderForUpload = GetRootFileFolder(FileType);
                var path = Path.Combine(folderForUpload, defaultPath.ToString(), filename);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                if (FileType == FileType.Images)
                {
                    var thumbnail = Path.Combine(folderForUpload, DefaultPath.Thumbnails.ToString(), filename);

                    if (File.Exists(thumbnail))
                    {
                        File.Delete(thumbnail);
                    }
                }
            }
            else
            {
                var token = new CancellationToken();
                using var ftpClient = CreateFtp();
                await ftpClient.ConnectAsync(token);
                await ftpClient.DeleteFileAsync(filename);
            }

        }

        public async Task<string> GeneratePath(string filename, DefaultPath defaultPath, Server server = Server.Localhost)
        {
            return await Task.Run(() =>
            {
                if (server == Server.Ftp)
                {

                    var ftp = GetFtpConfig();

                    var address = $"{ftp.Url}/{filename}";

                    return address;
                }
                else
                {
                    var domain = AppsettingsGetter.Get("ApiUrls:AdminApi");
                    var path = $"{domain}/{GetDefaultPath(defaultPath)}/{filename}";
                    return path;
                }
            });
        }

        public async Task<string> GetImageAsBase64String(string fileName, DefaultPath defaultPath, Server server = Server.Localhost)
        {
            var result = "";
            var addrss = "";

            if (defaultPath == DefaultPath.DefultUserAvatar)
            {
                addrss = Path.Combine(_he.WebRootPath, "Images/UserAvatar", fileName);
            }
            else
            {
                addrss = Path.Combine(_he.WebRootPath, ImagesRootDirectory(), defaultPath.ToString(), fileName);
            }

            if (server == Server.Localhost)
            {
                if (File.Exists(addrss))
                {
                    var file = await File.ReadAllBytesAsync(addrss);
                    if (file != null)
                    {
                        result = Convert.ToBase64String(file);
                    }
                }
            }
            else
            {

            }

            return result;
        }
    }
}
