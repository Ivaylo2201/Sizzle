using Application.CQRS.Users.Commands;
using Application.DTOs.User;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IMediator mediator, ITokenService tokenService) : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromBody] CreateUserRequest request)
    {
        var dto = new CreateUserDto
        {
            Username = request.Username,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            PasswordConfirmation = request.PasswordConfirmation
        };
        
        var userResult = await mediator.Send(new CreateUserCommand(dto));
        
        if (!userResult.IsSuccess || userResult.Value is null)
            return BadRequest(new { error = userResult.Error });
        
        return Created(string.Empty, new { token = tokenService.GenerateToken(userResult.Value) });
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] SignInUserRequest request)
    {
        var dto = new SignInUserDto
        {
            Username = request.Username,
            Password = request.Password,
        };
        
        var userResult = await mediator.Send(new SignInUserCommand(dto));

        if (!userResult.IsSuccess || userResult.Value is null)
            return BadRequest(new { error = userResult.Error });
        
        return Ok(new { token = tokenService.GenerateToken(userResult.Value) });
    }
}