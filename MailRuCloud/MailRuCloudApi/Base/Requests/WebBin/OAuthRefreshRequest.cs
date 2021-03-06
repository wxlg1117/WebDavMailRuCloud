﻿using System.Net;
using System.Text;

namespace YaR.MailRuCloud.Api.Base.Requests.WebBin
{
    class OAuthRefreshRequest : BaseRequestJson<OAuthRefreshRequest.Result>
    {
        private readonly string _refreshToken;

        public OAuthRefreshRequest(HttpCommonSettings settings, string refreshToken) : base(settings, null)
        {
            _refreshToken = refreshToken;
        }

        protected override string RelationalUri => "https://o2.mail.ru/token";

        protected override byte[] CreateHttpContent()
        {
            var data = $"client_id={Settings.ClientId}&grant_type=refresh_token&refresh_token={_refreshToken}";
            return Encoding.UTF8.GetBytes(data);
        }

        protected override HttpWebRequest CreateRequest(string baseDomain = null)
        {
            var request = base.CreateRequest(baseDomain);
            request.Host = request.RequestUri.Host;
            request.UserAgent = Settings.UserAgent;
            request.Accept = "*/*";
            request.ServicePoint.Expect100Continue = false;

            return request;
        }


        public class Result
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }

            public string error { get; set; }
            public int error_code { get; set; }
            public string error_description { get; set; }
        }
    }
}