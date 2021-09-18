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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Handlers
{
    public class CreateCashBoxRequestHandler : Notifiable<Notification>, IRequestHandler<CreateCashBoxRequest, Result<CreateCashBoxResponse>>
    {
        private readonly ICashBoxRepository _cashBoxReposity;
        private readonly IMapper _mapper;

        public CreateCashBoxRequestHandler(ICashBoxRepository cashBoxReposity, IMapper mapper)
        {
            _cashBoxReposity = cashBoxReposity;
            _mapper = mapper;
        }

        public async Task<Result<CreateCashBoxResponse>> Handle(CreateCashBoxRequest request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (!request.IsValid)
            {
                return new InvalidModelException(request.Notifications.ToList());
            }

            var cashBox = new CashBox();

            _cashBoxReposity.Create(cashBox);

            return _mapper.Map<CreateCashBoxResponse>(cashBox);
        }
    }
}
