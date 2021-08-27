using FarolCashBox.Domain.Commands.Contracts;
using System;

namespace FarolCashBox.Domain.Commands.Response
{
    public class CreateCashBoxResponse : ICommandResult
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
