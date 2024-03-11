using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class TrolleybusRepository(AppDbContext dbContext) : ITrolleybusRepository
{
    public TrolleybusEntity? GetTrolleybusWithLargestNumberRoutes()
    {
        return dbContext.Trolleybuses.MaxBy(x => x.Routes);
    }

    public List<int>? GetTrolleybusesInRoute(int routeId)
    {
        return dbContext.Routes.SingleOrDefault(x => x.Number == routeId)?.Trolleybuses?.Select(x => x.Number).ToList();
    }

    public List<int>? GetUniqueTrolleybusNumbers()
    {
        return dbContext.Trolleybuses.Select(x => x.Number).Distinct().ToList();
    }

    public int GetNumberTrolleybusesByCity(string cityName)
    {
        return dbContext.Cities.FirstOrDefault(c => c.Name == cityName)!.Routes!
            .Where(r => r.Trolleybuses != null)
            .Sum(r => r.Trolleybuses!.Count);
    }
}