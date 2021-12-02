using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace Practice1 
{
    public class Homework : DataBase
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            driver.Navigate().GoToUrl("https://www.labirint.ru/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void OrderBook_ShouldSuccess()
        {
            driver.FindElement(cookie).Click();
            var action = new Actions(driver);
            action.MoveToElement(driver.FindElement(book));
            action.Perform();
            driver.FindElement(books).Click();
            Assert.IsTrue(driver.Title.Contains("Купить книги через интернет магазин, заказать книги почтой по интернету | Лабиринт"),
                "не перешли на страницу");
            driver.FindElement(addToBasket).Click();
            driver.FindElement(checkout).Click();
            driver.FindElement(beginCheckout).Click();
            driver.FindElement(сourier).Click();
            driver.FindElement(city).SendKeys("dfgfgfg");
            driver.FindElement(city).SendKeys(Keys.Tab);
            driver.FindElement(wrongCity).Text.Should().Be("Неизвестный город");
            driver.FindElement(city).Clear();
            driver.FindElement(city).SendKeys("Екатеринбург");
            driver.FindElement(chooseCity).Click();
            driver.FindElement(street).SendKeys("Малопрудная ул.");
            driver.FindElement(chooseStreet).Click();
            driver.FindElement(house).SendKeys("5");
            driver.FindElement(corp).SendKeys("1");
            driver.FindElement(flat).SendKeys("1");
            driver.FindElement(housePhone).SendKeys("1");
            (driver as IJavaScriptExecutor).ExecuteScript(
                $"$('.js-dlform-wrap .js-delivery-date').datepicker('setDate','{DateTime.Today.AddDays(8).ToString("dd.MM.yyyy")}')");
            driver.FindElement(done).Click();

            var checkLightboxDisplayed = existsElement(expressDeliveryLightbox);
            checkLightboxDisplayed.Should().BeTrue();
        }

        private bool existsElement(By element)
        {
            try
            {
                driver.FindElement(element);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
    }
}