using GameFlow.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace GameFlow.Application.Queries
{
    public record GetGamesQuery() : IRequest<IEnumerable<GameResponse>>;
}
