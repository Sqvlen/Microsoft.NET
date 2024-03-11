using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class CityRepository(AppDbContext dbContext) : ICityRepository
{
    public IEnumerable<CityEntity>? GetAll()
    {
        return from cities in dbContext.Cities select cities;
    }

    public CityEntity? GetCityWithLargestNumberRoutes()
    {
        return dbContext.Cities.MaxBy(x => x.Routes?.Count);
    }
}