using GameFlow.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace GameFlow.Application.Queries
{
    public record GetGamesWithFiltersQuery(
        Guid? Id = null,
        string? Name = null,
        string? Edition = null,
        string? Description = null,
        decimal? Price = null,
        int? Quantity = null,
        bool? IsAvailableForRent = null,
        bool? IsAvailableForSale = null,
        string? Author = null,
        string? Publisher = null,
        string? ReleaseDate = null,
        string? MinAge = null,
        string? Language = null,
        string? GameTime = null,
        string? NumberOfPlayers = null,
        string? Category = null,
        string? AditionalInformation = null
    ) : IRequest<IEnumerable<GameResponse>>;
}
