using MediatR;
using System.Globalization;
using WalletApp.Application.DTO;
using WalletApp.Application.MapperProfiles;
using WalletApp.Application.Requests;
using WalletApp.Application.Services;
using WalletApp.Domain.DbEntities;

namespace WalletApp.Application.Handlers;

public class GetAccountInfoHandler : IRequestHandler<GetAccountInfoRequest, AccountInfoDTO>
{
    private readonly IPointsService _pointsService;

    public GetAccountInfoHandler(IPointsService pointsService)
    {
        _pointsService = pointsService;
    }

    public async Task<AccountInfoDTO> Handle(GetAccountInfoRequest request, CancellationToken cancellationToken)
    {
        string points = _pointsService.CountDailyPoints();

        var card = new СardDb { Id = Guid.NewGuid(), Balance = 301m };
        string paymentDue = $"You've paid your {CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(DateTimeOffset.UtcNow.Month)} balance";

        var accountInfoDTO = AccountInfoMapper.MapToAccountInfoDTO(card.Balance, card.Available, points, paymentDue);

        return await Task.FromResult(accountInfoDTO);
    }
}