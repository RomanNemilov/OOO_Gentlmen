using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Gentlmen.Classes
{
    public class ProductInOrder
    {
        public ProductExtended ProductExtended { get; set; }
        public int Count { get; set; }
        public ProductInOrder(ProductExtended productExtended)
        {
            ProductExtended = productExtended;
            Count = 1;
        }
    }
}
