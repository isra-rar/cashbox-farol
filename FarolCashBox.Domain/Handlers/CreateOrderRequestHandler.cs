using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Repositories;
using Flunt.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Handlers
{
    public class CreateOrderRequestHandler : Notifiable<Notification>, IRequestHandler<CreateOrderRequest, GenericCommandResult<CreateOrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderRequestHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<GenericCommandResult<CreateOrderResponse>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (!request.IsValid)
            {
                var failValidation = new GenericCommandResult<CreateOrderResponse>(false, "Dados Invalidos", request.Notifications, 400);
                return await Task.FromResult(failValidation);
            }

            var products = _productRepository.GetProductsByIds(request.ProductIds);
            var order = new Order(request.CashBoxId);
            order.AddProducts(products);

            _orderRepository.Create(order);

            var result = new GenericCommandResult<CreateOrderResponse>(true, "Pedido criado com sucesso",
            new CreateOrderResponse
            {
                Id = order.Id,
                CreationDate = order.CreationDate,
                TotalOrder = order.TotalOrder,
                PaymentType = order.PaymentType.ToString(),
                CashBoxId = order.CashBoxId,
                Products = order.Products
            });

            return await Task.FromResult(result);
        }
    }
}
