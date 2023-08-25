using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace IntelDataBase.HelperMethods
{
    public class HttpCall : HttpCallBase
    {
        public new APIResult HttpGet(string Url, string Token = null)
        {
            var result = base.HttpGet(Url, Token);
            return result.ToApiResult();
        }
        public TResponse HttpGet<TResponse>(string Url, string Token = null)
        {
            var result = base.HttpGet(Url, Token);
            return result.ToApiResult<TResponse>();
        }

        public new APIResult HttpPost(string Url, string JsonData, string Token = null)
        {
            var result = base.HttpPost(Url, JsonData, Token);
            return result.ToApiResult();
        }

        public TResponse HttpPost<TResponse>(string Url, string JsonData, string Token = null)
        {
            var result = base.HttpPost(Url, JsonData, Token);
            return result.ToApiResult<TResponse>();
        }

        public TResponse HttpPost<TRequest, TResponse>(string Url, TRequest Data, string Token = null)
        {
            var jsonString = JsonConvert.SerializeObject(Data);
            var result = base.HttpPost(Url, jsonString, Token);
            return result.ToApiResult<TResponse>();
        }
    }

    public abstract class HttpCallBase
    {
        protected virtual HttpResponseMessage HttpPost(string Url, string JsonData, string Token = null)
        {
            using (HttpClient _Client = new HttpClient())
            {

                if (Token != null)
                {
                    _Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                }

                var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var HttpResponseTask = _Client.PostAsync(Url, content);
                HttpResponseTask.Wait();
                var result = HttpResponseTask.Result;
                return result;

            }
        }

        protected virtual HttpResponseMessage HttpGet(string Url, string Token = null)
        {
            using (HttpClient _Client = new HttpClient())
            {

                if (Token != null)
                {
                    _Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                }

                var HttpResponseTask = _Client.GetAsync(Url);
                HttpResponseTask.Wait();
                var result = HttpResponseTask.Result;
                return result;
            }
        }
    }

    public static class HttpCallExtensionMethods
    {
        public static APIResult ToApiResult(this HttpResponseMessage result)
        {
            if (result.StatusCode != HttpStatusCode.OK)
            {
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                throw new Exception(result.StatusCode.ToString());
            }

            var ContentTask = result.Content.ReadAsStringAsync();
            ContentTask.Wait();
            var Content = ContentTask.Result;
            var APIResult = JsonConvert.DeserializeObject<APIResult>(Content); 
            return APIResult;
        }

        public static T ToApiResult<T>(this HttpResponseMessage result)
        {
            var Apiresult = result.ToApiResult();
            return JsonConvert.DeserializeObject<T>(Apiresult.zip_codes.ToString());
        }
    }

    public class APIResult
    {
        public object zip_codes { get; set; }

    }

    public class ZipCodeViewModel
    {
        public string zip_code { get; set; }
        public double distance { get; set; }
    }
}