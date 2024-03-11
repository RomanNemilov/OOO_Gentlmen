using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Gentlmen.Classes
{
    public class ProductExtended : Model.Product
    {

        public ProductExtended(Model.Product product)
        {
            ProductArticle = product.ProductArticle;
            ProductName = product.ProductName;
            ProductCost = product.ProductCost;
            ProductManufacturer = product.ProductManufacturer;
            ProductCategory = product.ProductCategory;
            ProductDiscount = product.ProductDiscount;
            ProductDescription = product.ProductDescription;
            ProductPhoto = product.ProductPhoto;
        }
        public string ProductPhotoCorrected
        {
            get
            {
                string file = Environment.CurrentDirectory + "/Images/" + ProductPhoto;
                if (File.Exists(file))
                {
                    return file;
                }
                else
                {
                    return "/Resources/logo.png";
                }
            }
        }

        public decimal ProductCostWithDiscount
        {
            get
            {
                return ProductCost - ProductDiscountRub;
            }
        }

        public decimal ProductDiscountRub
        {
            get
            {
                return ProductCost * (ProductDiscount / 100);
            }
        }
    }
}
