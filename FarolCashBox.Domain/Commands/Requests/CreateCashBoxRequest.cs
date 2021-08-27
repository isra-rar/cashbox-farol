using FarolCashBox.Domain.Commands.Contracts;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

namespace FarolCashBox.Domain.Commands.Requests
{
    public class CreateCashBoxRequest : Notifiable<Notification>, IRequest<GenericCommandResult<CreateCashBoxResponse>>, ICommand
    {
        public CreateCashBoxRequest()
        {

        }

        public void Validate()
        {
            AddNotifications(new Contract<CashBox>()
            .Requires());
        }
    }
}
