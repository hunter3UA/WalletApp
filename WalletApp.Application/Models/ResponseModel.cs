
namespace WalletApp.Application.Models;

public sealed class ResponseModel<T>
{
    public T? Data { get; set; }

    public bool Success { get; }

    public IEnumerable<ErrorModel>? Errors { get; set; }

    public ResponseModel(T data)
    {
        Data = data;
        Success = true;
    }

    public ResponseModel(params ErrorModel[] data)
    {
        Errors = data;
        Success = false;
    }
}