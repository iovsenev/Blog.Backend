using Blog.Api.Controllers.Common;
using Blog.Application.Mediators;
using Blog.Application.Services.Account.Login;
using Blog.Application.Services.Account.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
/// <summary>
/// Методы для регистрации пользователей и входа в систему.
/// </summary>
public class AccountController : BaseController
{
    private readonly IMediator _mediator;

    /// <summary>
    ///  
    /// </summary>
    /// <param name="mediator">Интерфейс паттерна посредник</param>
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Метод входа в систему. Возвращает JWT токен при успешном входе.
    /// </summary>
    /// <param name="command">Содержит Email и пароль пользователя</param>
    /// <param name="cancelationToken">Cancelation token</param>
    /// <returns>JWT bearer</returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(
        [FromBody] LoginUserCommand command,
        CancellationToken cancelationToken)
    {
        var result = await _mediator.Send(command, cancelationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    /// <summary>
    /// Метод регистрации пользователя в системе возвращает JWT токен при успешной регистрации
    /// </summary>
    /// <param name="command">RegisterUserCommand содержит email и пароль обязательные поля, userName может быть пустым</param>
    /// <param name="cancelationToken">Cancelation token</param>
    /// <returns>JWT Bearer</returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterUserCommand command,
        CancellationToken cancelationToken)
    {
        var result = await _mediator.Send(command, cancelationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);
        return await Login(new LoginUserCommand(command.Email, command.Password), cancelationToken);
        return Ok();
    }

    [HttpPost("[action]")]
    [Authorize]
    public async Task<IActionResult> EditUserData()
    {
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserData()
    {
        var user = User;
        return Ok(user.Claims.Select(c => c.Value));
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteAccount()
    {
        return Ok();
    }

}
