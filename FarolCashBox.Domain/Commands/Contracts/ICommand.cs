using OperationResult;

namespace FarolCashBox.Domain.Commands.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}