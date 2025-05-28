using Backend.DTOs.User;
using Backend.Repositories.Interfaces;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/auth")]
public class UserController(IUserRepository userRepository, TokenService tokenService) : ControllerBase
{
    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> Signup(CreateUserDto dto)
    {
        var user = await userRepository.CreateUser(dto);
        return CreatedAtAction(nameof(Signup), new { id = user.Id }, user);
    }
    
    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> Signin(LoginUserDto dto)
    {
        var user = await userRepository.GetUserByEmail(dto.Email);

        if (user == null)
            return NotFound(new { message = "The requested user resource was not found on the server" });

        return Ok(new { token = tokenService.GenerateToken(user) });
    }
}