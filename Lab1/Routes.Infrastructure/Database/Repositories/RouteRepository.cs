using System.Collections;
using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;
using Routes.Infrastructure.Entities.Dtos;

namespace Routes.Infrastructure.Database.Repositories;

public class RouteRepository(AppDbContext dbContext) : IRouteRepository
{
    public List<RouteEntity>? GetRoutesWhereTravelTimeMoreThan(float minutes)
    {
        return dbContext.Routes.Where(x => x.TravelTime > minutes).ToList();
    }

    public List<RouteEntity>? GetRoutesThatRunThroughStop(string stopName)
    {
        return dbContext.Routes
            .Where(x => x.StartStopEntity?.StopName == stopName || x.EndStopEntity?.StopName == stopName).ToList();
    }

    public List<RouteEntity>? GetRoutesWithTrolleybusesMoreThan(int trolleybusesCount)
    {
        return dbContext.Routes.Where(x => x.Trolleybuses?.Count > trolleybusesCount).ToList();
    }

    public List<RouteEntity>? GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThan(float minutes,
        int trolleybusesCount)
    {
        return dbContext.Routes.Where(x => x.Trolleybuses?.Count > trolleybusesCount && x.TravelTime < minutes)
            .ToList();
    }

    public List<RouteEntity>? GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThanAndSortedByTravelTime(
        float minutes,
        int trolleybusesCount)
    {
        return dbContext.Routes.Where(x => x.Trolleybuses?.Count > trolleybusesCount && x.TravelTime < minutes)
            .OrderBy(x => x.TravelTime)
            .ToList();
    }

    public List<RouteDtoWhereTimeTravelMoreThanAndGroupedByNumberOfTrolleybusInRoute<int?>>
        GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRoute(float minutes)
    {
        return dbContext.Routes.Where(x => x.TravelTime > minutes)
            .GroupBy(x => x.Trolleybuses?.Count)
            .Select(x => new RouteDtoWhereTimeTravelMoreThanAndGroupedByNumberOfTrolleybusInRoute<int?>
            {
                NumberTrolleybus = x.Key,
                Routes = x.ToList()
            }).ToList();
    }

    public List<RouteEntity> GetRoutesWhereTravelTimeMoreThanAndTake(float minutes, int numberTake)
    {
        return dbContext.Routes.Where(x => x.TravelTime > minutes)
            .OrderByDescending(x => x.TravelTime)
            .Take(numberTake)
            .ToList();
    }

    public List<RouteDtoWhereTravelTimeMoreThanAndGroupedByNumberOfTrolleybuses<int?>>
        GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRouteAndNumberRoutesInGroup(float minutes)
    {
        return dbContext.Routes.Where(x => x.TravelTime > minutes)
            .GroupBy(x => x.Trolleybuses?.Count)
            .Select(x => new RouteDtoWhereTravelTimeMoreThanAndGroupedByNumberOfTrolleybuses<int?>
            {
                NumberTrolleybus = x.Key,
                RouteCount = x.Count()
            }).ToList();
    }

    public List<RouteEntity>? GetRoutesWhereTrolleybusAndSkip(int number, int skipNumber)
    {
        return dbContext.Trolleybuses.Where(x => x.Number == number).Skip(skipNumber).SelectMany(x => x.Routes!)
            .ToList();
    }

    public List<RouteEntity>? GetRoutesSortedByTravelTime()
    {
        return dbContext.Routes.OrderBy(x => x.TravelTime).ToList();
    }

    public List<RouteEntity>? GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesCountOnRouteAndSortedByTravelTime(
        float minutes)
    {
        throw new NotImplementedException();
    }

    public List<RouteDtoGroupedByNumberOfTrolleybuses<int?>>
        GetRoutesWithTravelTimeMoreThanAndGroupedByNumberOfTrolleybusesWithNameOfStartingAndEndingStopsAndAverageTravelTimeAndLongestRouteInGroup(
            float minutes, string startStopName, string endStopName)
    {
        return dbContext.Routes.Where(x => x.TravelTime > minutes)
            .GroupBy(x => x.Trolleybuses?.Count)
            .Select(x => new RouteDtoGroupedByNumberOfTrolleybuses<int?>()
            {
                TrolleybusNumber = x.Key,
                Routes = x.Select(t => new RouteDto()
                {
                    RouteName = t.Name,
                    StartStop = t.StartStopEntity?.StopName!,
                    EndStop = t.EndStopEntity?.StopName!,
                    AverageTravelTime = t.TravelTime
                }).ToList(),
                LongestRoute = x.MaxBy(t => t.TravelTime)
            }).ToList();
    }

    public List<RouteDtoWhereNumberOfTrolleybusesMoreThan>? GetRoutesWithTrolleybusesMoreThanAndAverageTravelTime(int trolleybusesCount)
    {
        return dbContext.Routes.Where(x => x.Trolleybuses?.Count == trolleybusesCount)
            .Select(x => new RouteDtoWhereNumberOfTrolleybusesMoreThan
            {
                RouteName = x.Name,
                AverageTravelTime = x.TravelTime
            }).ToList();
    }

    public float GetSumTravelTime()
    {
        return dbContext.Routes.Sum(x => x.TravelTime);
    }
}