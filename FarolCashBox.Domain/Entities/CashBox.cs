using System.Collections.Generic;
using System.Linq;

namespace FarolCashBox.Domain.Entities
{
    public class CashBox : EntityBase
    {
        private IList<Order> _orders;
        public CashBox()
        {
            _orders = new List<Order>();
        }

        public IList<Order> Orders { get { return _orders.ToArray(); } }
        public decimal TotalAmount { get { return GenerateTotalCashBox(); } private set { } }

        public decimal GenerateTotalCashBox()
        {
            return _orders.Select(x => x.TotalOrder).Sum();
        }
    }
}