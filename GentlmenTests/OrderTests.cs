using NUnit.Framework;
using OOO_Gentlmen.Classes;
using OOO_Gentlmen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GentlmenTests
{
    [TestFixture]
    public class OrderTests
    {
        Order order;
        [SetUp]
        public void Setup()
        {
            order = new Order();
        }

        [Test]
        public void AddProductToOrder()
        {
            //Arrange
            var product = new OOO_Gentlmen.Model.Product();
            ProductExtended productExtended = new ProductExtended(product);
            // Act
            order.AddProduct(productExtended);

            // Assert
            Assert.AreEqual(productExtended, order.Products[0].ProductExtended);
        }

        [Test]
        public void AddProductToOrderMultipleTimes()
        {
            //Arrange
            var product = new OOO_Gentlmen.Model.Product();
            ProductExtended productExtended = new ProductExtended(product);
            // Act
            order.AddProduct(productExtended);
            order.AddProduct(productExtended);

            // Assert
            Assert.AreEqual(1, order.Products.Count);
            Assert.AreEqual(2, order.Products[0].Count);
        }

        [Test]
        public void FindValidProduct()
        {
            //Arrange
            var product1 = new OOO_Gentlmen.Model.Product()
            {
                ProductName = "Tufli"
            };
            var product2 = new OOO_Gentlmen.Model.Product()
            {
                ProductArticle = "Shtani"
            };
            ProductExtended productExtended1 = new ProductExtended(product1);
            ProductExtended productExtended2 = new ProductExtended(product2);
            order.AddProduct(productExtended1);
            order.AddProduct(productExtended2);
            // Act
            ProductInOrder productInOrder = order.FindProduct(productExtended1);

            // Assert
            Assert.AreEqual(productExtended1, productInOrder.ProductExtended);
        }

        [Test]
        public void FindInvalidProduct()
        {
            //Arrange
            var product1 = new OOO_Gentlmen.Model.Product()
            {
                ProductName = "Tufli"
            };
            var product2 = new OOO_Gentlmen.Model.Product()
            {
                ProductArticle = "Shtani"
            };
            ProductExtended productExtended1 = new ProductExtended(product1);
            ProductExtended productExtended2 = new ProductExtended(product2);
            order.AddProduct(productExtended2);
            // Act
            ProductInOrder productInOrder = order.FindProduct(productExtended1);

            // Assert
            Assert.AreEqual(null, productInOrder);
        }

        [Test]
        public void RemoveEmptyProducts()
        {
            //Arrange
            var product1 = new OOO_Gentlmen.Model.Product()
            {
                ProductName = "Tufli"
            };
            var product2 = new OOO_Gentlmen.Model.Product()
            {
                ProductArticle = "Shtani"
            };
            ProductExtended productExtended1 = new ProductExtended(product1);
            ProductExtended productExtended2 = new ProductExtended(product2);
            order.AddProduct(productExtended1);
            order.AddProduct(productExtended2);
            order.Products[0].Count = 0;
            // Act
            order.RemoveEmptyProducts();

            // Assert
            Assert.AreEqual(1, order.Products.Count);
            Assert.AreEqual(productExtended2, order.Products[0].ProductExtended);
        }
    }
}
