using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class CityRepository(AppDbContext dbContext) : ICityRepository
{
    public List<CityEntity>? GetAll()
    {
        return (from cities in dbContext.Cities select cities) as List<CityEntity>;
    }

    public CityEntity? GetCityWithLargestNumberRoutes()
    {
        return dbContext.Cities.MaxBy(x => x.Routes);
    }
}