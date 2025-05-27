using System.Security.Claims;
using Backend.Repositories.Interfaces;

namespace Backend.Middlewares;

public class UserContextMiddleware(RequestDelegate next, IUserRepository userRepository)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            if (int.TryParse(context.User.FindFirstValue("sub"), out var id))
            {
                var user = await userRepository.GetUserById(id);
                context.Items["User"] = user;
            }
        }

        await next(context);
    }
}