using FarolCashBox.Domain.Commands.Contracts;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using OperationResult;

namespace FarolCashBox.Domain.Commands.Requests
{
    public class CreateCashBoxRequest : Notifiable<Notification>, IRequest<Result<CreateCashBoxResponse>>, ICommand
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
