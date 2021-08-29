using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Handlers;
using FarolCashBox.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FarolCashBox.Tests.HandlersTests
{
    public class CreateOrderRequestHandlerTests
    {
        private readonly CreateOrderRequestHandler _sut;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderRequestHandlerTests()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _sut = new CreateOrderRequestHandler(_orderRepository, _productRepository);
        }

        [Fact]
        public async Task Handler_Create_Order_And_Valid_TotalOrder_IsSucess()
        {
            // Arrange
            var products = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
            };
            _productRepository.GetProductsByIds(products).Returns(new List<Product>
            {   new Product(default, 5, default, default),
                new Product(default, 10, default, default),
                new Product(default, 15, default, default),
                new Product(default, 20, default, default),
            });
            var request = new CreateOrderRequest(products, Domain.Enums.EPaymentType.DEBIT, default);

            // Act
            var result = await _sut.Handle(request, default);

            // Assert
            result.Sucess.Should().BeTrue();
            result.Code.Should().Be(200);
            result.Data.Should().BeOfType(typeof(CreateOrderResponse));
            result.Data.As<CreateOrderResponse>().TotalOrder.Should().Be(50);
            _orderRepository.Received().Create(Arg.Any<Order>());
        }
    }
}
