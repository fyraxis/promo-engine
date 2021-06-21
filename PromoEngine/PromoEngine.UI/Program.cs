using PromoEngine.EngineLib;
using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.Engine;
using PromoEngine.EngineLib.Product;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PromoEngine.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RunShoppingCartPromoEvalScenario1();
            RunShoppingCartPromoEvalScenario2();
            RunShoppingCartPromoEvalScenario3();
        }

        private static void RunShoppingCartPromoEvalScenario1()
        {
            IShoppingCart cart;
            IPromoEvalEngine engine;
            List<IPromotion> rules;
            LoadShoppingCartDataForScenario1(out cart);
            LoadPromoRules(out rules);
            InitPromoEngine(out engine, cart, rules);

            Console.WriteLine($"For scenario 1 the cart total value before promo application is ${cart.TotalCartValuePostPromoProcess}");
            ProcessCartContents(engine);

            Console.WriteLine($"For scenario 1 the cart total value after promo application is ${cart.TotalCartValuePostPromoProcess}");
        }

        private static void RunShoppingCartPromoEvalScenario2()
        {
            IShoppingCart cart;
            IPromoEvalEngine engine;
            List<IPromotion> rules;
            LoadShoppingCartDataForScenario2(out cart);
            LoadPromoRules(out rules);
            InitPromoEngine(out engine, cart, rules);

            Console.WriteLine($"For scenario 2 the cart total value before promo application is ${cart.TotalCartValuePostPromoProcess}");
            ProcessCartContents(engine);

            Console.WriteLine($"For scenario 2 the cart total value after promo application is ${cart.TotalCartValuePostPromoProcess}");
        }

        private static void RunShoppingCartPromoEvalScenario3()
        {
            IShoppingCart cart;
            IPromoEvalEngine engine;
            List<IPromotion> rules;
            LoadShoppingCartDataForScenario3(out cart);
            LoadPromoRules(out rules);
            InitPromoEngine(out engine, cart, rules);
            Console.WriteLine($"For scenario 3 the cart total value before promo application is ${cart.TotalCartValuePostPromoProcess}");
            ProcessCartContents(engine);

            Console.WriteLine($"For scenario 3 the cart total value after promo application is ${cart.TotalCartValuePostPromoProcess}");
        }

        private static void LoadShoppingCartDataForScenario1(out IShoppingCart cart)
        {
            cart = Factory.CreateShoppingCart();
            IShoppingItem item1, item2, item3;
            item1 = Factory.CreateShoppingItem();
            item1.LoadItemData("A", 50, 1);

            item2 = Factory.CreateShoppingItem();
            item2.LoadItemData("B", 30, 1);

            item3 = Factory.CreateShoppingItem();
            item3.LoadItemData("C", 20, 1);

            IEnumerable<IShoppingItem> items = new List<IShoppingItem>() { item1, item2, item3 };
            cart.LoadShoppingItems(items);
        }

        private static void LoadShoppingCartDataForScenario2(out IShoppingCart cart)
        {
            cart = Factory.CreateShoppingCart();
            IShoppingItem item1, item2, item3;
            item1 = Factory.CreateShoppingItem();
            item1.LoadItemData("A", 50, 5);

            item2 = Factory.CreateShoppingItem();
            item2.LoadItemData("B", 30, 5);

            item3 = Factory.CreateShoppingItem();
            item3.LoadItemData("C", 20, 1);

            IEnumerable<IShoppingItem> items = new List<IShoppingItem>() { item1, item2, item3 };
            cart.LoadShoppingItems(items);
        }

        private static void LoadShoppingCartDataForScenario3(out IShoppingCart cart)
        {
            cart = Factory.CreateShoppingCart();
            IShoppingItem item1, item2, item3, item4;
            item1 = Factory.CreateShoppingItem();
            item1.LoadItemData("A", 50, 3);

            item2 = Factory.CreateShoppingItem();
            item2.LoadItemData("B", 30, 5);

            item3 = Factory.CreateShoppingItem();
            item3.LoadItemData("C", 20, 1);

            item4 = Factory.CreateShoppingItem();
            item4.LoadItemData("D", 15, 1);

            IEnumerable<IShoppingItem> items = new List<IShoppingItem>() { item1, item2, item3, item4 };
            cart.LoadShoppingItems(items);
        }

        private static void LoadPromoRules(out List<IPromotion> rules)
        {
            IPromoItem item1 = Factory.CreatePromoItem();
            item1.LoadItemData("A", 3);
            IFixedValuePromotionSinglePack rule1 = Factory.CreateSinglePackFixPricePromoRule();
            rule1.Priority = 1;
            rule1.FixedPromoValue = 130;
            rule1.Item = item1;

            IPromoItem item2 = Factory.CreatePromoItem();
            item2.LoadItemData("B", 2);
            IFixedValuePromotionSinglePack rule2 = Factory.CreateSinglePackFixPricePromoRule();
            rule2.Priority = 2;
            rule2.FixedPromoValue = 45;
            rule2.Item = item2;

            IPromoItem item3 = Factory.CreatePromoItem();
            item3.LoadItemData("C", 1);
            IPromoItem item4 = Factory.CreatePromoItem();
            item4.LoadItemData("D", 1);
            IFixedValuePromotionMultiPack rule3 = Factory.CreateMultiPackFixPricePromoRule();
            rule3.Priority = 3;
            rule3.FixedPromoValue = 30;
            rule3.Items = new List<IPromoItem>() { item3, item4 };

            rules = new List<IPromotion>() { rule1, rule2, rule3 };
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
