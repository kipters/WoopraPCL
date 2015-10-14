using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using WoopraPCL.Services;

namespace WoopraPCL
{

    public class WoopraVisitor
    {
        public static WoopraVisitor GetAnonymousVisitor()
        {
            /*
            var anonymousCookie = settings.GetString("anonymous_cookie");
            if (anonymousCookie == null)
            {
                anonymousCookie = Guid.NewGuid().ToString("N");
                settings.SetString("anonymous_cookie", anonymousCookie);
            }
            */

            var anonymousCookie = Guid.NewGuid().ToString("N");

            return new WoopraVisitor(anonymousCookie);
        }

        public static WoopraVisitor CreateWithEmail(IWoopraCrypto crypto, string email)
        {
            var emailHash = crypto.MD5HexRapresentation(email);
            var visitor = new WoopraVisitor(emailHash);
            visitor.Properties.Add("email", email);
            return visitor;
        }

        public WoopraVisitor(string cookie)
        {
            this.Cookie = cookie;
            Properties = new Dictionary<string, string>();
        }

        public string Cookie { get; }

        public Dictionary<string, string> Properties { get; }
    }

}
