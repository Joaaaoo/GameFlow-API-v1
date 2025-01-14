using GameFlow.Application.DTOs;
using GameFlow.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GameFlow.Application.Queries
{
    public class GameQueryHandler :
        IRequestHandler<GetGameQuery, GameResponse>,
        IRequestHandler<GetGamesQuery, IEnumerable<GameResponse>>,
        IRequestHandler<GetGamesForRentQuery, IEnumerable<GameResponse>>, 
        IRequestHandler<GetGamesForSaleQuery, IEnumerable<GameResponse>>,
        IRequestHandler<GetGamesWithFiltersQuery, IEnumerable<GameResponse>> 

    {
        private readonly IGameRepository _gameRepository;

        public GameQueryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameResponse> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.Id);
            if (game == null)
            {
                throw new KeyNotFoundException($"Game with Id {request.Id} not found.");
            }

            return new GameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Edition = game.Edition,
                Description = game.Description,
                Price = game.Price,
                Quantity = game.Quantity,
                IsAvailableForRent = game.IsAvailableForRent,
                IsAvailableForSale = game.IsAvailableForSale,
                Author = game.Author,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
                MinAge = game.MinAge,
                Language = game.Language,
                GameTime = game.GameTime,
                NumberOfPlayers = game.NumberOfPlayers,
                Category = game.Category,
                AditionalInformation = game.AditionalInformation,
                Photos = game.Photos.Select(p => p.PhotoData).ToList()
            };
        }

        public async Task<IEnumerable<GameResponse>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAllAsync();
            return games.Select(game => new GameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Edition = game.Edition,
                Description = game.Description,
                Price = game.Price,
                Quantity = game.Quantity,
                IsAvailableForRent = game.IsAvailableForRent,
                IsAvailableForSale = game.IsAvailableForSale,
                Author = game.Author,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
                MinAge = game.MinAge,
                Language = game.Language,
                GameTime = game.GameTime,
                NumberOfPlayers = game.NumberOfPlayers,
                Category = game.Category,
                AditionalInformation = game.AditionalInformation,
                Photos = game.Photos.Select(p => p.PhotoData).ToList()
            }).ToList();
        }
        public async Task<IEnumerable<GameResponse>> Handle(GetGamesForRentQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAvailableForRentAsync();
            return games.Select(game => new GameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Edition = game.Edition,
                Description = game.Description,
                Price = game.Price,
                Quantity = game.Quantity,
                IsAvailableForRent = game.IsAvailableForRent,
                IsAvailableForSale = game.IsAvailableForSale,
                Author = game.Author,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
                MinAge = game.MinAge,
                Language = game.Language,
                GameTime = game.GameTime,
                NumberOfPlayers = game.NumberOfPlayers,
                Category = game.Category,
                AditionalInformation = game.AditionalInformation,
                Photos = game.Photos.Select(p => p.PhotoData).ToList()
            }).ToList();
        }

        public async Task<IEnumerable<GameResponse>> Handle(GetGamesForSaleQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAvailableForSaleAsync();
            return games.Select(game => new GameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Edition = game.Edition,
                Description = game.Description,
                Price = game.Price,
                Quantity = game.Quantity,
                IsAvailableForRent = game.IsAvailableForRent,
                IsAvailableForSale = game.IsAvailableForSale,
                Author = game.Author,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
                MinAge = game.MinAge,
                Language = game.Language,
                GameTime = game.GameTime,
                NumberOfPlayers = game.NumberOfPlayers,
                Category = game.Category,
                AditionalInformation = game.AditionalInformation,
                Photos = game.Photos.Select(p => p.PhotoData).ToList()
            }).ToList();
        }
        public async Task<IEnumerable<GameResponse>> Handle(GetGamesWithFiltersQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetGamesWithFiltersAsync(
                request.Id,
                request.Name,
                request.Edition,
                request.Description,
                request.Price,
                request.Quantity,
                request.IsAvailableForRent,
                request.IsAvailableForSale,
                request.Author,
                request.Publisher,
                request.ReleaseDate,
                request.MinAge,
                request.Language,
                request.GameTime,
                request.NumberOfPlayers,
                request.Category,
                request.AditionalInformation
            );

            return games.Select(game => new GameResponse
            {
                Id = game.Id,
                Name = game.Name,
                Edition = game.Edition,
                Description = game.Description,
                Price = game.Price,
                Quantity = game.Quantity,
                IsAvailableForRent = game.IsAvailableForRent,
                IsAvailableForSale = game.IsAvailableForSale,
                Author = game.Author,
                Publisher = game.Publisher,
                ReleaseDate = game.ReleaseDate,
                MinAge = game.MinAge,
                Language = game.Language,
                GameTime = game.GameTime,
                NumberOfPlayers = game.NumberOfPlayers,
                Category = game.Category,
                AditionalInformation = game.AditionalInformation,
                Photos = game.Photos.Select(p => p.PhotoData).ToList()
            }).ToList();
        }
    }
}
