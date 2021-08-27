using System;

namespace FarolCashBox.Domain.Entities
{
    public class OrderProduct : EntityBase
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public Order Order { get; private set; }
        public Product Product { get; private set; }
    }
}
