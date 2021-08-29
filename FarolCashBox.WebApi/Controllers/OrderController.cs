using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarolCashBox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public Task<GenericCommandResult<CreateOrderResponse>> CreateOrder(
            [FromBody] CreateOrderRequest request)
            => _mediator.Send(request);
    }
}
