using System;
using System.Net.Http;

namespace consumeapiiiii.Helper
{
    public class APIHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:42851/");
            return client;
        }
    }
}
