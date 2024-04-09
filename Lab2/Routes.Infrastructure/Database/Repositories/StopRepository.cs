using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class StopRepository(AppDbContext dbContext) : IStopRepository
{
    public List<StopEntity> GetStopsAndSortedByName()
    {
        return dbContext.Stops.OrderBy(x => x.StopName).ToList();
    }
}