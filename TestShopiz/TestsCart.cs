using NUnit.Framework;
using Shopiz;
using System.Collections.Generic;

namespace TestShopiz
{
    public class TestCart
    {
        [Test]
        public void CartAndAllGetters_NewCartWithoutItem_Success()
        {
            //given
            string expectedId = "XFIF";
            string expectedName = "Christmas Gift";
            int expectedCartSize = 0;
            string expectedCurrency = "CHF";
            double expectedCartBalance = 0.0d;

            //when
            Cart cart = new Cart(expectedId, expectedName);

            //then
            Assert.AreEqual(expectedId, cart.Id);
            Assert.AreEqual(expectedName, cart.Name);
            Assert.AreEqual(expectedCartSize, cart.CartItems.Count);
            Assert.AreEqual(expectedCurrency, cart.Currency);
            Assert.AreEqual(expectedCartBalance, cart.Balance);
        }

        [Test]
        public void CartAndAllGetters_NewCartWithItems_Success()
        {
            //given
            string expectedId = "ROVHR";
            string expectedName = "Mom's birthday";
            int expectedCartSize = 10;
            string expectedCurrency = "CHF";
            double expectedCartBalance = 1450.0d;

            //when
            Cart cart = new Cart(expectedId, expectedName, GenerateCartItems(expectedCartSize, 10));

            //then
            Assert.AreEqual(expectedId, cart.Id);
            Assert.AreEqual(expectedName, cart.Name);
            Assert.AreEqual(expectedCartSize, cart.CartItems.Count);
            Assert.AreEqual(expectedCurrency, cart.Currency);
            Assert.AreEqual(expectedCartBalance, cart.Balance);
        }

        [Test]
        public void AddItems_EmptyCartAddOneItem_Success()
        {
            //given
            string expectedId = "ZRTIVIA";
            string expectedName = "Anni'w wedding";
            int expectedCartSize = 1;
            double expectedCartBalance = 0.0d;
            Cart cart = new Cart(expectedId, expectedName);

            //when
            cart.AddItems(GenerateCartItems(1,0));

            //then
            Assert.AreEqual(expectedCartSize, cart.CartItems.Count);
            Assert.AreEqual(expectedCartBalance, cart.Balance);
        }

        [Test]
        public void AddItems_NotEmptyCartAddOneItem_Success()
        {
            //given
            string expectedId = "URTZR34";
            string expectedName = "Wish List";
            int expectedCartSize = 2;
            double expectedCartBalance = 100.0d;
            Cart cart = new Cart(expectedId, expectedName);
            cart.AddItems(GenerateCartItems(1, 4));

            //when
            cart.AddItems(GenerateCartItems(1, 6));

            //then
            Assert.AreEqual(expectedCartSize, cart.CartItems.Count);
            Assert.AreEqual(expectedCartBalance, cart.Balance);
        }

        [Test]
        public void AddItems_NotEmptyCartAddItems_Success()
        {
            //given
            string expectedId = "784RTVAR";
            string expectedName = "Holiday - Camping material";
            int expectedCartSize = 15;
            double expectedCartBalance = 1850.0d;
            Cart cart = new Cart(expectedId, expectedName);
            cart.AddItems(GenerateCartItems(10, 3));

            //when
            cart.AddItems(GenerateCartItems(5,20));

            //then
            Assert.AreEqual(expectedCartSize, cart.CartItems.Count);
            Assert.AreEqual(expectedCartBalance, cart.Balance);
        }

        [Test]
        public void Empty_TryToEmptyAnEmptyCart_ThrowException()
        {
            //given
            Cart cart = new Cart("ALURIA_Rt5", "Sport Cart");

            //when
            Assert.Throws<EmptyCartException>(delegate
            {
                cart.Empty();
            });

            //then
            //Exception thrown
        }

        [Test]
        public void Empty_NotEmptyCart_Success()
        {
            //given
            Cart cart = new Cart("RIAJöV_", "Books in German", GenerateCartItems(10, 40));
            
            //when
            cart.Empty();

            //then
            Assert.AreEqual(0, cart.CartItems.Count);
            Assert.AreEqual(0.0d, cart.Balance);
        }

        private List<CartItem> GenerateCartItems(int quantity, int startIndex)
        {
            List<CartItem> carItemsGenerated = new List<CartItem>();
            for (int i = startIndex; i < quantity + startIndex; i++)
            {
                CartItem cartItem = new CartItem(i.ToString(), "Description" + i, i*10);
                carItemsGenerated.Add(cartItem);
            }
            return carItemsGenerated;
        }
    }
}