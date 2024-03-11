using System.ComponentModel.DataAnnotations;
using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class TrolleybusEntity : BaseEntity<long>
{
    [Required]
    public required int Number { get; set; }
    
    public List<RouteEntity>? Routes { get; set; }
}