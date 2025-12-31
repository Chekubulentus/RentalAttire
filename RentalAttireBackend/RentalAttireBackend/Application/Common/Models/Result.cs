namespace RentalAttireBackend.Application.Common.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; } = default!;
        public string SuccessMessage { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public static Result<T> Success(T data) => new() { Data = data, IsSuccess = true};
        public static Result<T> Failure(string message) => new() { IsSuccess = false, ErrorMessage = message };
        public static Result<T> SuccessWithMessage(string message) => new() { IsSuccess = true, SuccessMessage = message };
    }
}
