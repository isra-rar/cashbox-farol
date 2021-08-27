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
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public Task<GenericCommandResult<CreateProductResponse>> CreateProduct(
            [FromBody] CreateProductRequest request) 
            => _mediator.Send(request);
    }
}
