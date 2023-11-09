namespace WalletApp.Application.DTO
{
    public sealed record TransactionDTO(string Name, decimal Sum, string Type, bool Pending, DateTimeOffset ExecutedDay)
    {
        public string? AuthorizedUser { get; set; }

        public string? Description { get; set; }
    }
}
