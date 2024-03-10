using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class CityEntity : BaseEntity<long>
{
    public List<RouteEntity>? Routes { get; set; }
}