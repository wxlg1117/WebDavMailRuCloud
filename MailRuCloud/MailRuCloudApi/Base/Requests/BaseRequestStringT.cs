﻿using System.IO;

namespace YaR.MailRuCloud.Api.Base.Requests
{
    public abstract class BaseRequestString<T> : BaseRequest<string, T> where T : class
    {
        protected BaseRequestString(RequestInit init) : base(init)
        {
        }

        protected override string Transport(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}