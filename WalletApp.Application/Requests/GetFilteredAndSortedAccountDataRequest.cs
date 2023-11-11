using MediatR;
using WalletApp.Application.DTO;

namespace WalletApp.Application.Requests;

public record GetFilteredAndSortedAccountDataRequest(int UserId) : IRequest<AccountDataDTO>;
