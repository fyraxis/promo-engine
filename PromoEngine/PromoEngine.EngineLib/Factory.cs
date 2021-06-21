using PromoEngine.EngineLib.Engine;
using PromoEngine.EngineLib.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoEngine.EngineLib.Product;
using PromoEngine.EngineLib.PromoRules;

namespace PromoEngine.EngineLib
{
    public static class Factory
    {
        public static IPromoEvalEngine CreatePromoEvalEngine() => new PromoEvalEngine();

        public static IShoppingCart CreateShoppingCart() => new ShoppingCart();

        public static IShoppingItem CreateShoppingItem() => new ShoppingItem();

        public static IPromoItem CreatePromoItem() => new PromoItem();

        public static IFixedValuePromotionSinglePack CreateSinglePackFixPricePromoRule() => new PromoSinglePackFixPrice();

        public static IFixedValuePromotionMultiPack CreateMultiPackFixPricePromoRule() => new PromoMultiPackFixPrice();

    }
}
