using System.Collections;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Abstractions;

public interface IRouteRepository
{
    List<RouteEntity>? GetRoutesWhereTravelTimeMoreThan(float minutes);
    List<RouteEntity>? GetRoutesThatRunThroughStop(string stopName);
    List<RouteEntity>? GetRoutesWithTrolleybusesMoreThan(int trolleybusesCount);
    List<RouteEntity>? GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThan(float minutes, int trolleybusesCount);
    List<RouteEntity>? GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThanAndSortedByTravelTime(float minutes, int trolleybusesCount);
    IEnumerable? GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRoute(float minutes);
    List<RouteEntity> GetRoutesWhereTravelTimeMoreThanAndTake(float minutes, int numberTake);
    IEnumerable? GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRouteAndNumberRoutesInGroup(
        float minutes);

    List<RouteEntity>? GetRoutesWhereTrolleybusAndSkip(int number, int skipNumber);
    
    List<RouteEntity>? GetRoutesSortedByTravelTime();

    List<RouteEntity>? GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesCountOnRouteAndSortedByTravelTime(
        float minutes);

    IEnumerable?
        GetRoutesWithTravelTimeMoreThanAndGroupedByNumberOfTrolleybusesWithNameOfStartingAndEndingStopsAndAverageTravelTimeAndLongestRouteInGroup(
            float minutes, string startStopName, string endStopName);

    IEnumerable? GetRoutesWithTrolleybusesMoreThanAndAverageTravelTime(int trolleybusesCount);

    float GetSumTravelTime();
}