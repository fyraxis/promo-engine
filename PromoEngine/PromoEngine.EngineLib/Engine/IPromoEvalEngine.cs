using PromoEngine.EngineLib.Cart;
using PromoEngine.EngineLib.PromoRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.Engine
{
    public interface IPromoEvalEngine
    {

        public IShoppingCart Cart { get; }
        public IEnumerable<IPromotion> Rules { get; }
        public void LoadShoppingCart(IShoppingCart cart);
        public void LoadPromoRules(IEnumerable<IPromotion> rules);

        public void ProcessShoppingCart();
    }
}
