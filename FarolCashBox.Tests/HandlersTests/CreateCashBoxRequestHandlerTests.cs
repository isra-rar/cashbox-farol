using AutoMapper;
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
        private readonly ICashBoxRepository _cashBoxReposity;
        private readonly IMapper _mapper;

        public CreateCashBoxRequestHandlerTests()
        {
            _cashBoxReposity = Substitute.For<ICashBoxRepository>();
            _mapper = Substitute.For<IMapper>();
            _sut = new CreateCashBoxRequestHandler(_cashBoxReposity, _mapper);
        }

        [Fact]
        public async Task Handler_Create_CashBox_Valid_Should_Return_True()
        {
            // Arrange
            var request = new CreateCashBoxRequest();

            // Act
            var result = await _sut.Handle(request, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
            _cashBoxReposity.Received().Create(Arg.Any<CashBox>());
        }

    }
}
