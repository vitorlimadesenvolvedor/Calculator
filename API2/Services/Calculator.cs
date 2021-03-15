using System;

namespace API2.Services
{
    public class Calculator
    {
        public decimal CalculateInterest(decimal initialValue, decimal interestRate, int months)
        {
            if (months < 0)
                months = Math.Abs(months);

            if (initialValue < 0)
                initialValue = Math.Abs(initialValue);

            decimal result = initialValue * (decimal)(Math.Pow((double)(1 + interestRate), months));
            decimal roundedResult = Math.Round(result, 2);

            return roundedResult;
        }
    }
}
