﻿using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarolCashBox.Infra.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
