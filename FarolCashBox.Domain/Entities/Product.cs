using FarolCashBox.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FarolCashBox.Domain.Entities
{
    public class Product : EntityBase
    {
        private IList<Order> _orders;
        public Product(string name, decimal value, int quantity, EProductType productType)
        {
            Name = name;
            Value = value;
            Quantity = quantity;
            ProductType = productType;
            _orders = new List<Order>();
        }

        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public int Quantity { get; private set; }
        public EProductType ProductType { get; private set; }
        [JsonIgnore]
        public IEnumerable<Order> Orders { get { return _orders.ToArray(); } }
    }
}