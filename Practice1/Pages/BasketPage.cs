using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Practice1.Pages
{
    public class BasketPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasketPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        private By сourier = By.CssSelector(".b-radio-delivery-courier > .b-radio-e-bg");

        public void ChooseCourierDelivery()
        {
            driver.FindElement(сourier).Click();
        }
    }
}