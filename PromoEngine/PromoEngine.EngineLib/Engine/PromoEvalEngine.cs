using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.Engine
{
    public class PromoEvalEngine : IPromoEvalEngine
    {
        public IShoppingCart Cart { get; private set; }

        public IEnumerable<IPromotion> Rules { get; private set; }

        public void LoadPromoRules(IEnumerable<IPromotion> rules)
        {
            Rules = rules;
        }

        public void LoadShoppingCart(IShoppingCart cart)
        {
            Cart = cart;
        }

        public void ProcessShoppingCart()
        {
            foreach (var promo in Rules.OrderBy(p => p.Priority))
            {
                if (promo.CheckRuleValid() == false)
                    continue;
                promo.ApplyToCart(Cart);
            }
        }
    }
}
