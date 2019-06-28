﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Net.Http.Headers;

namespace Cinema.gui.Logic
{
    public class ApiClient
    {
        readonly string baseurl = @"http://localhost:50163/";

        public  T GetData<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return new T();
                var EmpResponse = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(EmpResponse);

            }
        }

        public bool PostData<T>(string url, T obj) 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(obj).ToString(), Encoding.UTF8 , "application/json");
                var result = client.PostAsync(url, content);
                return result.Result.IsSuccessStatusCode;

            }
        }

        public T1 PostData<T, T1>(string url, T obj)
        {
            using ( var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(obj).ToString(),
                    Encoding.UTF8, "application/json");
                var result = client.PostAsync(url, content);
                var tempResponse = result.Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T1>(tempResponse);

            }
        }
    }
}