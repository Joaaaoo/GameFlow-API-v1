using MediatR;
using GameFlow.Infrastructure;
using GameFlow.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GameFlow.Application.Commands;

namespace GameFlow.Application.Handlers
{
    public class CreateGameHandler : IRequestHandler<CreateGameCommand, bool>
    {
        private readonly GameFlowDbContext _context;

        public CreateGameHandler(GameFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Edition = request.Edition,
                Description = request.Description,
                Price = request.Price,
                Quantity = request.Quantity,
                IsAvailableForRent = request.IsAvailableForRent,
                IsAvailableForSale = request.IsAvailableForSale,
                Author = request.Author,
                Publisher = request.Publisher,
                ReleaseDate = request.ReleaseDate,
                MinAge = request.MinAge,
                Language = request.Language,
                GameTime = request.GameTime,
                NumberOfPlayers = request.NumberOfPlayers,
                Category = request.Category,
                AditionalInformation = request.AditionalInformation,
                Photos = new List<GamePhoto>()
            };

            var photosAsByteArray = request.GetPhotosAsByteArray();
            if (photosAsByteArray != null && photosAsByteArray.Count > 0)
            {
                foreach (var photoData in photosAsByteArray)
                {
                    game.Photos.Add(new GamePhoto
                    {
                        Id = Guid.NewGuid(),
                        PhotoData = photoData,
                        GameId = game.Id
                    });
                }
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
