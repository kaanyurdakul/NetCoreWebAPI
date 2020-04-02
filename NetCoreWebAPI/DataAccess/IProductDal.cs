using NetCoreWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
