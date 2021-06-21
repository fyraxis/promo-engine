using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.PromoRules
{
    interface IFixedValuePromotion : IPromotion
    {
        public decimal FixedPromoValue { get; set; }
    }
}
