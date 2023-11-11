using MediatR;
using WalletApp.Application.DTO;

namespace WalletApp.Application.Requests;

public sealed record GetAccountInfoRequest(int UserID) : IRequest<AccountInfoDTO>;