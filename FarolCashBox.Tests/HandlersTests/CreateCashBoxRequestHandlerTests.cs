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
    public class CreateCashBoxRequestHandlerTests
    {
        private readonly CreateCashBoxRequestHandler _sut;
        private readonly IRepository<CashBox> _cashBoxReposity;

        public CreateCashBoxRequestHandlerTests()
        {
            _cashBoxReposity = Substitute.For<IRepository<CashBox>>();
            _sut = new CreateCashBoxRequestHandler(_cashBoxReposity);
        }

        [Fact]
        public async Task Handler_Create_CashBox_Valid_Should_Return_True()
        {
            // Arrange
            var request = new CreateCashBoxRequest();

            // Act
            var result = await _sut.Handle(request, default);

            // Assert
            result.Sucess.Should().BeTrue();
            result.Code.Should().Be(200);
            result.Data.Should().BeOfType(typeof(CreateCashBoxResponse));
            _cashBoxReposity.Received().Create(Arg.Any<CashBox>());
        }

    }
}
