using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface ITrolleybusRepository
{
    // void GetJsonNode();
    List<int>? GetUniqueTrolleybusNumbers();
}