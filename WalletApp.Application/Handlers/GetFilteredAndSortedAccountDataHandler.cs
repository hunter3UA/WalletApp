using MediatR;
using System.Globalization;
using WalletApp.Application.DTO;
using WalletApp.Application.MapperProfiles;
using WalletApp.Application.Repositories;
using WalletApp.Application.Requests;
using WalletApp.Application.Services;
using WalletApp.Domain.DbEntities;
using WalletApp.Domain.Enums;

namespace WalletApp.Application.Handlers;

public class GetFilteredAndSortedAccountDataHandler : IRequestHandler<GetFilteredAndSortedAccountDataRequest, AccountDataDTO>
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IPointsService _pointsService;

    public GetFilteredAndSortedAccountDataHandler(ITransactionRepository transactionRepository, IPointsService pointsService)
    {
        _transactionRepository = transactionRepository;
        _pointsService = pointsService;
    }

    public async Task<AccountDataDTO> Handle(GetFilteredAndSortedAccountDataRequest request, CancellationToken cancellationToken)
    {
        var transactions = await _transactionRepository
            .GetRangeAsync(trn => trn.UserId == request.UserId, trn => trn.ExecutedDay, SortingOrder.Desc, cancellationToken, default, 10);

        string points = _pointsService.CountDailyPoints();
        var card = new СardDb { Id = Guid.NewGuid(), Balance = 301m };
        string currentMonth = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(DateTimeOffset.UtcNow.Month);

        return AccountDataMapper.MapToAccountData(card.Balance, card.Available, points, currentMonth, transactions);
    }
}