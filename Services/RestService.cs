using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RestService<TEntity> : IRestService<TEntity> where TEntity : class
    {
        protected static string baseUrl = "https://localhost:7041/api";

        public async Task<List<TEntity>> DoHttpGetRequest(string controllerUrl)
        {
            var returnResponse = new List<TEntity>();
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{controllerUrl}";
                var apiResponse = await client.GetAsync(url);

                returnResponse = JsonConvert.DeserializeObject<List<TEntity>>(await apiResponse.Content.ReadAsStringAsync());
                return returnResponse;
            }
        }

        public async Task<TEntity> DoHttpGetSingleRequest(string controllerUrl)
        {
            TEntity returnResponse;
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{controllerUrl}";
                var apiResponse = await client.GetAsync(url);

                returnResponse = JsonConvert.DeserializeObject<TEntity>(await apiResponse.Content.ReadAsStringAsync());
                return returnResponse;
            }
        }

        public async Task<string> DoHttpPostRequest(string controllerUrl, TEntity entityToInsert)
        {
            string returnResponse = $"Something went wrong, trying to insert {nameof(TEntity)}...";
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{controllerUrl}";
                var serializedEntity = JsonConvert.SerializeObject(entityToInsert);
                var apiResponse = await client.PostAsync(url, new StringContent(serializedEntity, Encoding.UTF8, "application/json"));
                var response = await apiResponse.Content.ReadAsStringAsync();

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    returnResponse = "Success!";
                }
            }
            return returnResponse;
        }

        public async Task<string> DoHttpPutRequest(string controllerUrl, TEntity entityToUpdate)
        {
            string returnResponse = $"Something went wrong, trying to update {nameof(TEntity)}...";
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{controllerUrl}";
                var serializedEntity = JsonConvert.SerializeObject(entityToUpdate);
                var apiResponse = await client.PutAsync(url, new StringContent(serializedEntity, Encoding.UTF8, "application/json"));
                var response = await apiResponse.Content.ReadAsStringAsync();

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    returnResponse = "Success!";
                }
            }
            return returnResponse;
        }

        public async Task<string> DoHttpDeleteRequest(string controllerUrl)
        {
            string returnResponse = $"Something went wrong, trying to delete {nameof(TEntity)}...";
            using (var client = new HttpClient())
            {
                string url = $"{baseUrl}/{controllerUrl}";
                var apiResponse = await client.DeleteAsync(url);
                var response = await apiResponse.Content.ReadAsStringAsync();

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    returnResponse = "Success!";
                }
            }
            return returnResponse;
        }
    }
}
