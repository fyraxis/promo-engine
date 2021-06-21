using PromoEngine.EngineLib;
using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.Engine;
using PromoEngine.EngineLib.Product;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Collections.Generic;

namespace PromoEngine.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IShoppingCart cart;
            IPromoEvalEngine engine;
            List<IPromotion> rules;
            LoadShoppingCartData(out cart);
            LoadPromoRules(out rules);
            InitPromoEngine(out engine, cart, rules);
            ProcessCartContents(engine);
        }

        private static void LoadShoppingCartData(out IShoppingCart cart)
        {
            cart = Factory.CreateShoppingCart();
            IEnumerable<IShoppingItem> items = new List<IShoppingItem>();
            cart.LoadShoppingItems(items);
        }

        private static void LoadPromoRules(out List<IPromotion> rules)
        {
            rules = new List<IPromotion>();
        }

        private static void InitPromoEngine(out IPromoEvalEngine engine, IShoppingCart cart, List<IPromotion> rules)
        {
            engine = Factory.CreatePromoEvalEngine();
            engine.LoadPromoRules(rules);
            engine.LoadShoppingCart(cart);
        }

        private static void ProcessCartContents(IPromoEvalEngine engine)
        {
            engine.ProcessShoppingCart();
        }
    }
}
