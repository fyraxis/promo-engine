using PromoEngine.EngineLib;
using PromoEngine.EngineLib.Engine;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromoEngine.Tests
{
    public class EngineTests
    {
        [Fact]
        public void ShouldHaveNoAttachedCartForNewEngine()
        {
            IPromoEvalEngine engine = Factory.CreatePromoEvalEngine();

            Assert.Null(engine.Cart);
        }

        [Fact]
        public void ShouldHaveNoAttachedPromoRulesForNewEngine()
        {
            IPromoEvalEngine engine = Factory.CreatePromoEvalEngine();

            Assert.Null(engine.Rules);
        }

        [Fact]
        public void ShouldHaveAShoppingCartAfterLoading()
        {
            IPromoEvalEngine engine = Factory.CreatePromoEvalEngine();
            engine.LoadShoppingCart(Factory.CreateShoppingCart());

            Assert.NotNull(engine.Cart);
        }

        [Fact]
        public void ShouldHavePromoRulesAfterLoading()
        {
            IPromoEvalEngine engine = Factory.CreatePromoEvalEngine();
            engine.LoadPromoRules(new List<IPromotion>());

            Assert.NotNull(engine.Rules);
        }
    }
}
