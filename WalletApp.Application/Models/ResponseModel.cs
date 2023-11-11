
namespace WalletApp.Application.Models;

public sealed class ResponseModel<T>
{
    public T? Data { get; }

    public bool Success { get; }

    public IEnumerable<string> Errors { get; }

    public ResponseModel(T data)
    {
        Data = data;
        Success = true;
        Errors = Enumerable.Empty<string>();
    }

    public ResponseModel(params string[] errors)
    {
        Errors = errors;
        Success = false;
    }
}