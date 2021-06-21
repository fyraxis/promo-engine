using PromoEngine.EngineLib;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromoEngine.Tests
{
    public class PromoTests
    {
        [Fact]
        public void ShouldNotBeValidForNewRuleWithoutConfig()
        {
            bool expected = false;

            IPromotion promoRule = Factory.CreateSinglePackFixPricePromoRule();
            bool actual = promoRule.CheckRuleValid();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldNotBeValidForNewRuleWithoutItemSet()
        {
            bool expected = false;

            IFixedValuePromotion promoRule = Factory.CreateSinglePackFixPricePromoRule();
            promoRule.Priority = 1;
            promoRule.FixedPromoValue = 30;
            bool actual = promoRule.CheckRuleValid();

            Assert.Equal(expected, actual);
        }
    }
}
