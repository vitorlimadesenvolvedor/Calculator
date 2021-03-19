using API2.Controllers;
using Domain.DTOs;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Tests.Fixture;
using Tests.Mocks;
using Xunit;

namespace Tests
{
    public class CalculatorControllerTest : IClassFixture<API2ApplicationFactory>
    {
        private readonly API2ApplicationFactory _factory;

        private readonly CalculatorController _controller;
        private readonly CalculatorService _service;

        public CalculatorControllerTest(API2ApplicationFactory factory)
        {
            _factory = factory;

            _service = new CalculatorService(new InterestRateStub());
            _controller = new CalculatorController(_service);
            
        }
        
        [Fact]
        public async Task CalculateInterest_ReturnsOkObjectResult()
        {
            // Arrange
            CalculatorDTO calculatorDTO = new CalculatorDTO { ValorInicial = 100, Meses = 5 };

            // Act
            var result = await _controller.CalculateInterest(calculatorDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ShowMeTheCode_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.ShowMeTheCode();
            
            // Assert
            Assert.IsType<ActionResult<Uri>>(result);
        }


        [Theory]
        [InlineData("/api/calculator/calculajuros?valorInicial=100&meses=5")]
        public async Task Get_CalculateInterest_EndpointReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/api/calculator/showmethecode")]
        public async Task Get_ShowMeTheCode_EndpointReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

    }
}
