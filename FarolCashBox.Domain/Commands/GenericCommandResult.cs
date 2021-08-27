using FarolCashBox.Domain.Commands.Contracts;

namespace FarolCashBox.Domain.Commands
{
    public class GenericCommandResult<T>  where T : ICommandResult
    {
        public GenericCommandResult(bool sucess, string message, object data, int code = 200)
        {
            Sucess = sucess;
            Message = message;
            Code = code;
            Data = data;
        }

        public bool Sucess { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}