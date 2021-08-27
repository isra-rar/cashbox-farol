using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FarolCashBox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashBoxController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CashBoxController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public Task<GenericCommandResult<CreateCashBoxResponse>> CreateProduct(
            [FromBody] CreateCashBoxRequest request)
            => _mediator.Send(request);
    }
}
