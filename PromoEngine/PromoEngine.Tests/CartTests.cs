using PromoEngine.EngineLib;
using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromoEngine.Tests
{
    public class CartTests
    {
        [Fact]
        public void ShouldHaveZeroTotalCartValueForNewCart()
        {
            decimal expected = 0m;

            IShoppingCart cart = Factory.CreateShoppingCart();

            Assert.Equal(expected, cart.TotalCartValue);
        }
        [Fact]
        public void ShouldHaveZeroTotalCartValuePostPromoProcessForNewCart()
        {
            decimal expected = 0m;

            IShoppingCart cart = Factory.CreateShoppingCart();

            Assert.Equal(expected, cart.TotalCartValuePostPromoProcess);
        }

        [Fact]
        public void ShouldHaveZeroItemsForNewCart()
        {
            int expected = 0;

            IShoppingCart cart = Factory.CreateShoppingCart();

            Assert.Equal(expected, cart.Items.Count());
        }

        [Fact]
        public void ShouldHaveZeroPromotionsAppliedForNewCart()
        {
            int expected = 0;

            IShoppingCart cart = Factory.CreateShoppingCart();

            Assert.Equal(expected, cart.PromotionsApplied.Count());
        }

        [Fact]
        public void ShouldHaveItemsCountEqualToLoadedItems()
        {
            int expected = 4;
            List<IShoppingItem> items = new List<IShoppingItem>() { };
            for (int i = 0; i < expected; i++)
            {
                items.Add(Factory.CreateShoppingItem());
            }

            IShoppingCart cart = Factory.CreateShoppingCart();
            cart.LoadShoppingItems(items);

            Assert.Equal(expected, cart.Items.Count());
        }

        [Fact]
        public void ShouldHaveTotalValueEqualToLoadedItems()
        {
            decimal expected = 15.35m;
            List<IShoppingItem> items = new List<IShoppingItem>() {
                new ShoppingItem() { Price = 10M },
                new ShoppingItem() { Price = 5M },
                new ShoppingItem() { Price = .35M } };

            IShoppingCart cart = Factory.CreateShoppingCart();
            cart.LoadShoppingItems(items);

            Assert.Equal(expected, cart.TotalCartValue);
        }

        [Fact]
        public void ShouldHaveTotalValuesEqualWhenNoPromotionsApplied()
        {
            List<IShoppingItem> items = new List<IShoppingItem>() {
                new ShoppingItem() { Price = 10M },
                new ShoppingItem() { Price = 5M },
                new ShoppingItem() { Price = .35M } };

            IShoppingCart cart = Factory.CreateShoppingCart();
            cart.LoadShoppingItems(items);

            Assert.Equal(cart.TotalCartValuePostPromoProcess, cart.TotalCartValue);
        }

        [Fact]
        public void ShouldHaveRegisteredAppliablePromotionsAfterSimpleCall()
        {
            int expected = 1;

            IShoppingCart cart = Factory.CreateShoppingCart();
            cart.RegisterAppliedPromotion(Factory.CreateSinglePackFixPricePromoRule());

            Assert.Equal(expected, cart.PromotionsApplied.Count());
        }
    }
}
