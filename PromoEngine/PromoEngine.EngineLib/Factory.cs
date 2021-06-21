using PromoEngine.EngineLib.Engine;
using PromoEngine.EngineLib.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib
{
    public static class Factory
    {
        public static IPromoEvalEngine CreatePromoEvalEngine() => new PromoEvalEngine();

        public static IShoppingCart CreateShoppingCart() => new ShoppingCart();

    }
}
