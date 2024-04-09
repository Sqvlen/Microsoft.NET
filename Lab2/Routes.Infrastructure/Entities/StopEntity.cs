using System.ComponentModel.DataAnnotations;
using Routes.Infrastructure.Database;

namespace Routes.Infrastructure.Entities;

public class StopEntity : BaseEntity<long>
{
    [Required]
    [MaxLength(64)]
    [MinLength(2)]
    public required string StopName { get; set; }
}