using DotnetUnitTesting;
using NUnit.Framework;

namespace UnitTesting
{
    public class Tests
    {
        [Test]
        public void VerifyThatUserCanAddProductsToTheShoppingCart()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            Product productToAdd = new Product(1, "Milk", 10.99, 1.0);

            //Act
            shoppingCart.AddProductToCart(productToAdd);

            //Assert
            Assert.IsTrue(shoppingCart.Products.Contains(productToAdd));
        }

        [Test]
        public void VerifyThatUserCanRemoveProductsToTheShoppingCart()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            Product productToAdd = new Product(1, "Milk", 10.99, 1.0);
            shoppingCart.AddProductToCart(productToAdd);

            //Act
            shoppingCart.RemoveProductFromCart(productToAdd);

            //Assert
            Assert.IsFalse(shoppingCart.Products.Contains(productToAdd));
        }

        [Test]
        public void VerifyThatUserCanGetTheTotalPriceOfTheShoppingCart()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            Product productToAdd = new Product(1, "Milk", 10.00, 2.0);

            //Act
            shoppingCart.AddProductToCart(productToAdd);

            //Assert
            Assert.AreEqual(20.00, shoppingCart.GetCartTotalPrice());
        }

        [Test]
        public void VerifyThatProductQuantityIncreasesIfAddProductToShoppingCartTheSecondTime()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            Product productToAdd = new Product(1, "Milk", 10.00, 1.0);

            //Act
            shoppingCart.AddProductToCart(productToAdd);
            shoppingCart.AddProductToCart(productToAdd);

            //Assert
            Assert.AreEqual(2.0, shoppingCart.Products[0].Quantity);
        }
    }
}