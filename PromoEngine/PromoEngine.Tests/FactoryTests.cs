using PromoEngine.EngineLib;
using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.Engine;
using PromoEngine.EngineLib.Product;
using PromoEngine.EngineLib.PromoRules;
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

        [Fact]
        public void ShouldCreateNewShoppingItem()
        {
            IShoppingItem shopItem;

            shopItem = Factory.CreateShoppingItem();

            Assert.NotNull(shopItem);
        }

        [Fact]
        public void ShouldCreateNewFixPriceSinglePackPromoRule()
        {
            IPromotion promoRule;

            promoRule = Factory.CreateSinglePackFixPricePromoRule();

            Assert.NotNull(promoRule);
        }
    }
}
