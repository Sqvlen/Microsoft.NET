using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface ITrolleybusRepository
{
    TrolleybusEntity? GetTrolleybusWithLargestNumberRoutes();
    // List<int>? GetTrolleybusesInRoute(int routeId);
    // List<int>? GetUniqueTrolleybusNumbers();
    // int GetNumberTrolleybusesByCity(string cityName);
}