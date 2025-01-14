using GameFlow.Application.DTOs;
using MediatR;
using System;

namespace GameFlow.Application.Queries
{
    public record GetGameQuery(Guid Id) : IRequest<GameResponse>;
}
