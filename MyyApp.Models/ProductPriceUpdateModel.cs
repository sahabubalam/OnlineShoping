using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyyApp.Models
{
    public class ProductPriceUpdateModel
    {
        public int price { get; set; }
        public int ProductId { get; set; }
        public List<Product> products { get; set; }
    }
    public class ProductQuantityUpdateModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public List<Product> products { get; set; }
    }
}
