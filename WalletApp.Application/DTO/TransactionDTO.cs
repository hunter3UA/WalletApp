namespace WalletApp.Application.DTO;

public sealed record TransactionDTO(
    string Name,
    decimal Sum,
    string Type,
    bool Pending,
    string ExecutedDay,
    string? AuthorizedUser,
    string? Description,
    string? IconUrl);