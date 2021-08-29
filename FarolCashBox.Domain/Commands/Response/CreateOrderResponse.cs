using FarolCashBox.Domain.Commands.Contracts;
using FarolCashBox.Domain.Commands.Response.ViewModels;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Enums;
using System;
using System.Collections.Generic;

namespace FarolCashBox.Domain.Commands.Response
{
    public class CreateOrderResponse : ICommandResult
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal TotalOrder { get; set; }
        public string PaymentType { get; set; }
        public Guid CashBoxId { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
