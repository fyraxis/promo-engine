using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoEngine.EngineLib.Product
{
    public class ShoppingItem : IShoppingItem
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public void LoadItemData(string code, decimal price, int quantity)
        {
            Code = code;
            Price = price;
            Quantity = quantity;
        }
    }
}
