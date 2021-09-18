using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Expections;
using FarolCashBox.Domain.Repositories;
using Flunt.Notifications;
using MediatR;
using OperationResult;

namespace FarolCashBox.Domain.Handlers
{
    public class CreateOrderRequestHandler : Notifiable<Notification>, IRequestHandler<CreateOrderRequest, Result<CreateOrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderRequestHandler(IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<CreateOrderResponse>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (!request.IsValid)
                return new InvalidModelException(request.Notifications.ToList());

            var products = _productRepository.GetProductsByIds(request.ProductIds);
            var order = new Order(request.CashBoxId);
            order.AddProducts(products);

            _orderRepository.Create(order);

            return _mapper.Map<CreateOrderResponse>(order);
        }
    }
}
