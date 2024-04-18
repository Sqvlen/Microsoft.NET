using System.ComponentModel.DataAnnotations;
using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class CityEntity : BaseEntity<long>
{
    [Required]
    [MaxLength(64)]
    [MinLength(2)]
    public required string Name { get; set; }
    public List<RouteEntity>? Routes { get; set; }
}