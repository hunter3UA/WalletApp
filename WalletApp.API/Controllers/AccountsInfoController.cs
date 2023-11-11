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
    public async Task<ActionResult> GetAccountInfo([FromRoute] int userId, CancellationToken cancellationToken)
    {
        var getAccountInfoRequest = new GetAccountInfoRequest(userId);
        var accountInfoDTO = await _mediator.Send(getAccountInfoRequest, cancellationToken);
        var response = new ResponseModel<AccountInfoDTO>(accountInfoDTO);

        return Ok(response);
    }
}