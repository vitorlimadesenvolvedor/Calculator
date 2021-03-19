using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class API2UITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public API2UITests()
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
                .GoToUrl("http://localhost:5001/index.html");
            Assert.Equal("Swagger UI", _driver.Title);
            Assert.Contains("API 2", _driver.PageSource);
            Assert.Contains("Calculator API", _driver.PageSource);
        }


        [Fact]
        public void EndpointCalculaJuros_WhenExecuted_ReturnsADecimal()
        {
            _driver.Navigate()
                .GoToUrl("http://localhost:5001/api/Calculator/calculajuros?valorInicial=100&meses=5");


            string jsonResult = _driver.FindElement(By.CssSelector("pre")).Text;
            bool parseResult = decimal.TryParse(jsonResult, out decimal result);

            Assert.True(parseResult);
        }


        [Fact]
        public void EndpointCalculaJuros_WrongModelData_ReturnsModelError()
        {
            _driver.Navigate()
                .GoToUrl("http://localhost:5001/api/Calculator/calculajuros?valorInicial=-100&meses=-5");


            Assert.Contains("Número de meses deve ser um inteiro positivo", _driver.PageSource);
            Assert.Contains("Valor inicial deve ser um decimal positivo", _driver.PageSource);
        }

        [Fact]
        public void CalculaJurosInSwaggerInterface_WrongModelData_ReturnsInputsError()
        {
            string ValorInicialCssSelector = "input[placeholder='ValorInicial']";
            string MesesCssSelector = "input[placeholder='Meses']";

            string backgroundColor = "rgba(254, 235, 235, 1)";
            string cssClass = "invalid";

            _driver.Navigate()
                .GoToUrl("http://localhost:5001/index.html");

            _driver.FindElement(By.Id("operations-Calculator-get_api_Calculator_calculajuros"))
               .Click();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            _driver.FindElement(By.Id("operations-Calculator-get_api_Calculator_calculajuros"))
               .Click();

            _driver.FindElement(By.CssSelector("button.try-out__btn"))
                .Click();

            _driver.FindElement(By.CssSelector(ValorInicialCssSelector))
                .SendKeys("-100");

            _driver.FindElement(By.CssSelector(MesesCssSelector))
                .SendKeys("-5");

            _driver.FindElement(By.CssSelector("button.opblock-control__btn"))
                .Click();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _driver.FindElement(By.CssSelector("button.opblock-control__btn"))
                .Click();

            var inputElementValorInicial = _driver.FindElement(By.CssSelector(ValorInicialCssSelector));
            var inputElementMeses = _driver.FindElement(By.CssSelector(MesesCssSelector));


            var inputCssClassFromValorInicial = inputElementValorInicial.GetAttribute("class");
            var inputCssClassFromMeses = inputElementMeses.GetAttribute("class");

            var inputBackgroundColorFromValorInicial = inputElementValorInicial.GetCssValue("background-color");
            var inputBackgroundColorFromMeses = inputElementMeses.GetCssValue("background-color");

            Assert.Equal(cssClass, inputCssClassFromValorInicial);
            Assert.Equal(cssClass, inputCssClassFromMeses);
            Assert.Equal(backgroundColor, inputBackgroundColorFromMeses);
            Assert.Equal(backgroundColor, inputBackgroundColorFromValorInicial);
        }
    }

}
