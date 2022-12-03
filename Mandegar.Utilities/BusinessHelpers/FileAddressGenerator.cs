using Mandegar.Utilities.Enums;

namespace Mandegar.Utilities.BusinessHelpers
{
    public static class FileAddressGenerator
    {
        public static string ThumbnailImage(string fileName)
        {
            return $"/Uploads/{FileType.Images}/{DefaultPath.Thumbnails}/{fileName}";
        }
        public static string ThumbnailImage()
        {
            return $"{ AppsettingsGetter.Get("ApiUrls:AdminApi")}/Uploads/{FileType.Images}/{DefaultPath.Thumbnails}";
        }
        public static string AdminUserAvatar(string fileName)
        {
            return $"Uploads/{FileType.Images}/{DefaultPath.UserAvatar}/{fileName}";
        }
        public static string AdminUserAvatar()
        {
            return $"{ AppsettingsGetter.Get("ApiUrls:AdminApi")}/Uploads/{FileType.Images}/{DefaultPath.UserAvatar}";
        }
        public static string DefaultAvatar()
        {
            return $"{AppsettingsGetter.Get("ApiUrls:AdminApi")}/Images/UserAvatar/Default.jpg";
        }

    }
}
