using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.Product
{
    public interface IPromoItem
    {
        string Code { get; set; }
        int Quantity { get; set; }
    }
}