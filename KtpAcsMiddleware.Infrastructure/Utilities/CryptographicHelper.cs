using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public static class CryptographicHelper
    {
        /// <summary>
        ///     获取开太平对接sgin值(目前只有拉取工人需要)
        /// </summary>
        /// <param name="ktpTeamId">班组ID</param>
        /// <returns></returns>
        public static string GetKtpSgin(int ktpTeamId)
        {
            var value =
                $"{ConfigHelper.ProjectId}#{ktpTeamId}#{FormatHelper.GetIsoDateTimeString(DateTime.Now)}#{ConfigHelper.KtpSginToken}";
            return DesEncrypt(value, ConfigHelper.KtpSginKey);
        }

        /// <summary>
        ///     DES加密算法:sKey为8位
        /// </summary>
        /// <param name="value">需要加密的字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string DesEncrypt(string value, string sKey)
        {
            var ret = new StringBuilder();
            using (var des = new DESCryptoServiceProvider())
            {
                var inputByteArray = Encoding.UTF8.GetBytes(value);
                des.Key = Encoding.UTF8.GetBytes(sKey);
                des.IV = Encoding.UTF8.GetBytes(sKey);
                des.Mode = CipherMode.CBC; //兼任其他语言的des
                //des.BlockSize = 64;
                //des.KeySize = 64;
                des.Padding = PaddingMode.PKCS7;
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();

                        foreach (var b in ms.ToArray())
                        {
                            ret.AppendFormat("{0:X2}", b);
                        }
                        return ret.ToString();
                    }
                }
            }
        }

        /// <summary>
        ///     DES解密算法:sKey为8位或16位
        /// </summary>
        /// <param name="value">需要解密的字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public static string DesDecrypt(string value, string sKey)
        {
            try
            {
                var str = "";
                using (var des = new DESCryptoServiceProvider())
                {
                    var inputByteArray = new byte[value.Length / 2];
                    for (var x = 0; x < value.Length / 2; x++)
                    {
                        var i = (Convert.ToInt32(value.Substring(x * 2, 2), 16));
                        inputByteArray[x] = (byte) i;
                    }
                    des.Key = Encoding.UTF8.GetBytes(sKey);
                    des.IV = Encoding.UTF8.GetBytes(sKey);
                    des.Mode = CipherMode.CBC; //兼任其他语言的des
                    des.Padding = PaddingMode.PKCS7;
                    //des.BlockSize = 64;
                    //des.KeySize = 64;
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(inputByteArray, 0, inputByteArray.Length);
                            cs.FlushFinalBlock();

                            str = Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                }
                return str;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     32位MD5
        /// </summary>
        /// <returns></returns>
        public static string Md5Hash(string value)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string Hash(string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            var sourceBytes = Encoding.UTF8.GetBytes(source);

            var sha1 = SHA1.Create();

            var hash = sha1.ComputeHash(sourceBytes);

            return Convert.ToBase64String(hash);
        }
    }
}