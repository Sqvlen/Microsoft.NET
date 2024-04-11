namespace Routes.Infrastructure.Entities.Dtos;

public record RouteDto
{
    public required string RouteName { get; init; }
    public required string StartStop { get; init; }
    public required string EndStop { get; init; }
    public required float AverageTravelTime { get; init; }
}