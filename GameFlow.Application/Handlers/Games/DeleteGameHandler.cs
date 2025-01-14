using MediatR;
using GameFlow.Infrastructure;
using Microsoft.EntityFrameworkCore;
using GameFlow.Application.Commands.Games;

namespace GameFlow.Application.Handlers.Games
{
    public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly GameFlowDbContext _context;

        public DeleteGameHandler(GameFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games.Include(g => g.Photos).FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken);
            if (game == null)
            {
                return false;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
