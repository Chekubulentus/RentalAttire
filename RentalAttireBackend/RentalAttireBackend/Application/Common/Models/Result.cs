namespace RentalAttireBackend.Application.Common.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; } = default!;
        public string SuccessMessage { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public static Result<T> Success(T data, string message) => new() { Data = data, IsSuccess = true, SuccessMessage = message };
        public static Result<T> Failure(string message) => new() { IsSuccess = false, ErrorMessage = message };
    }
}
