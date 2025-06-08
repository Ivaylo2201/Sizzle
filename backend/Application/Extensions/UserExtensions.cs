using Application.DTOs.User;
using Core.Entities;

namespace Application.Extensions;

public static class UserExtensions
{
    public static ReadUserDto ToDto(this User user)
    {
        return new ReadUserDto
        {
            PhoneNumber = user.PhoneNumber,
            Username = user.Username,
        };
    }
}