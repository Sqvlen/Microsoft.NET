namespace Routes.Infrastructure.Entities.Dtos;

public record RouteDtoGroupedByNumberOfTrolleybuses<TKey>
{
    public required TKey TrolleybusNumber { get; init; }
    public required List<RouteDto> Routes { get; init; }
    public required RouteEntity? LongestRoute { get; init; }
}