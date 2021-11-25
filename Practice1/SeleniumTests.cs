using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;

namespace Practice1
{
    public class SeleniumTests
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
            // не нужно прописывать в матодах

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

    public class SeleniumPracticeTests
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
            driver.Navigate().GoToUrl("https://www.labirint.ru/books/");
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
             * проверка текста                                                          ????????????????????
             * Вбить верный город +  
             * Выбрать выпадашку +
             * Заполняем улицу +
             * дом, строение кв, домофон +
             * Выбираем дату +
             * Готово +
             * Проверка отсутствия большого ЛБ курьерской доставки ,т.е. найти локатор ЛБ ??????????????????????
             */
            
            var cookie = driver.FindElement(By.ClassName("cookie-policy__button"));
            cookie.Click();
            var book = driver.FindElement(By.CssSelector("span > a[href='/books/']"));
            Actions action = new Actions(driver);
            action.MoveToElement(book);
            action.Perform();
            var books = driver.FindElement(By.CssSelector("li.b-menu-second-item a[href='/books/']"));
            books.Click();
            var addToBasket = driver.FindElement(By.CssSelector(".products-row-action [data-idtov='496161']"));
            addToBasket.Click();
            var checkout = driver.FindElement(By.CssSelector(".products-row-action .btn-more"));
            checkout.Click();
            var beginCheckout = driver.FindElement(By.CssSelector("#basket-default-begin-order"));
            beginCheckout.Click();
            var сourier = driver.FindElement(By.CssSelector(".b-radio-delivery-courier > .b-radio-e-bg"));
            сourier.Click();
            var city = driver.FindElement(By.CssSelector(".js-district"));
            city.Click();
            city.SendKeys("dfgfgfg");
            city.SendKeys(Keys.Enter);
            var wrongCity = driver.FindElement(By.CssSelector(".responsive-children .b-form-e-row-m-district .b-form-error-e-text"));
            // wrongCity.Text.Should().Be("Неизвестный город"); //??????????????????????????
            city.Clear();
            city.SendKeys("Екатеринбург");
            var chooseCity = driver.FindElement(By.CssSelector(".suggests-item-txt"));
            chooseCity.Click();
            var street = driver.FindElement(By.CssSelector(".js-street-suggests"));
            street.Click();
            street.SendKeys("Малопрудная ул.");
            var chooseStreet = driver.FindElement(By.CssSelector("#suggest-undefined"));
            chooseStreet.Click();
            var house = driver.FindElement(By.CssSelector(".js-gpscheck.b-form-input-m-short"));
            house.Click();
            house.SendKeys("5");
            var corp = driver.FindElement(By.CssSelector(".js-corp"));
            corp.Click();
            corp.SendKeys("1");
            var flat = driver.FindElement(By.CssSelector(".js-flat"));
            flat.Click();
            flat.SendKeys("1");
            var intercom = driver.FindElement(By.CssSelector(".b-form-input-m-tight"));
            intercom.Click();
            intercom.SendKeys("1");
            var date = driver.FindElement(By.CssSelector("tr:nth-of-type(5) [href='#']"));
            date.Click();
            var done = driver.FindElement(By.CssSelector("[value='Готово']"));
            done.Click();
            var expressDeliveryLightbox = driver.FindElement(By.CssSelector(".responsive-children .b-dlform-inner"));
            //Assert.IsFalse(expressDeliveryLightbox); //??
            expressDeliveryLightbox.Should().NotBe(expressDeliveryLightbox);
        }
    }
}