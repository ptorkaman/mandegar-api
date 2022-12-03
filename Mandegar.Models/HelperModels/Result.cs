using Mandegar.Resources.AdminMessage;

namespace Mandegar.Models.HelperModels
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; } = default(T);

        public Result()
        {

        }

        public Result(T data)
        {
            Data = data;
            Success = true;
            Message = Messages.OperationSucceeded;
        }

        public Result(bool success)
        {
            Success = success;
            Data = default(T);
            Message = success ? Messages.OperationSucceeded : Messages.OperationFailed;
        }

        public Result(string message)
        {
            Success = false;
            Data = default(T);
            Message = message;
        }

        public Result(T data, bool success)
        {
            Data = data;
            Success = success;
            Message = success ? Messages.OperationSucceeded : Messages.OperationFailed;
        }
    }
}
