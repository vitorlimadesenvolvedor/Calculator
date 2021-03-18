using Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    public class InterestRateStub : IInterestRateService
    {
        public async Task<decimal> Get()
        {
            return await Task.Run(() => 0.01m );
        }
    }
}
