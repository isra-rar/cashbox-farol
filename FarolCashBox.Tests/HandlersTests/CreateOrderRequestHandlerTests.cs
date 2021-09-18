using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Handlers;
using FarolCashBox.Domain.Repositories;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace FarolCashBox.Tests.HandlersTests
{
    public class CreateOrderRequestHandlerTests
    {
        private readonly CreateOrderRequestHandler _sut;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderRequestHandlerTests()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _sut = new CreateOrderRequestHandler(_orderRepository, _productRepository, _mapper);
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
            var productsReturn = new List<Product>
            {   new Product(default, 5, default, default),
                new Product(default, 10, default, default),
                new Product(default, 15, default, default),
                new Product(default, 20, default, default)
            };

            _productRepository.GetProductsByIds(products).Returns(productsReturn);

            var request = new CreateOrderRequest(products, Domain.Enums.EPaymentType.DEBIT, default);

            // Act
            var result = await _sut.Handle(request, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
            //result.Value.TotalOrder.Should().Be(50); COMO CONSIGO VALIDAR ISSOOO?!?! // FAZER TESTE DE MODEL DO ORDER SEPARADO
            _orderRepository.Received().Create(Arg.Any<Order>());
        }
    }
}
