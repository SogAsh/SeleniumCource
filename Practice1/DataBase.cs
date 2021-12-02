using OpenQA.Selenium;

namespace Practice1
{
    public class DataBase
    {
        public static By cookie = By.ClassName("cookie-policy__button");
        public static By book = By.CssSelector(".top-link-menu .b-header-b-menu-e-text");
        public static By books = By.CssSelector(".b-menu-second-item a[href='/books/']");
        public static By addToBasket = By.CssSelector("a.btn-primary[data-position='1']");
        public static By checkout = By.CssSelector(".products-row-action .btn-more");
        public static By beginCheckout = By.CssSelector("#basket-default-begin-order");
        public static By сourier = By.CssSelector(".b-radio-delivery-courier > .b-radio-e-bg");
        public static By city = By.CssSelector(".js-district");
        public static By wrongCity = By.CssSelector(".responsive-children .b-form-e-row-m-district .b-form-error-e-text");
        public static By chooseCity = By.CssSelector(".suggests-item-txt");
        public static By street = By.CssSelector(".js-street-suggests");
        public static By chooseStreet = By.CssSelector("#suggest-undefined");
        public static By house = By.CssSelector(".js-gpscheck.b-form-input-m-short");
        public static By corp = By.CssSelector(".js-corp");
        public static By flat = By.CssSelector(".js-flat");
        public static By housePhone = By.CssSelector(".b-form-input-m-tight");
        public static By done = By.CssSelector("[value='Готово']");
        public static By expressDeliveryLightbox = By.CssSelector(".responsive-modal[style*='display: none']");
    }
}