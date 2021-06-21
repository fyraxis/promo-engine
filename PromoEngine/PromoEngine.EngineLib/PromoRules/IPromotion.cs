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
        public bool IsApplied { get; set; }
        public int TimesApplied { get; set; }

        public void ApplyToCart(IShoppingCart cart);

        public decimal GetTotalPromoAmount();
    }
}