namespace WalletApp.Application.Models
{
    public sealed class ErrorResponseModel
    {
        public IEnumerable<ErrorModel> Errors { get; set; }

        public ErrorResponseModel(params ErrorModel[] errors)
        {
            Errors = errors;
        }

        public ErrorResponseModel(IEnumerable<ErrorModel> errors)
        {
            Errors = errors;
        }
    }
}
