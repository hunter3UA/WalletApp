using MediatR;
using WalletApp.Application.DTO;
using WalletApp.Application.MapperProfiles;
using WalletApp.Application.Repositories;
using WalletApp.Application.Requests;
using WalletApp.Application.Services;
using WalletApp.Domain.Enums;

namespace WalletApp.Application.Handlers;

public class GetTransactionsHandler : IRequestHandler<GetTtransactionsRequest, List<TransactionDTO>>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IPointsService _pointsService;

    public GetTransactionsHandler(ITransactionRepository transactionRepository, IPointsService pointsService)
    {
        _transactionRepository = transactionRepository;
        _pointsService = pointsService;
    }

    public async Task<List<TransactionDTO>> Handle(GetTtransactionsRequest request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository
            .GetRangeAsync(trn => trn.UserId == request.UserId, trn => trn.ExecutedDay, SortingOrder.Desc, cancellationToken, default, 10);

        return transactions.MapToTransactionsDTO(DateTimeOffset.UtcNow);
    }
}