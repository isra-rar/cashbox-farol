using System;
using System.Collections.Generic;
using System.Linq;
using FarolCashBox.Domain.Enums;

namespace FarolCashBox.Domain.Entities
{
    public class Order : EntityBase
    {
        private IList<Product> _products;
        public Order(Guid cashBoxId)
        {
            CashBoxId = cashBoxId;
            _products = new List<Product>();
        }

        public IEnumerable<Product> Products { get { return _products.ToArray(); } }
        public decimal TotalOrder { get { return GenerateTotalOrder(); } private set { } }
        public EPaymentType PaymentType { get; private set; }
        public Guid CashBoxId { get; private set; }
        public CashBox CashBox { get; private set; }

        public void AddProduct(List<Product> products)
        {
            products.AddRange(products);
        }

        public decimal GenerateTotalOrder()
        {
            return _products.Select(x => x.Value).Sum();
        }

    }
}