using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsByIds(List<Guid> ids);
        IEnumerable<Product> GetAllProductsByType(EProductType productType);
    }
}
