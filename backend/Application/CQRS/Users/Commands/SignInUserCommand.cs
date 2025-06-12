using Application.DTOs.User;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Users.Commands;

public record SignInUserCommand(SignInUserDto Dto) : IRequest<Result>;