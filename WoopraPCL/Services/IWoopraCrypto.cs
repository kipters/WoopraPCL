using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace WoopraPCL.Services
{

    public interface IWoopraCrypto
    {
        string MD5HexRapresentation(string data);
    }
    
}
