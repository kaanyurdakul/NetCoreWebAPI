using NetCoreWebAPI.Entities;
using NetCoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI.DataAccess
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NortwindContext>, IProductDal
    {
        public List<ProductModel> GetProductWithDetails()
        {
            using (NortwindContext context = new NortwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductModel
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice
                             };
                return result.ToList();
            }
        }
    }
}
