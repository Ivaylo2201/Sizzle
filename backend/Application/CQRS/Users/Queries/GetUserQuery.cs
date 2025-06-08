using Application.DTOs.User;
using Core.Abstractions;
using MediatR;

namespace Application.CQRS.Users.Queries;

public record GetUserQuery(int UserId) : IRequest<Result<ReadUserDto?>>;