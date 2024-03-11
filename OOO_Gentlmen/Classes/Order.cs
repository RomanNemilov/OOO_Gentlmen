using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Gentlmen.Classes
{
    
    public class Order
    {
        public List<ProductInOrder> Products { get; set; } = new List<ProductInOrder>();

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (ProductInOrder productInOrder in Products)
                {
                    total += productInOrder.ProductExtended.ProductCost * productInOrder.Count;
                }
                return total;
            }
        }

        public decimal Discount
        {
            get
            {
                decimal discount = 0;
                foreach (ProductInOrder productInOrder in Products)
                {
                    discount += (decimal)productInOrder.ProductExtended.ProductDiscountRub * productInOrder.Count;
                }
                return discount;
            }
        }

        public decimal TotalWithDiscount => Total - Discount;

        public void AddProduct(ProductExtended product)
        {
            ProductInOrder productInOrder = FindProduct(product);
            if (productInOrder == null)
            {
                Products.Add(new ProductInOrder(product));
            }
            else
            {
                productInOrder.Count++;
                Console.WriteLine(productInOrder.Count);
            }
        }

        public void RemoveProduct(ProductExtended product)
        {
            ProductInOrder productInOrder = FindProduct(product);
            Products.Remove(productInOrder);
        }

        public ProductInOrder FindProduct(ProductExtended product)
        {
            return Products.FirstOrDefault(productInOrder => productInOrder.ProductExtended.ProductName == product.ProductName);
        }

        public bool RemoveEmptyProducts()
        {
            bool removed = false;
            while (Products.FirstOrDefault(productInOrder => productInOrder.Count == 0) != null)
            {
                Products.Remove(Products.FirstOrDefault(productInOrder => productInOrder.Count == 0));
                removed = true;
            }
            return removed;
        }

        public void Clear()
        {
            Products.Clear();
        }
    }
    
}
