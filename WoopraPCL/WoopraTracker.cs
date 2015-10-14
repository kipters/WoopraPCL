using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace WoopraPCL
{
    public class WoopraTracker
    {
        private const string EventEndpoint = "https://www.woopra.com/track/ce/";
        private readonly string _platformString;
        private readonly string _userAgent;
        public WoopraTracker(WoopraVisitor visitor, string deviceModel, string osVersionString, string appName, string platformString)
        {
            _platformString = platformString;
            IdleTimeout = TimeSpan.FromSeconds(30);
            Visitor = visitor;
            Properties = new Dictionary<string, string>
            {
                { "device",deviceModel },
                { "os",osVersionString },
                { "browser",appName }
            };
            _userAgent = $"SampleApp/1.0 ({osVersionString})";
        }

        public string Domain { get; set; }

        public WoopraVisitor Visitor { get; }

        public TimeSpan IdleTimeout { get; set; }

        public bool PingEnabled { get; set; }

        public string Referer { get; set; }

        public Dictionary<string, string> Properties { get; }

        public void TrackEvent(WoopraEvent woopraEvent)
        {
            if (string.IsNullOrWhiteSpace(Domain))
                throw new NullReferenceException("WoopraTracker.Domain property must be set before any call to WoopraTracker.TrackEvent");

            if (Visitor == null)
                throw new NullReferenceException("WoopraTracker.Visitor property must be set before any call to WoopraTracker.TrackEvent");

            var timeoutMs = IdleTimeout.TotalMilliseconds;
            var builder = new StringBuilder($"{EventEndpoint}?app={_platformString}&host={Domain}&cookie={Visitor.Cookie}&response=json&timeout={timeoutMs}");
            if (!string.IsNullOrWhiteSpace(Referer))
                builder.Append($"&referer={Referer}");

            AppendParameters(builder, Properties, "ce_");
            AppendParameters(builder, Visitor.Properties, "cv_");

            foreach (var prop in woopraEvent.Properties)
            {
                var key = prop.Key;
                if (key.StartsWith("~"))
                    key = key.Substring(1);
                else
                    key = $"ce_{key}";
                key = Uri.EscapeUriString(key);
                var value = Uri.EscapeUriString(prop.Value);
                string frag = $"&{key}={value}";
                builder.Append(frag);
            }

            var uri = builder.ToString();
            var request = HttpWebRequest.CreateHttp(uri);
            request.BeginGetResponse(ar => request.EndGetResponse(ar), null);
        }

        private static void AppendParameters(StringBuilder builder, IDictionary<string, string> dict, string prefix)
        {
            foreach (var prop in dict)
            {
                var key = Uri.EscapeUriString(prop.Key);
                var value = Uri.EscapeUriString(prop.Value);
                var frag = $"&{prefix}{key}={value}";
                builder.Append(frag);
            }
        }

        public void TrackEvent(string eventName)
        {
            TrackEvent(new WoopraEvent(eventName));
        }
    }
}

