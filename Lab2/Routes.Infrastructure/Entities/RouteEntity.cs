using System.ComponentModel.DataAnnotations;
using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class RouteEntity : BaseEntity<long>
{
    [Required]
    [MaxLength(64)]
    [MinLength(2)]
    public required string Name { get; set; }

    [Required]
    public required int Number { get; set; }
    
    public StopEntity? StartStopEntity { get; set; }
    public StopEntity? EndStopEntity { get; set; }
    public ICollection<TrolleybusEntity>? Trolleybuses { get; set; }
    
    [Required]
    public required float TravelTime { get; set; }
}