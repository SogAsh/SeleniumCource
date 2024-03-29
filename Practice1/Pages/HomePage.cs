﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        private string url = "https://www.labirint.ru/";
        private By cookie = By.ClassName("cookie-policy__button");
        private By book = By.CssSelector(".top-link-menu .b-header-b-menu-e-text");
        private By books = By.CssSelector(".b-menu-second-item a[href='/books/']");
        private By addToBasket = By.CssSelector("a.btn-primary[data-position='1']");
        private By checkout = By.CssSelector(".products-row-action .btn-more");
        private By beginCheckout = By.CssSelector("#basket-default-begin-order");
        private By allTheme = By.CssSelector(".btn[href='/now/']");

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            driver.FindElement(cookie).Click();
        }

        public void AddBookToCard()
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(book))
                .Perform();

            wait.Until(ExpectedConditions.ElementIsVisible(books));
            driver.FindElement(books).Click();
            driver.FindElement(addToBasket).Click();
            CheckDeliveryUrl();
            var textContent = driver.FindElement(checkout).GetAttribute("textContent");
            Assert.AreEqual("ОФОРМИТЬ", textContent);
            driver.FindElement(checkout).Click();
            driver.FindElement(beginCheckout).Click();
        }

        private void CheckDeliveryUrl()
        {
            var expected = "https://www.labirint.ru/now/";
            Assert.AreEqual(expected, driver.FindElement(allTheme).GetAttribute("href"));
        }
        
    }
}