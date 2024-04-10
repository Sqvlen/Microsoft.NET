using System.Text.Json;
using System.Text.Json.Nodes;
using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class TrolleybusRepository(JsonNode jsonNode) : ITrolleybusRepository
{
    private readonly IEnumerable<TrolleybusEntity> _trolleybuses;
    
    public void GetJsonNode()
    {
        
    }
    
    public TrolleybusEntity? GetTrolleybusWithLargestNumberRoutes()
    {
        return _trolleybuses.MaxBy(x => x.Routes?.Count); // dbContext.Trolleybuses.MaxBy(x => x.Routes?.Count);
    }

    public List<int>? GetUniqueTrolleybusNumbers()
    {
        return _trolleybuses.Select(x => x.Number).Distinct().ToList();
    }
}