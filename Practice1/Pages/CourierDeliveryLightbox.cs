using System;
using System.Globalization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Practice1.Pages
{
    public class CourierDeliveryLightbox
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CourierDeliveryLightbox(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        private By city = By.CssSelector(".js-district");
        private By wrongCity = By.CssSelector(".responsive-children .b-form-e-row-m-district .b-form-error-e-text");
        private By chooseCity = By.CssSelector(".suggests-item-txt");
        private By street = By.CssSelector(".js-street-suggests");
        private By chooseStreet = By.CssSelector("#suggest-undefined");
        private By house = By.CssSelector(".js-gpscheck.b-form-input-m-short");
        private By corp = By.CssSelector(".js-corp");
        private By flat = By.CssSelector(".js-flat");
        private By housePhone = By.CssSelector(".b-form-input-m-tight");
        private By done = By.CssSelector("[value='Готово']");
        private By expressDeliveryLightbox = By.CssSelector(".responsive-modal[style*='display: none']");
        private By loadingpanel = By.CssSelector(".loading-panel");

        public void Confirm()
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingpanel));
            driver.FindElement(done).Click();
        }

        public void SetDate()
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingpanel));

            (driver as IJavaScriptExecutor).ExecuteScript(
                $"$('.js-dlform-wrap .js-delivery-date').datepicker('setDate','{DateTime.Now.AddDays(3).ToString("d", DateTimeFormatInfo.InvariantInfo)}')");
        }

        public void AddAdress(string cityStreet, string numBuild, string corpNum, string flatNum, string housePhoneNum)
        {
            driver.FindElement(street).SendKeys(cityStreet);
            driver.FindElement(chooseStreet).Click();
            driver.FindElement(house).SendKeys(numBuild);
            driver.FindElement(corp).SendKeys(corpNum);
            driver.FindElement(flat).SendKeys(flatNum);
            driver.FindElement(housePhone).SendKeys(housePhoneNum);
        }

        public void EnterCity(string nameCity, bool validCity = true)
        {
            driver.FindElement(city).Clear();
            driver.FindElement(city).SendKeys(nameCity);
            var value = driver.FindElement(city).GetAttribute("value");
            Assert.AreEqual(nameCity, value);

            if (validCity)
            {
                driver.FindElement(chooseCity).Click();
            }
            else
            {
                driver.FindElement(city).SendKeys(Keys.Tab);
            }
        }

        public bool IsVisibleErrorCity()
        {
            return driver.FindElement(wrongCity).Displayed;
        }

        public bool IsVisibleLightbox()
        {
            return driver.FindElement(expressDeliveryLightbox).Displayed;
        }
    }
}