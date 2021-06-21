using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.Product
{
    public class PromoItem : IPromoItem
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
}
