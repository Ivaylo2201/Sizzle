using Application.CQRS.Users.Commands;
using Application.DTOs.User;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IMediator mediator, ITokenService tokenService) : ControllerBase
{
    [HttpPost]
    [Route("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] CreateUserDto dto)
    {
        var result = await mediator.Send(new CreateUserCommand(dto));
        var token = tokenService.GenerateToken(result.Value);
        
        return Created(null as string, new { token });
    }

    [HttpPost]
    [Route("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInUserDto dto)
    {
        var result = await mediator.Send(new SignInUserCommand(dto));

        if (!result.IsSuccess || result.Value is null)
            return BadRequest(new { message = result.Error });
        
        var token = tokenService.GenerateToken(result.Value);
        return Ok(new { token });
    }
}