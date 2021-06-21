using PromoEngine.EngineLib;
using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.Engine;
using PromoEngine.EngineLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromoEngine.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void ShouldCreateNewShoppingCart()
        {
            IShoppingCart cart;

            cart = Factory.CreateShoppingCart();

            Assert.NotNull(cart);
        }

        [Fact]
        public void ShouldCreateNewEngine()
        {
            IPromoEvalEngine engine;

            engine = Factory.CreatePromoEvalEngine();

            Assert.NotNull(engine);
        }

        public void ShouldCreateNewShoppingItem()
        {
            IShoppingItem shopItem;

            shopItem = Factory.CreateShoppingItem();

            Assert.NotNull(shopItem);
        }
    }
}
