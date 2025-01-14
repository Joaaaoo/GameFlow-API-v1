using MediatR;
using GameFlow.Infrastructure;
using GameFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GameFlow.Application.Commands.Games;

namespace GameFlow.Application.Handlers.Games
{
    public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, bool>
    {
        private readonly GameFlowDbContext _context;

        public UpdateGameHandler(GameFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games.Include(g => g.Photos).FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

            if (game == null)
                return false;

            game.Name = request.Name;
            game.Edition = request.Edition;
            game.Description = request.Description;
            game.Price = request.Price;
            game.Quantity = request.Quantity;
            game.IsAvailableForRent = request.IsAvailableForRent;
            game.IsAvailableForSale = request.IsAvailableForSale;
            game.Author = request.Author;
            game.Publisher = request.Publisher;
            game.ReleaseDate = request.ReleaseDate;
            game.MinAge = request.MinAge;
            game.Language = request.Language;
            game.GameTime = request.GameTime;
            game.NumberOfPlayers = request.NumberOfPlayers;
            game.Category = request.Category;
            game.AditionalInformation = request.AditionalInformation;

            // Atualizar fotos
            game.Photos.Clear();
            if (request.Photos != null && request.Photos.Any())
            {
                foreach (var photoData in request.Photos)
                {
                    game.Photos.Add(new GamePhoto
                    {
                        Id = Guid.NewGuid(),
                        PhotoData = photoData,
                        GameId = game.Id
                    });
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
