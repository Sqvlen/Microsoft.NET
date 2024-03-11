using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface ICityRepository
{
    List<CityEntity>? GetAll();
    CityEntity? GetCityWithLargestNumberRoutes();
}