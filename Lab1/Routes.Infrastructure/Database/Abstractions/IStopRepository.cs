using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface IStopRepository
{
    List<StopEntity> GetStopsAndSortedByName();
}