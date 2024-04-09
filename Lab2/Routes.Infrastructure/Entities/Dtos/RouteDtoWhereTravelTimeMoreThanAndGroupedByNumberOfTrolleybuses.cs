namespace Routes.Infrastructure.Entities.Dtos;

public record RouteDtoWhereTravelTimeMoreThanAndGroupedByNumberOfTrolleybuses<TKey>
{
    public required TKey NumberTrolleybus { get; init; }
    public required int RouteCount { get; init; }
}