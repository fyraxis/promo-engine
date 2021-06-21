using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.PromoRules
{
    public class PromoSinglePackFixPrice : IFixedValuePromotion
    {
        public int Priority { get; set; }
        public bool IsApplied { get; set; }
        public int TimesApplied { get; set; }

        public IPromoItem Item { get; set; }
        public decimal FixedPromoValue { get; set; }

        public void ApplyToCart(IShoppingCart cart)
        {
            IShoppingItem cartItem = cart.Items.FirstOrDefault(i => i.Code == Item.Code);

            if(cartItem == null)
            {
                return;
            }

            if(Item.Quantity <= 0)
            {
                return;
            }

            if(cartItem.Quantity < Item.Quantity)
            {
                return;
            }

            int applications = cartItem.Quantity / Item.Quantity;
            IsApplied = true;
            TimesApplied = applications;

            cartItem.Quantity -= applications * Item.Quantity;
        }

        public decimal GetTotalPromoAmount() => TimesApplied * FixedPromoValue;
        
    }
}
