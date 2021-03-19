using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class API1UITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public API1UITests()
        {
            _driver = new ChromeDriver();
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Index_WhenExecuted_ReturnsSwaggerPage()
        {
            _driver.Navigate()
                .GoToUrl("http://localhost:5000/index.html");
            Assert.Equal("Swagger UI", _driver.Title);
            Assert.Contains("API 1", _driver.PageSource);
            Assert.Contains("API about interest rate", _driver.PageSource);
        }

        [Fact]
        public void EndpointTaxaJuros_WhenExecuted_ReturnsADecimal()
        {
            _driver.Navigate()
                .GoToUrl("http://localhost:5000/api/Interest/taxaJuros");

            string jsonResult = _driver.FindElement(By.CssSelector("pre")).Text;
            bool parseResult = decimal.TryParse(jsonResult, out decimal result);

            Assert.True(parseResult);
        }

    }
}
