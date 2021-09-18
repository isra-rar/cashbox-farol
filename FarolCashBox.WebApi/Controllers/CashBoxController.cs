using FarolCashBox.Domain.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FarolCashBox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashBoxController : BaseController
    {
        public CashBoxController(IMediator mediator) 
            : base (mediator) { }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(
            [FromBody] CreateCashBoxRequest request)
            => await SendRequest(request).ConfigureAwait(false);
    }
}
