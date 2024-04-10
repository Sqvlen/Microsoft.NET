using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface ITrolleybusRepository
{
    void GetJsonNode();
    TrolleybusEntity? GetTrolleybusWithLargestNumberRoutes();
    List<int>? GetUniqueTrolleybusNumbers();
}