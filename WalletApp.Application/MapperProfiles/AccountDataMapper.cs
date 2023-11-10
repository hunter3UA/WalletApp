using WalletApp.Application.DTO;
using WalletApp.Application.DTO.Transactions;
using WalletApp.Application.Helpers;
using WalletApp.Domain.DbEntities;

namespace WalletApp.Application.MapperProfiles;

public static class AccountDataMapper
{
    public static AccountDataDTO MapToAccountData(decimal CardBalance, decimal Available, string DailyPoints, string Month, IEnumerable<TransactionDb> transactions)
    {
        var transactionsDTO = new List<TransactionDTO>();
        DateTimeOffset now = DateTimeOffset.UtcNow;

        foreach (var transaction in transactions)
        {
            var newTransactionDTO = new TransactionDTO(
                transaction.Name,
                transaction.Sum,
                transaction.Type.ToString(),
                transaction.Pending,
                DateFormatterHelper.FormatDate(transaction.ExecutedDay, now),
                transaction.AuthorizedUser,
                transaction.Description,
                transaction.IconUrl);

            transactionsDTO.Add(newTransactionDTO);
        }

        return new AccountDataDTO(CardBalance, Available, DailyPoints, Month, transactionsDTO);
    }
}