using Backend.Database.Entities;
using Backend.DTOs.User;

namespace Backend.Mappers;

public static class UserMapper
{
    public static User ToUser(this CreateUserDto dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
        };
    }
}