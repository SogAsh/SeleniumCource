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
            Assert.IsTrue(driver.FindElement(books).Displayed);
            driver.FindElement(books).Click();
            Assert.IsTrue(driver.Url.Contains("https://www.labirint.ru/books/"));
            driver.FindElement(addToBasket).Click();
            driver.FindElement(checkout).Click();
            driver.FindElement(beginCheckout).Click();
            driver.FindElement(сourier).Click();
            driver.FindElement(city).SendKeys("dfgfgfg");
            driver.FindElement(city).SendKeys(Keys.Tab);
            Assert.AreEqual("Неизвестный город", driver.FindElement(wrongCity).Text);
            driver.FindElement(city).Clear();
            driver.FindElement(city).SendKeys("Екатеринбург ");
            driver.FindElement(chooseCity).Click();
            driver.FindElement(street).SendKeys("Малопрудная ул.");
            driver.FindElement(chooseStreet).Click();
            driver.FindElement(house).SendKeys("5");
            driver.FindElement(corp).SendKeys("1");
            driver.FindElement(flat).SendKeys("1");
            driver.FindElement(housePhone).SendKeys("1");
            
            var loadgpanel = existsElement(loadingpanel);
            loadgpanel.Should().BeFalse(); //не понимаю почему падает, если пройтись дебагом, то будет false, а если просто run test, то true
            
            (driver as IJavaScriptExecutor).ExecuteScript(
                $"$('.js-dlform-wrap .js-delivery-date').datepicker('setDate','{DateTime.Today.AddDays(3).ToString("dd.MM.yyyy")}')");
            //дата 12.02.2021 ставится правильно, но потом скидывается обратно на 11 число
            
            driver.FindElement(done).Click();
            loadgpanel.Should().BeFalse(); 
            
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