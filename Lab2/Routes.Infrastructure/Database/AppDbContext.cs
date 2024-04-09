using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database;

public class AppDbContext
{
    public List<CityEntity> Cities { get; set; } = null!;
    
    public List<RouteEntity> Routes { get; set; } = null!;
    
    public List<StopEntity> Stops { get; set; } = null!;
    
    public List<TrolleybusEntity> Trolleybuses { get; set; } = null!;
}