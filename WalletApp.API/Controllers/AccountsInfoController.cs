using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.DTO;
using WalletApp.Application.Models;
using WalletApp.Application.Requests;

namespace WalletApp.API.Controllers;

[Route("api/accounts-info")]
[ApiController]
public class AccountsInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountsInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult> GetAccountData([FromRoute] int userId, CancellationToken cancellationToken)
    {
        var pagedTransactionRequest = new GetFilteredAndSortedAccountDataRequest(userId);
        var accountData = await _mediator.Send(pagedTransactionRequest, cancellationToken);
        var response = new ResponseModel<AccountDataDTO>(accountData);

        return Ok(response);
    }
}