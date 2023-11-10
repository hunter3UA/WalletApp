using MediatR;
using WalletApp.Application.DTO;

namespace WalletApp.Application.Requests;

public record GetPagedAndSortedTransactionsRequest(int UserId) : IRequest<AccountDataDTO>;
