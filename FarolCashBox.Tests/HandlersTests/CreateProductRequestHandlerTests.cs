using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Enums;
using FarolCashBox.Domain.Handlers;
using FarolCashBox.Domain.Repositories;
using FluentAssertions;
using Flunt.Notifications;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FarolCashBox.Tests.EntityTests
{
    public class CreateProductRequestHandlerTests
    {
        private readonly CreateProductRequestHandler _sut;
        private readonly IRepository<Product> _productReposity;

        public CreateProductRequestHandlerTests()
        {
            _productReposity = Substitute.For<IRepository<Product>>();
            _sut = new CreateProductRequestHandler(_productReposity);
        }

        [Fact]
        public async Task Handler_Create_Product_Invalid_Should_Return_False()
        {
            // Arrange
            var request = new CreateProductRequest(default, default, default, default);

            // Act
            var result = await _sut.Handle(request, default);

            // Assert
            result.Sucess.Should().BeFalse();
            result.Code.Should().Be(400);
            result.Data.Should().BeOfType(typeof(List<Notification>));
        }

        [Fact]
        public async Task Handler_Create_Product_Valid_Should_Return_True()
        {
            // Arrange
            var request = new CreateProductRequest("Pastel de frango", (decimal)5.5, 10, EProductType.SAVORY);

            // Act
            var result = await _sut.Handle(request, default);

            // Assert
            result.Sucess.Should().BeTrue();
            result.Code.Should().Be(200);
            result.Data.Should().BeOfType(typeof(CreateProductResponse));
            _productReposity.Received().Create(Arg.Any<Product>());
        }

    }
}
