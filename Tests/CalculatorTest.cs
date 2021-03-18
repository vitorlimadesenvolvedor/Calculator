using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void CalculateCompoundInterest_NegativeParams_ReturnsDecimal()
        {
            //Arrange
            
            decimal initalValue = -100;
            int months = -5;
            decimal interestRate = 0.01m;
            
            //Act
            
            decimal result = Calculator.CalculateCompoundInterest(initalValue, interestRate, months);

            //Assert
            Assert.Equal(105.10m, result);

        }

        [Fact]
        public void CalculateCompoundInterest_ReturnsDecimalWithTwoDecimalPlacesAndNoRounded()
        {
            // Arrange
            decimal initalValue = 177.36m;
            int months = 5;
            decimal interestRate = 0.01m;

            // Act
            decimal result = Calculator.CalculateCompoundInterest(initalValue, interestRate, months);
            int decimalPlacesNumber = result.ToString(CultureInfo.InvariantCulture).Split('.')[1].Length;

            // Assert
            Assert.Equal(2, decimalPlacesNumber);
            Assert.Equal(186.40m, result);
        }
    }
}
