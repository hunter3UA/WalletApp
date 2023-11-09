namespace WalletApp.Application.DTO
{
    public sealed record GetDataDTO(string NoPaymentDue, int DayilyPoints, List<TransactionDTO> Transactions);
}
