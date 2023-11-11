using MediatR;
using WalletApp.Application.DTO;

namespace WalletApp.Application.Requests;

public sealed record GetTtransactionsRequest(int UserId) : IRequest<List<TransactionDTO>>;
