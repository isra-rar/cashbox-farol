using System;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Repositories;
using FarolCashBox.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FarolCashBox.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context) => _context = context;

        public void Create(Order entity)
        {
            foreach (var product in entity.Products)
            {
                _context.Products.Attach(product);

            }
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var order = _context.Orders.Find(id);
            _context.Remove(order);
            _context.SaveChanges();
        }

        public void Update(Order entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
