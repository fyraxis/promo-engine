using PromoEngine.EngineLib.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.PromoRules
{
    public interface IFixedValuePromotionSinglePack : IFixedValuePromotion
    {
        public IPromoItem Item { get; set; }
    }
}
