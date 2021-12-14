using NUnit.Framework;
using Practice1.Pages;

namespace Practice1
{
    [TestFixture]
    public class Homework : SeleniumTestBase
    {
        [Test]
        public void BasketPage_EnterInvalidCity_ErrorCity()
        {
            PrepairArrange();

            //act
            var courierPage = new CourierDeliveryLightbox(driver, wait);
            courierPage.EnterCity("ddddd", false);

            //assert
            Assert.IsTrue(courierPage.IsVisibleErrorCity(), "Не появилась ошибка о неизвестном городе");
        }

        [Test]
        public void BasketPage_FillAll_Success()
        {
            PrepairArrange();

            //act
            var courierPage = new CourierDeliveryLightbox(driver, wait);
            courierPage.EnterCity("Екатеринбург", true);
            courierPage.AddAdress("Малопрудная ул.", "5", "1", "1", "1");
            courierPage.SetDate();
            courierPage.Confirm();

            //assert
            Assert.IsFalse(courierPage.IsVisibleLightbox(), "ЛБ курьерской доставки отображается");
        }

        private void PrepairArrange()
        {
            //arrange
            var homePage = new HomePage(driver, wait);
            homePage.OpenPage();
            homePage.AddBookToCard();

            var basketPage = new BasketPage(driver, wait);
            basketPage.ChooseCourierDelivery();
        }
    }
}