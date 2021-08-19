using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Models
{
 
       public class md5
    {

       
        public  string ToMD5(string str)
        {

            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(String.Format("{0:x2}", b));

            }
            return sbHash.ToString();

        }




        public  string Encrypt(string text, string key)
        {
            var data = Encoding.UTF8.GetBytes(text);

            using (var md5 = new MD5CryptoServiceProvider())
            {
                var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                using (var tripDes = new TripleDESCryptoServiceProvider { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    var transform = tripDes.CreateEncryptor();
                    var results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public string Decrypt(string cipher, string key)
        {

            try
            {
                var data = Convert.FromBase64String(cipher);
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(key));

                    using (var tripDes = new TripleDESCryptoServiceProvider()
                    {
                        Key = keys,
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    })
                    {
                        var transform = tripDes.CreateDecryptor();
                        var results = transform.TransformFinalBlock(data, 0, data.Length);
                        return Encoding.UTF8.GetString(results);

                    }
                }

            }
            catch (Exception ex)
            {
                return null;

            }
         
        }
    }





}
