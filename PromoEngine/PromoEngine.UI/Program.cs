using PromoEngine.EngineLib;
using System;

namespace PromoEngine.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart;
            PromoEvalEngine engine;
            LoadShoppingCartData(out cart);
            InitPromoEngine(out engine);
            ProcessCartContents(engine, cart);
        }

        private static void LoadShoppingCartData(out ShoppingCart cart)
        {
            cart = new ShoppingCart();
        }

        private static void InitPromoEngine(out PromoEvalEngine engine)
        {
            engine = new PromoEvalEngine();
        }

        private static void ProcessCartContents(PromoEvalEngine engine, ShoppingCart cart)
        {
            
        }
    }
}
