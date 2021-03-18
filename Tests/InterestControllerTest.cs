using API1;
using API1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class InterestControllerTest
    : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly InterestController _controller;
        public InterestControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _controller = new InterestController();
        }

        [Fact]
        public void CalculateInterest_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetInterestRate();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData("/api/interest/taxaJuros")]
        public async Task GetInterestRate_EndpointReturnSuccessAndCorrectContentType(string url)
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
