using WalletApp.Application.DTO.Transactions;

namespace WalletApp.Application.DTO;

public sealed record AccountDataDTO(decimal CardBalance, decimal Available, string DailyPoints,string Month, IEnumerable<TransactionDTO> transactions);