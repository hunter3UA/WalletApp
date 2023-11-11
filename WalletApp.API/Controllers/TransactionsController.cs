using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.DTO;
using WalletApp.Application.Models;
using WalletApp.Application.Requests;

namespace WalletApp.API.Controllers;

[Route("api/transactions")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult> GetTransactions([FromRoute] int userId, CancellationToken cancellationToken)
    {
        var getTransactionsRequest = new GetTtransactionsRequest(userId);
        var accountData = await _mediator.Send(getTransactionsRequest, cancellationToken);
        var response = new ResponseModel<List<TransactionDTO>>(accountData);

        return Ok(response);
    }
}