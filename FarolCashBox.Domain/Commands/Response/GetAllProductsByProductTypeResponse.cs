using FarolCashBox.Domain.Commands.Contracts;
using System;

namespace FarolCashBox.Domain.Commands.Response
{
    public class GetAllProductsByProductTypeResponse : ICommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public string ProductType { get; set; }
    }
}
