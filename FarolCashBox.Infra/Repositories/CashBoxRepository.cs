using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Repositories;
using FarolCashBox.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarolCashBox.Infra.Repositories
{
    public class CashBoxRepository : ICashBoxRepository
    {
        private readonly DataContext _context;

        public CashBoxRepository(DataContext context) => _context = context;

        public void Create(CashBox entity)
        {
            _context.CashBoxes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _context.CashBoxes.Find(id);
            _context.Remove(product);
            _context.SaveChanges();
        }

        public void Update(CashBox entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
