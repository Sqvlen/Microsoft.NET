using System.ComponentModel.DataAnnotations;
using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class RouteEntity : BaseEntity<long>
{
    [Required]
    [MaxLength(64)]
    [MinLength(2)]
    public required string Name { get; set; }
    
    public required StopEntity StartStopEntity { get; set; }
    public required StopEntity EndStopEntity { get; set; }
    public List<TrolleybusEntity>? Trolleybuses { get; set; }
    public required DateTimeOffset TravelTime { get; set; }
}