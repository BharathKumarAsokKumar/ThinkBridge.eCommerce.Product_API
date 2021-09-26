using CoreNLogText;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkBridge.eCommerce.Entity.DAL
{
    public class ProductDAL : ControllerBase
    {
        private readonly DBProductContext dBProductContext;
        public ProductDAL(DBProductContext dbContext)
        {
            dBProductContext = dbContext;
        }

        public  List<Product> GetProductDetails(Product productDet)
        {
            List<Product> product = new List<Product>();

            try
            {
                using (dBProductContext)
                {
                    product = dBProductContext.Products.Where(w => w.Name.Contains(productDet.Name)).ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
            return  product;
        }

        public List<Product> GetProductDetails()
        {
            List<Product> product = new List<Product>();

            try
            {
                using (dBProductContext)
                {
                    product = dBProductContext.Products.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return product;
        }

        public int AddProductetails(List<Product> productDet)
        {
            try
            {
                using (dBProductContext)
                {
                    foreach (Product prod in productDet)
                    {
                        if (dBProductContext.Products.Where(w => w.Name == prod.Name).FirstOrDefault() == null)
                        {
                            dBProductContext.Products.Add(prod);
                        }
                    }
                                        dBProductContext.SaveChanges();
                }
                return 1;

            }
            catch(Exception e)
            {
                return 0;
                throw e;
            }
        }

        public int RemoveProductDetails(int id)
        {
            try
            {
                Product product = new Product();
                using (dBProductContext)
                {
                    product = dBProductContext.Products.Where(w => w.Id == id).FirstOrDefault();
                    if (product != null)
                    {
                        dBProductContext.Products.Remove(product);
                        dBProductContext.SaveChanges();
                    }
                }
                return 1;
            }
            catch(Exception e)
            {
                return 0;
                throw e;
            }
        }

        public int UpdateProductDetails(int id, Product productDet)
        {
            try
            {
                using (dBProductContext)
                {
                    var product = dBProductContext.Products.Where(w => w.Id == id).FirstOrDefault();

                    if (product != null)
                    {
                        product.Price = productDet.Price;
                        product.Name = productDet.Name;
                        product.Description = productDet.Description;
                    }

                    dBProductContext.SaveChanges();
                    return 1;
                }
            }
            catch(Exception e)
            {
                return 0;
                throw e;
            }
        }


    }
}
