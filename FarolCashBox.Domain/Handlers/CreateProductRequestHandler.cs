using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Expections;
using FarolCashBox.Domain.Repositories;
using Flunt.Notifications;
using MediatR;
using OperationResult;

namespace FarolCashBox.Domain.Handlers
{
    public class CreateProductRequestHandler : Notifiable<Notification>, IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
    {
        private readonly IProductRepository _productReposity;
        private readonly IMapper _mapper;

        public CreateProductRequestHandler(IProductRepository productReposity, IMapper mapper)
        {
            _productReposity = productReposity;
            _mapper = mapper;
        }

        public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (!request.IsValid)
            {
                return new InvalidModelException(request.Notifications.ToList());
            }

            var product = new Product(request.Name, request.Value, request.Quantity, request.ProductType);

            _productReposity.Create(product);

            return _mapper.Map<CreateProductResponse>(product);
        }
    }
}