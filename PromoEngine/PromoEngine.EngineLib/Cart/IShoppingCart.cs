using PromoEngine.EngineLib.Product;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.Cart
{
    public interface IShoppingCart
    {
        public decimal TotalCartValue { get; }
        public IEnumerable<IShoppingItem> Items { get; }

        public IEnumerable<IPromotion> PromotionsApplied { get; }

        public void LoadShoppingItems(IEnumerable<IShoppingItem> cartItems);
    }
}
