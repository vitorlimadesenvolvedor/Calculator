using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class ApiRequest
    {
        private readonly HttpClient _client;
        public ApiRequest(string url)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }

        public async Task<GenericResponse> Get(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = new GenericResponse(true, "", data);
                    return result;
                }
                else
                {
                    return new GenericResponse(false, response.ReasonPhrase);
                }

            }
            catch (Exception ex)
            {
                return new GenericResponse(false, $"Url: {_client.BaseAddress}{url} :{ex.Message}");
            }

        }
    }
}
