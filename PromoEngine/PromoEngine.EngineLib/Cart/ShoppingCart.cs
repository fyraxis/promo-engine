using PromoEngine.EngineLib.Product;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.Cart
{
    public class ShoppingCart : IShoppingCart
    {
        public decimal TotalCartValue => Items.Sum(i => i.Price * i.Quantity);

        public decimal TotalCartValuePostPromoProcess => TotalCartValue + PromotionsApplied.Sum(p => p.GetTotalPromoAmount());

        public IEnumerable<IShoppingItem> Items { get; private set; }

        public IEnumerable<IPromotion> PromotionsApplied { get; private set; }

        public ShoppingCart()
        {
            Items = new List<IShoppingItem>();
            PromotionsApplied = new List<IPromotion>();
        }

        public void LoadShoppingItems(IEnumerable<IShoppingItem> cartItems)
        {
            Items = cartItems;
        }

        public void RegisterAppliedPromotion(IPromotion promo)
        {
            PromotionsApplied = PromotionsApplied.Append(promo);
        }
    }
}
