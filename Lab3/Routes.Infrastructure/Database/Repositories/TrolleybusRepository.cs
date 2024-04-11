using System.Text.Json;
using System.Text.Json.Nodes;
using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class TrolleybusRepository : ITrolleybusRepository
{
    private readonly List<TrolleybusEntity> _trolleybuses;

    public TrolleybusRepository(JsonNode jsonNode)
    {
        _trolleybuses = jsonNode.AsArray()
            .SelectMany(x => x["Trolleybuses"].Deserialize<IEnumerable<TrolleybusEntity>>()).ToList();
    }

    public List<int> GetUniqueTrolleybusNumbers()
    {
        return _trolleybuses.Select(x => x.Number).Distinct().ToList();
    }
}