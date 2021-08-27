using FarolCashBox.Domain.Commands;
using FarolCashBox.Domain.Commands.Requests;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Repositories;
using Flunt.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Handlers
{
    public class CreateCashBoxRequestHandler : Notifiable<Notification>, IRequestHandler<CreateCashBoxRequest, GenericCommandResult<CreateCashBoxResponse>>
    {
        private readonly IRepository<CashBox> _cashBoxReposity;

        public CreateCashBoxRequestHandler(IRepository<CashBox> cashBoxReposity)
        {
            _cashBoxReposity = cashBoxReposity;
        }

        public async Task<GenericCommandResult<CreateCashBoxResponse>> Handle(CreateCashBoxRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (!request.IsValid)
            {
                var failValidation = new GenericCommandResult<CreateCashBoxResponse>(false, "Dados Invalidos", request.Notifications, 400);
                return await Task.FromResult(failValidation);
            }

            var cashBox = new CashBox();

            _cashBoxReposity.Create(cashBox);

            var result = new GenericCommandResult<CreateCashBoxResponse>(true, "Produto criado com sucesso",
            new CreateCashBoxResponse
            {
                Id = cashBox.Id,
                CreationDate = cashBox.CreationDate,
            });

            return await Task.FromResult(result);
        }
    }
}
