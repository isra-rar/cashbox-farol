using System.Threading;
using System.Threading.Tasks;
using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Repositories;
using Flunt.Notifications;
using MediatR;

namespace FarolCashBox.Domain.Handlers
{
    public class CreateProductRequestHandler : Notifiable<Notification>, IRequestHandler<CreateProductRequest, GenericCommandResult<CreateProductResponse>>
    {
        private readonly IRepository<Product> _productReposity;

        public CreateProductRequestHandler(IRepository<Product> productReposity)
        {
            _productReposity = productReposity;
        }

        public async Task<GenericCommandResult<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (!request.IsValid)
            {
                var failValidation = new GenericCommandResult<CreateProductResponse>(false, "Dados Invalidos", request.Notifications, 400);
                return await Task.FromResult(failValidation);
            }

            var product = new Product(request.Name, request.Value, request.Quantity, request.ProductType);

            _productReposity.Create(product);

            var result = new GenericCommandResult<CreateProductResponse>(true, "Produto criado com sucesso",
            new CreateProductResponse
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Name = product.Name,
                Value = product.Value,
                Quantity = product.Quantity,
                ProductType = product.ProductType.ToString()
            });

            return await Task.FromResult(result);
        }
    }
}