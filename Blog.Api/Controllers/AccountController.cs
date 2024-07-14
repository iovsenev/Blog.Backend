using Blog.Api.Controllers.Common;
using Blog.Application.Services.Account.Login;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

public class AccountController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request,
        CancellationToken ct)
    {
        return Ok();
    }
}
