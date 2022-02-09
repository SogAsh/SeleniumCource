using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Practice1
{
    public class Homework
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void CheckTransitionToVkipedia()
        {
            driver.Navigate().GoToUrl("https://ru.wikipedia.org/");
            IWebElement queryInput = driver.FindElement(By.Name("search")); //явное ожидание, для ожидания всего всего
            IWebElement searchButton = driver.FindElement(By.Name("go")); //неявное ожидание, для ожидания появление элемента на странице
            // не нужно прописывать в методах

            queryInput.SendKeys("Selenium");
            searchButton.Click();

            Assert.IsTrue(driver.Title.Contains("Selenium — Википедия"), "не перешли на страницу");
            Assert.AreEqual("Selenium — Википедия", driver.Title, "не перешли на страницу");
        }

        [Test]
        public void Locators()
        {
            driver.Navigate().GoToUrl("https://www.labirint.ru/guestbook/");

            var input = driver.FindElement(By.Id("search-field"));
            var block = driver.FindElements(By.ClassName("b-rfooter-e-item"));
            var search = driver.FindElement(By.Name("searchformadvanced"));
            var allGoods = driver.FindElement(By.CssSelector(".sorting-items.sorting-active"));
            var years = driver.FindElements(By.CssSelector("select[name='year_begin'] option:not([selected])"));
            var linkText = driver.FindElement(By.LinkText("Как сделать заказ"));
            var link = driver.FindElement(By.CssSelector("[data-event-content = 'Как сделать заказ']"));
        }
    }
}