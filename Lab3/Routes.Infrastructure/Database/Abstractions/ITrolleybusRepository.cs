using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface ITrolleybusRepository
{
    List<int>? GetUniqueTrolleybusNumbers();
}