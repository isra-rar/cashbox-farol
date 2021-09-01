using FarolCashBox.Domain.Commands.Contracts;
using FarolCashBox.Domain.Commands.Response;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

namespace FarolCashBox.Domain.Commands.Requests
{
    public class GetAllProductsByProductTypeRequest : Notifiable<Notification>, IRequest<GenericCommandResult<GetAllProductsByProductTypeResponse>>, ICommand
    {
        public GetAllProductsByProductTypeRequest(string productType)
        {
            ProductType = productType;
        }

        public string ProductType { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<GetAllProductsByProductTypeRequest>()
                .Requires()
                .IsNotNull(ProductType, "ProductType", "O Tipo do Produto não pode ser NULO")
                );
        }
    }
}
