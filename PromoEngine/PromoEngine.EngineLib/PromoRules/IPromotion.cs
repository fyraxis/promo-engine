using PromoEngine.EngineLib.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.PromoRules
{
    public interface IPromotion
    {
        public int Priority { get; set; }
        public bool IsApplied { get; }
        public int TimesApplied { get; }

        public void ApplyToCart(IShoppingCart cart);

        public decimal GetTotalPromoAmount();

        public bool CheckRuleValid();
    }
}