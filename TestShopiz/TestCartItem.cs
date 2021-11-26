using NUnit.Framework;
using Shopiz;

namespace TestShopiz
{
    public class TestCartItem
    {
        [Test]
        public void CartItemAndAllGetters_NominalCase_Succes()
        {
            //given
            string expectedId = "34RTZ";
            string expectedLongDescription = "A long cart item description";
            double expectedUnitPrice = 25.50d;

            //when
            CartItem cartItem = new CartItem(expectedId, expectedLongDescription, expectedUnitPrice);

            //then
            Assert.AreEqual(expectedId, cartItem.Id);
            Assert.AreEqual(expectedLongDescription, cartItem.LongDescription);
            Assert.AreEqual(expectedUnitPrice, cartItem.UnitPrice);
            Assert.AreEqual("CHF", cartItem.Currency);
        }

        [Test]
        public void UnitPrice_UpdatePrice_Succes()
        {
            //given
            double expectedUnitPrice = 50.0d;
            CartItem cartItem = new CartItem("34RTZ", "An other long cart item description", 40.00d);

            //when
            cartItem.UnitPrice = expectedUnitPrice;

            //then
            Assert.AreEqual(expectedUnitPrice, cartItem.UnitPrice);
        }

        [Test]
        public void UnitPrice_TooSmallValue_ThrowException()
        {
            //given
            double expectedUnitPrice = 00.10d;
            CartItem cartItem = new CartItem("34RTZ", "Cart item used to test a too small unit price case", 40.00d);

            //when

            Assert.Throws<TooSmallValueException>(delegate
            {
                cartItem.UnitPrice = expectedUnitPrice;
            });

            //then
            //Exception thrown
        }
    }
}