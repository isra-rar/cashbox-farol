using FarolCashBox.Domain.Commands.Contracts;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using OperationResult;
using System;
using System.Collections.Generic;

namespace FarolCashBox.Domain.Commands.Requests
{
    public class CreateOrderRequest : Notifiable<Notification>, IRequest<Result<CreateOrderResponse>>, ICommand
    {
        public CreateOrderRequest(List<Guid> productIds, EPaymentType paymentType, Guid cashBoxId)
        {
            ProductIds = productIds;
            PaymentType = paymentType;
            CashBoxId = cashBoxId;
        }

        public List<Guid> ProductIds { get; set; }
        public EPaymentType PaymentType { get; set; }
        public Guid CashBoxId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateOrderRequest>()
                .Requires()
                .IsGreaterThan(ProductIds, 0, "ProductIds", "Lista de Produtos deve contem pelo menos UM Produto")
                .IsNotNull(PaymentType, "PaymentType", "O tipo de pagamento não pode ser NULO")
                .IsNotNull(CashBoxId, "CashBoxId", "O Id do CAIXA não pode ser NULO")
                );
        }
    }
}
