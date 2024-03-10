using System.ComponentModel.DataAnnotations;
using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class TrolleybusEntity : BaseEntity<long>
{
    [Required]
    public required int Number { get; set; }
    
    public RouteEntity? Route { get; set; }
}