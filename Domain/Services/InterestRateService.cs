using Domain.Helpers;
using Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class InterestRateService : IInterestRateService
    {
        private readonly ApiRequest _api = null;
        public InterestRateService(IConfiguration configuration)
        {
           string url = configuration.GetSection("Services:API1").Value;
            _api = new ApiRequest(url);
        }
            
        public async Task<decimal> Get()
        {
           
            var result = await _api.Get("api/interest/taxaJuros");

            if (result.Success)
            {
               return JsonConvert.DeserializeObject<decimal>(result.Data.ToString());
            }
            else
            {
                throw new Exception($"Não foi possível obter o valor da taxa de juros: {result.Message}");
            }
        }
    }
}
