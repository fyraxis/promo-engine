using PromoEngine.EngineLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.PromoRules
{
    public interface IFixedValuePromotionMultiPack  : IFixedValuePromotion
    {
        public IEnumerable<IPromoItem> Items { get; set; }
    }
}
