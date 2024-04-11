using System.Text.Json;
using System.Text.Json.Nodes;
using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class StopRepository(JsonNode jsonNode) : IStopRepository
{
    public List<StopEntity> GetStopsAndSortedByName()
    {
        return jsonNode.Deserialize<IEnumerable<StopEntity>>()!.OrderBy(x => x.StopName)
            .ToList();
    }
}