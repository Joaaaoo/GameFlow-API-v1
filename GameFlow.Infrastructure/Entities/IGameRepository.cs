using GameFlow.Domain.Entities;

public interface IGameRepository
{
    Task<Game?> GetByIdAsync(Guid id);
    Task<IEnumerable<Game>> GetAllAsync();
    Task<IEnumerable<Game>> GetAvailableForRentAsync(); 
    Task<IEnumerable<Game>> GetAvailableForSaleAsync();
    Task<IEnumerable<Game>> GetGamesWithFiltersAsync(
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
       );
}
