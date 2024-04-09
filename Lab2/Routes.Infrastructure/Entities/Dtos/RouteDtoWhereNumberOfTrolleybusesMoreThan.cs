namespace Routes.Infrastructure.Entities.Dtos;

public record RouteDtoWhereNumberOfTrolleybusesMoreThan
{
    public required string RouteName { get; init; }
    public required float AverageTravelTime { get; init; }
}