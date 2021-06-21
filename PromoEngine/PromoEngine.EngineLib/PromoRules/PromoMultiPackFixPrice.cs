using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.PromoRules
{
    public class PromoMultiPackFixPrice : IFixedValuePromotionMultiPack
    {
        public decimal FixedPromoValue { get; set; }
        public int Priority { get; set; }

        public bool IsApplied { get; private set; }

        public int TimesApplied { get; private set; }

        public IEnumerable<IPromoItem> Items { get; set; } = new List<IPromoItem>();

        public void ApplyToCart(IShoppingCart cart)
        {
            IEnumerable<IShoppingItem> cartItems = cart.Items.Where(i => Items.Select(p => p.Code).Contains(i.Code));

            if (cartItems.Count() != Items.Count())
                return;

            int applications = int.MaxValue;
            foreach (var item in cartItems)
            {
                applications = Math.Min(applications, item.Quantity / Items.FirstOrDefault(p => p.Code == item.Code).Quantity);
            }

            IsApplied = applications != 0;
            TimesApplied = applications;

            if (IsApplied)
            {
                foreach (var item in cartItems)
                {
                    item.Quantity -= applications * Items.FirstOrDefault(p => p.Code == item.Code).Quantity;
                }
                cart.RegisterAppliedPromotion(this);
            }
        }

        public bool CheckRuleValid()
        {
            if (Items == null || Items.Count() == 0)
                return false;
            if (Items.Any(i => i.Quantity <= 0))
                return false;
            if (Priority < 0)
                return false;

            return true;
        }

        public decimal GetTotalPromoAmount() => TimesApplied * FixedPromoValue;
    }
}
