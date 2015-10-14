using System;
using WoopraPCL.Services;
using Foundation;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WoopraPCL.iOS
{
    public class TouchWoopraCrypto : IWoopraCrypto
    {
        public string MD5HexRapresentation(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(bytes);
            return string.Join("", hash.Select(x => x.ToString("x2")));
        }
    }
}
