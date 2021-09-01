using FarolCashBox.Domain.Expections;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarolCashBox.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> SendRequest<T>(IRequest<Result<T>> request, int statusCode = StatusCodes.Status200OK) where T : class
        {
            try
            {
                var (isSuccess, value, exception) = await _mediator.Send(request).ConfigureAwait(false);

                if (!isSuccess)
                    return HandleError(exception);
                else if (value is null)
                    return new NoContentResult();
                else
                    return new ObjectResult(value) { StatusCode = statusCode };

            }
            catch (Exception exception)
            {
                return HandleError(exception);
            }
        }

        private IActionResult HandleError(Exception exception)
        {
            IActionResult response;

            switch (exception)
            {
                case InvalidModelException invalidModelException:
                    response = new BadRequestObjectResult(invalidModelException.Notifications);
                    break;
                default:
                    response = StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
                    break;
            }

            return response;
        }
    }
}
