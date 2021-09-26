using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using ThinkBridge.eCommerce.Entity;
using ThinkBridge.eCommerce.Entity.DAL;

namespace ThinkBridge.eCommerce.ProductTest
{
    [Binding]
    public class ProductSteps
    {
        
         ProductDAL productDAL;
        private int result = 0;
        private List<Product> products = new List<Product>();
        private static IConfiguration configuration;

        public ProductSteps()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json", false, true)
                .Build();
            productDAL = new ProductDAL(new DBProductContext(configuration.GetConnectionString("ProductDB")));
        }

        [Given(@"the user has  new product")]
        public void GivenTheUserHasNewProduct()
        {
        }
        [When(@"the user adds new product")]
        public void WhenTheUserAddsNewProduct(Table table)
        {
            List<Product> addProd = new List<Product>();
            for (int i = 0; i < table.RowCount; i++)
            {
                Product prod = new Product();
                prod.Description = table.Rows[i]["Description"];
                prod.Name = table.Rows[i]["Name"];
                prod.Price = table.Rows[i]["Price"];
                prod.Id = Convert.ToInt32(table.Rows[i]["Id"]);
                addProd.Add(prod);
            }
            result = productDAL.AddProductetails(addProd);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Assert.AreEqual(p0, result);
        }
        [Given(@"the user has wish to see all products")]
        public void GivenTheUserHasWishToSeeAllProducts()
        {
        }
        
        [Given(@"the user has product Name")]
        public void GivenTheUserHasProductName()
        {
        }
        
        [Given(@"the user has product Name to be updated")]
        public void GivenTheUserHasProductNameToBeUpdated()
        {
        }
        
        [Given(@"the user has product Name to be removed")]
        public void GivenTheUserHasProductNameToBeRemoved()
        {
        }
        
        [When(@"the user search all product")]
        public void WhenTheUserSearchAllProduct()
        {
            products = productDAL.GetProductDetails();
        }

        [When(@"the user search a product")]
        public void WhenTheUserSearchAProduct(Table table)
        {
            
                Product prod = new Product();
                prod.Name = table.Rows[0]["Name"];
                prod.Id = Convert.ToInt32(table.Rows[0]["Id"]);
            
            products = productDAL.GetProductDetails(prod);
        }

        [When(@"the user Updates a product")]
        public void WhenTheUserUpdatesAProduct(Table table)
        {
            Product Prod = new Product();

            Prod.Id = Convert.ToInt32(table.Rows[0]["Id"]);
            Prod.Name = table.Rows[0]["Name"];

            result = productDAL.UpdateProductDetails(Prod.Id,Prod);
        }
        [When(@"the user removes a product")]
        public void WhenTheUserRemovesAProduct(Table table)
        {
            result = productDAL.RemoveProductDetails(Convert.ToInt32(table.Rows[0]["Id"]));
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            List<Product> addProd = new List<Product>();
            for (int i = 0; i < table.RowCount; i++)
            {
                Product prod = new Product();
                prod.Description = table.Rows[i]["Description"];
                prod.Name = table.Rows[i]["Name"];
                prod.Price = table.Rows[i]["Price"];
                prod.Id = Convert.ToInt32(table.Rows[i]["Id"]);
                addProd.Add(prod);
            }
            Assert.AreEqual(addProd.Count, products.Count);
        }

            [Then(@"the successfull updates represents result as (.*)")]
        public void ThenTheSuccessfullUpdatesRepresentsResultAs(int p0)
        {
            Assert.AreEqual(p0, result);
        }
        
        [Then(@"the successfull delete of product represents result as (.*)")]
        public void ThenTheSuccessfullDeleteOfProductRepresentsResultAs(int p0)
        {
            Assert.AreEqual(p0, result);
        }
    }
}
