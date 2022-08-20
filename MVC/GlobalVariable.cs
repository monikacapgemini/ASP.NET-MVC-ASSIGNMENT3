using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace MVC
{
    public static class GlobalVariable
    {
        public static HttpClient WebAPIClient = new HttpClient();

        static GlobalVariable()
        {

            WebAPIClient.BaseAddress = new Uri("https://localhost:44304/api/");
            WebAPIClient.DefaultRequestHeaders.Clear();
            WebAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

    }
}