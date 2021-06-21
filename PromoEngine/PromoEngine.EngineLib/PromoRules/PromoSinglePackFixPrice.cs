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
        public bool IsApplied { get; private set; }
        public int TimesApplied { get; private set; }

        public IPromoItem Item { get; set; }
        public decimal FixedPromoValue { get; set; }

        public void ApplyToCart(IShoppingCart cart)
        {
            IShoppingItem cartItem = cart.Items.FirstOrDefault(i => i.Code == Item.Code);

            if(cartItem == null)
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
            cart.RegisterAppliedPromotion(this);
        }

        public bool CheckRuleValid()
        {
            if (Item == null)
                return false;
            if (Item.Quantity <= 0)
                return false;
            if (FixedPromoValue <= 0)
                return false;
            if (Priority < 0)
                return false;

            return true;
        }

        public decimal GetTotalPromoAmount() => TimesApplied * FixedPromoValue;
        
    }
}
