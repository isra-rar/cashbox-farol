using System;
using FarolCashBox.Domain.Commands.Contracts;

namespace FarolCashBox.Domain.Commands.Response
{
    public class CreateProductResponse : ICommandResult
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public string ProductType { get; set; }
    }
}