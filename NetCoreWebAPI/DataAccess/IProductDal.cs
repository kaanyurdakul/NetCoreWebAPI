using NetCoreWebAPI.Entities;
using NetCoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductModel> GetProductWithDetails();
    }
}
