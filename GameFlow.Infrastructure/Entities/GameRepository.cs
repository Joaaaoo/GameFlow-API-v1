using GameFlow.Domain.Entities;
using GameFlow.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class GameRepository : IGameRepository
{
    private readonly GameFlowDbContext _dbContext;

    public GameRepository(GameFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Games.FirstOrDefaultAsync(game => game.Id == id);
    }
    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _dbContext.Games.ToListAsync();
    }
    public async Task<IEnumerable<Game>> GetAvailableForRentAsync()
    {
        return await _dbContext.Games.Where(game => game.IsAvailableForRent).ToListAsync();
    }
    public async Task<IEnumerable<Game>> GetAvailableForSaleAsync()
    {
        return await _dbContext.Games.Where(game => game.IsAvailableForSale).ToListAsync();
    }
    public async Task<IEnumerable<Game>> GetGamesWithFiltersAsync(
             Guid? id,
             string name,
             string edition,
             string description,
             decimal? price,
             int? quantity,
             bool? isAvailableForRent,
             bool? isAvailableForSale,
             string author,
             string publisher,
             string releaseDate,
             string minAge,
             string language,
             string gameTime,
             string numberOfPlayers,
             string category,
             string aditionalInformation
         )
    {
        //melhorar
        var query = _dbContext.Games.AsQueryable();

        if (id.HasValue)
            query = query.Where(g => g.Id == id.Value);
        if (!string.IsNullOrEmpty(name))
            query = query.Where(g => g.Name.Contains(name));
        if (!string.IsNullOrEmpty(edition))
            query = query.Where(g => g.Edition.Contains(edition));
        if (!string.IsNullOrEmpty(description))
            query = query.Where(g => g.Description.Contains(description));
        if (price.HasValue)
            query = query.Where(g => g.Price == price.Value);
        if (quantity.HasValue)
            query = query.Where(g => g.Quantity == quantity.Value);
        if (isAvailableForRent.HasValue)
            query = query.Where(g => g.IsAvailableForRent == isAvailableForRent.Value);
        if (isAvailableForSale.HasValue)
            query = query.Where(g => g.IsAvailableForSale == isAvailableForSale.Value);
        if (!string.IsNullOrEmpty(author))
            query = query.Where(g => g.Author.Contains(author));
        if (!string.IsNullOrEmpty(publisher))
            query = query.Where(g => g.Publisher.Contains(publisher));
        if (!string.IsNullOrEmpty(releaseDate))
            query = query.Where(g => g.ReleaseDate.Contains(releaseDate));
        if (!string.IsNullOrEmpty(minAge))
            query = query.Where(g => g.MinAge.Contains(minAge));
        if (!string.IsNullOrEmpty(language))
            query = query.Where(g => g.Language.Contains(language));
        if (!string.IsNullOrEmpty(gameTime))
            query = query.Where(g => g.GameTime.Contains(gameTime));
        if (!string.IsNullOrEmpty(numberOfPlayers))
            query = query.Where(g => g.NumberOfPlayers.Contains(numberOfPlayers));
        if (!string.IsNullOrEmpty(category))
            query = query.Where(g => g.Category.Contains(category));
        if (!string.IsNullOrEmpty(aditionalInformation))
            query = query.Where(g => g.AditionalInformation.Contains(aditionalInformation));

        return await query.ToListAsync();
    }
}
