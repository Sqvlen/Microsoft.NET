namespace Routes.Infrastructure.Entities.Dtos;

public record RouteDtoWhereTimeTravelMoreThanAndGroupedByNumberOfTrolleybusInRoute<TKey>
{
    public required TKey NumberTrolleybus { get; init; }
    public required List<RouteEntity> Routes { get; init; }
}