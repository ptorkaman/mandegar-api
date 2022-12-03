using Mandegar.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Mandegar.Utilities.BusinessHelpers
{
    public static class Security
    {
        public static string Encrypt(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return "";
            byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("MaliSaltValue");

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Text);

            PasswordDeriveBytes password = new PasswordDeriveBytes("MaliPassPhrase", saltValueBytes, "SHA1", 2);

            byte[] keyBytes = password.GetBytes(256 / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();

            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            //correct cipherText for getting into url as queryString
            cipherText = cipherText.Replace("+", "-1/=/2-");


            return cipherText;
        }
        public static string Decrypt(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return "##-1";
            //correct cipherText's charectars
            Text = Text.Replace("-1/=/2-", "+");

            byte[] initVectorBytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
            byte[] saltValueBytes = Encoding.ASCII.GetBytes("MaliSaltValue");
            byte[] cipherTextBytes = null;
            try
            {
                cipherTextBytes = Convert.FromBase64String(Text);
            }
            catch (Exception)
            {
                return "##-1";
            }
            PasswordDeriveBytes password = new PasswordDeriveBytes("MaliPassPhrase", saltValueBytes, "SHA1", 2);
            byte[] keyBytes = password.GetBytes(256 / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = 0;
            try
            {
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            }
            catch (Exception)
            {
                return "##-1";
            }
            memoryStream.Close();
            cryptoStream.Close();
            string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            return plainText;

        }
        public static bool HasAccessToNav(List<Claim> UserRoles, int sectionRole, bool justSuperAdmin = false)
        {
            if (UserRoles == null && UserRoles.Count() == 0)
                return false;

            bool hasPermission = false;

            foreach (var item in UserRoles)
            {

                var permissions = item.Value.Split("|").ToList();
                if (permissions != null && permissions.Count() > 0)
                {
                    var pId = Convert.ToInt32(permissions[0]);
                    bool isActive = Convert.ToBoolean(permissions[1]);
                    if (
                        (pId == sectionRole && isActive == true && justSuperAdmin == false) ||
                         //(pId == (int)Enums.AdminAuthorize.Admin && justSuperAdmin == false) ||
                         pId == (int)AdminAuthorize.SuperAdmin)
                    {
                        hasPermission = true;
                        break;
                    };
                }
            }

            return hasPermission;
        }
    }
}
