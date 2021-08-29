﻿using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Repositories;
using FarolCashBox.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarolCashBox.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) => _context = context;

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.Find(id);
            _context.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Product> GetProductsByIds(List<Guid> ids)
        {
            return _context.Products.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}
