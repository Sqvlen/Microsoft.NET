using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class TrolleybusEntity : BaseEntity<long>
{
    public RouteEntity Route { get; set; }
    public int Number { get; set; }
}