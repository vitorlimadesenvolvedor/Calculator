using Domain.Helpers;
using Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IInterestRateService _interestRateService;

        public CalculatorService(IInterestRateService interestRateService)
        {
            _interestRateService = interestRateService;
        }

        public async Task<decimal> GetTotalCompoundInterestGain(decimal initialValue, int months)
        {
            decimal interestRate = await _interestRateService.Get();

            return Calculator.CalculateCompoundInterest(initialValue, interestRate, months);
        }
    }
}
