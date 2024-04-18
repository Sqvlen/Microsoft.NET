using Routes.Infrastructure.Entities;
using Routes.Infrastructure.Entities.Dtos;

namespace Routes.Infrastructure.Database.Abstractions;

public interface IRouteRepository
{
    IEnumerable<RouteEntity>? GetAll();
    RouteEntity? GetRouteByName(string name);
    List<RouteEntity>? GetRoutesWhereTravelTimeMoreThan(float minutes);
    List<RouteEntity>? GetRoutesThatRunThroughStop(string stopName);
    List<RouteEntity>? GetRoutesWithTrolleybusesMoreThan(int trolleybusesCount);
    List<RouteEntity>? GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThan(float minutes, int trolleybusesCount);
    List<RouteEntity>? GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThanAndSortedByTravelTime(float minutes, int trolleybusesCount);
    List<RouteDtoWhereTimeTravelMoreThanAndGroupedByNumberOfTrolleybusInRoute<int?>>
        GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRoute(float minutes);
    List<RouteEntity> GetRoutesWhereTravelTimeMoreThanAndTake(float minutes, int numberTake);
    List<RouteDtoWhereTravelTimeMoreThanAndGroupedByNumberOfTrolleybuses<int?>>
        GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRouteAndNumberRoutesInGroup(float minutes);

    List<RouteEntity>? GetRoutesWhereTrolleybusAndSkip(int number, int skipNumber);
    
    List<RouteEntity>? GetRoutesSortedByTravelTime();

    List<RouteDtoGroupedByNumberOfTrolleybuses<int?>>
        GetRoutesWithTravelTimeMoreThanAndGroupedByNumberOfTrolleybusesWithNameOfStartingAndEndingStopsAndAverageTravelTimeAndLongestRouteInGroup(
            float minutes, string startStopName, string endStopName);

    List<RouteDtoWhereNumberOfTrolleybusesMoreThan>? GetRoutesWithTrolleybusesMoreThanAndAverageTravelTime(int trolleybusesCount);

    float GetSumTravelTime();
}