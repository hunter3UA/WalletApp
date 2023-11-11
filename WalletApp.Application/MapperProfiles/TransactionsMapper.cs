using WalletApp.Application.DTO;
using WalletApp.Application.Helpers;
using WalletApp.Domain.DbEntities;

namespace WalletApp.Application.MapperProfiles;

public static class TransactionsMapper
{
    public static List<TransactionDTO> MapToTransactionsDTO(this IEnumerable<TransactionDb> transactions, DateTimeOffset now)
    {
        var transactionsDTO = new List<TransactionDTO>();

        foreach (var transaction in transactions)
        {
            var newTransactionDTO = new TransactionDTO(
                transaction.Name,
                transaction.Sum,
                transaction.Type.ToString(),
                transaction.Pending,
                DateFormatter.FormatDate(transaction.ExecutedDay, now),
                transaction.AuthorizedUser,
                transaction.Description,
                transaction.IconUrl);

            transactionsDTO.Add(newTransactionDTO);
        }

        return transactionsDTO;
    }
}