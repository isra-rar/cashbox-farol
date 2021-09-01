using FarolCashBox.Domain.Commands.Contracts;
using FarolCashBox.Domain.Commands.Response;
using FarolCashBox.Domain.Entities;
using FarolCashBox.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using OperationResult;

namespace FarolCashBox.Domain.Commands.Requests
{
    public class CreateProductRequest : Notifiable<Notification>, IRequest<Result<CreateProductResponse>>, ICommand
    {
        public CreateProductRequest(string name, decimal value, int quantity, EProductType productType)
        {
            Name = name;
            Value = value;
            Quantity = quantity;
            ProductType = productType;
        }

        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public EProductType ProductType { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Product>()
            .Requires()
            .IsGreaterThan(Name, 3, "Name", "O NOME do produto deve ser maior que TRES")
            .IsGreaterThan(Value, 0, "Value", "O VALOR do produto deve ser maior que ZERO")
            .IsGreaterThan(Quantity, 0, "Quantity", "A QUANTIDADE do produto deve ser maior que ZERO")
            .IsNotNull(ProductType, "Quantity", "O TIPO do produto não pode ser NULO")
            );
        }
    }
}