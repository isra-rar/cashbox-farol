using FarolCashBox.Domain.Entities;
using FarolCashBox.Infra.Context;
using FarolCashBox.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

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
    }
}
