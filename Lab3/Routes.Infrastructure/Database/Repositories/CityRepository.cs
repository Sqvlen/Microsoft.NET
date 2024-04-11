using System.Text.Json;
using System.Text.Json.Nodes;
using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class CityRepository(JsonNode jsonNode) : ICityRepository
{
    private readonly IEnumerable<CityEntity> _cities = jsonNode.Deserialize<IEnumerable<CityEntity>>()!;
    
    public IEnumerable<CityEntity> GetAll()
    {
        return from cities in _cities select cities;
    }

    public CityEntity? GetCityWithLargestNumberRoutes()
    {
        return _cities.MaxBy(x => x.Routes?.Count);
    }
}