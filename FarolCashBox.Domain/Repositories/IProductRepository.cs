﻿using FarolCashBox.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FarolCashBox.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsByIds(List<Guid> ids);
    }
}
