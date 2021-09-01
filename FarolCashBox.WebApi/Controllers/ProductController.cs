using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Enums;
using FarolCashBox.Domain.Expections;
using FarolCashBox.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarolCashBox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        public ProductController(IMediator mediator)
            : base (mediator) { }

        //[HttpGet("productsByFilter/{productType}")]
        //public IEnumerable<Product> GetAllProductsByType(string productType) 
        //    => _productRepository.GetAllProductsByType(productType);

        [HttpPost]
        public async Task<IActionResult> CreateProduct(
            [FromBody] CreateProductRequest request) 
            => await SendRequest(request).ConfigureAwait(false);
    }
}
