using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace Practice1
{
    public class Homework1
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        
        private static By cookie = By.ClassName("cookie-policy__button");
        private static By book = By.CssSelector(".top-link-menu .b-header-b-menu-e-text");
        private static By books = By.CssSelector(".b-menu-second-item a[href='/books/']");
        private static By addToBasket = By.CssSelector("a.btn-primary[data-position='1']");
        private static By checkout = By.CssSelector(".products-row-action .btn-more");
        private static By beginCheckout = By.CssSelector("#basket-default-begin-order");
        private static By сourier = By.CssSelector(".b-radio-delivery-courier > .b-radio-e-bg");
        private static By city = By.CssSelector(".js-district");
        private static By wrongCity = By.CssSelector(".responsive-children .b-form-e-row-m-district .b-form-error-e-text");
        private static By chooseCity = By.CssSelector(".suggests-item-txt");
        private static By street = By.CssSelector(".js-street-suggests");
        private static By chooseStreet = By.CssSelector("#suggest-undefined");
        private static By house = By.CssSelector(".js-gpscheck.b-form-input-m-short");
        private static By corp = By.CssSelector(".js-corp");
        private static By flat = By.CssSelector(".js-flat");
        private static By housePhone = By.CssSelector(".b-form-input-m-tight");
        private static By done = By.CssSelector("[value='Готово']");
        
        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.labirint.ru/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver = null;
        }
        
        [Test]
        public void ChechLocatorsInPractice1()
        {
            /*
             * В режиме инкогнито принять куки +
             * Книги + 
             * Все книги +
             * Любую первую книгу - добавить в корзину +
             * оформить +
             * начать оформление (синяя) +
             * курьерская доставка галочки +
             * Вбить неверный город и увидеть ошибку "Неизвестный город"
             * проверка текста                       //??????????????????????????                                   
             * Вбить верный город +  
             * Выбрать выпадашку +
             * Заполняем улицу +
             * дом, строение кв, домофон +
             * Выбираем дату +
             * Готово +
             * Проверка отсутствия большого ЛБ курьерской доставки ,т.е. найти локатор ЛБ ??????????????????????
             */
            
            driver.FindElement(cookie).Click();
            var action = new Actions(driver);
            action.MoveToElement(driver.FindElement(book));
            action.Perform();
            driver.FindElement(books).Click();
            driver.FindElement(addToBasket).Click();
            driver.FindElement(checkout).Click();
            driver.FindElement(beginCheckout).Click();
            driver.FindElement(сourier).Click();
            driver.FindElement(city).SendKeys("dfgfgfg");
            driver.FindElement(city).SendKeys(Keys.Enter);
            //driver.FindElement(wrongCity).Text.Should().Be("Неизвестный город"); //??????????????????????????
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
            var expressDeliveryLightbox = driver.FindElement(By.CssSelector(".responsive-children .b-dlform-inner"));
            //Проверка отсутствия большого ЛБ курьерской доставки
        }
    }
}