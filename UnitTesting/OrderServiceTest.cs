using DotnetUnitTesting;
using NSubstitute;
using NUnit.Framework;

namespace UnitTesting
{
    class OrderServiceTest
    {
        [Test]
        public void VerifyThatUserGetsCorrectDiscount()
        {
            //Arrange
            var user = new UserAccount("John", "Smith", "1990/10/10");
            user.ShoppingCart.AddProductToCart(new Product(1, "Milk", 10, 1));
            var mock = Substitute.For<IDiscountUtility>();
            mock
                .CalculateDiscount(Arg.Is<UserAccount>(account =>
                    account.Name.Equals("John") && account.Surname.Equals("Smith") &&
                    account.DateOfBirth.Equals("1990/10/10")))
                .Returns(3.00);

            //Action
            var actualOrderPriceWithDiscount = new OrderService(mock).GetOrderPrice(user);

            //Assert
            mock.Received(1).CalculateDiscount(user);
            mock.DidNotReceiveWithAnyArgs();
            Assert.That(actualOrderPriceWithDiscount, Is.EqualTo(7));
        }
    }
}
