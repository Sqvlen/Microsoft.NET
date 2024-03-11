using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface ICityRepository
{
    IEnumerable<CityEntity>? GetAll();
    CityEntity? GetCityWithLargestNumberRoutes();
}