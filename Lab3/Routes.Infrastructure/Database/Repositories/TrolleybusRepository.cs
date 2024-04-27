using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class TrolleybusRepository(IEnumerable<TrolleybusEntity> trolleybuses) : ITrolleybusRepository
{
    public List<int> GetUniqueTrolleybusNumbers()
    {
        return trolleybuses.Select(x => x.Number).Distinct().ToList();
    }
}