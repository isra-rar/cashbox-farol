using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Enums;
using FarolCashBox.Domain.Repositories;
using Flunt.Notifications;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Handlers
{
    //public class GetAllProductsByProductTypeRequestHanlder : Notifiable<Notification>, IRequestHandler<GetAllProductsByProductTypeRequest, GenericCommandResult<GetAllProductsByProductTypeResponse>>
    //{
    //    private readonly IProductRepository _productReposity;

    //    public GetAllProductsByProductTypeRequestHanlder(IProductRepository productReposity)
    //    {
    //        _productReposity = productReposity;
    //    }

    //    public async Task<GenericCommandResult<GetAllProductsByProductTypeResponse>> Handle(GetAllProductsByProductTypeRequest request, CancellationToken cancellationToken)
    //    {
    //        request.Validate();
    //        if (!request.IsValid)
    //        {
    //            var failValidation = new GenericCommandResult<GetAllProductsByProductTypeResponse>(false, "Dados Invalidos", request.Notifications, 400);
    //            return await Task.FromResult(failValidation);
    //        }

    //        try
    //        {
    //            var productType = Enum.Parse<EProductType>(request.ProductType);
    //            var products = _productReposity.GetAllProductsByType(productType).ToList();

    //            var result = products.Select(x =>
    //                new GetAllProductsByProductTypeResponse
    //                {
    //                    Id = x.Id,
    //                    Name = x.Name,
    //                    Value = x.Value,
    //                    ProductType = x.ProductType.ToString(),
    //                    Quantity = x.Quantity
    //                });

    //            return await Task.FromResult(result);
    //        }
    //        catch (System.Exception)
    //        {

    //            throw;
    //        }

    //    }
    //}
}
