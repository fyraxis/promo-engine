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
        public void ApplyToCart(IShoppingCart cart);
    }
}