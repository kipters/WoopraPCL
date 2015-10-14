using System;
using WoopraPCL.Services;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace WoopraPCL.Droid
{
    public class DroidWoopraCrypto : IWoopraCrypto
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

