﻿using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;
using Routes.Infrastructure.Entities.Dtos;

namespace Routes.Infrastructure.Database.Repositories;

public class RouteRepository(IEnumerable<RouteEntity> entities) : IRouteRepository
{
    public IEnumerable<RouteEntity> GetAll()
    {
        return from route in entities select route;
    }
    
    public RouteEntity? GetRouteByName(string name)
    {
        return entities.AsEnumerable().FirstOrDefault(x => x.Name == name);
    }
    
    public List<RouteEntity> GetRoutesWhereTravelTimeMoreThan(float minutes)
    {
        return entities.Where(x => x.TravelTime > minutes).ToList();
    }
    
    public List<RouteEntity> GetRoutesThatRunThroughStop(string stopName)
    {
        return entities.Where(x => x.StartStopEntity?.StopName == stopName ||
                                                             x.EndStopEntity?.StopName == stopName)
            .ToList();
    }
    
    public List<RouteEntity> GetRoutesWithTrolleybusesMoreThan(int trolleybusesCount)
    {
        return entities
            .Where(x => x.Trolleybuses?.Count > trolleybusesCount).ToList();
    }
    
    public List<RouteEntity> GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThan(float minutes,
        int trolleybusesCount)
    {
        return entities.Where(x =>
                x.Trolleybuses?.Count > trolleybusesCount && x.TravelTime < minutes).ToList();
    }
    
    public List<RouteEntity> GetRoutesWhereTravelTimeLessThanAndTrolleybusesMoreThanAndSortedByTravelTime(
        float minutes,
        int trolleybusesCount)
    {
        return entities.Where(x =>
                x.Trolleybuses?.Count > trolleybusesCount &&
                x.TravelTime < minutes)
            .OrderBy(x => x.TravelTime)
            .ToList();
    }
    
    public List<RouteDtoWhereTimeTravelMoreThanAndGroupedByNumberOfTrolleybusInRoute<int?>>
        GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRoute(float minutes)
    {
        return entities.Where(x => x.TravelTime > minutes)
            .GroupBy(x => x.Trolleybuses?.Count)
            .Select(x => new RouteDtoWhereTimeTravelMoreThanAndGroupedByNumberOfTrolleybusInRoute<int?>
            {
                NumberTrolleybus = x.Key,
                Routes = x.ToList()
            }).ToList();
    }
    
    public List<RouteEntity> GetRoutesWhereTravelTimeMoreThanAndTake(float minutes, int numberTake)
    {
        return entities.Where(x => x.TravelTime > minutes)
            .OrderByDescending(x => x.TravelTime)
            .Take(numberTake)
            .ToList();
    }
    
    public List<RouteDtoWhereTravelTimeMoreThanAndGroupedByNumberOfTrolleybuses<int?>>
        GetRoutesWhereTravelTimeMoreThanAndGroupedByTrolleybusesNumberOnRouteAndNumberRoutesInGroup(float minutes)
    {
        return entities.Where(x => x.TravelTime > minutes)
            .GroupBy(x => x.Trolleybuses?.Count)
            .Select(x => new RouteDtoWhereTravelTimeMoreThanAndGroupedByNumberOfTrolleybuses<int?>
            {
                NumberTrolleybus = x.Key,
                RouteCount = x.Count()
            }).ToList();
    }
    
    public List<RouteEntity> GetRoutesWhereTrolleybusAndSkip(int number, int skipNumber)
    {
        return entities.Where(x => x.Number == number).Skip(skipNumber)
            .ToList();
    }
    
    public List<RouteEntity> GetRoutesSortedByTravelTime()
    {
        return entities.OrderBy(x => x.TravelTime).ToList();
    }
    
    public List<RouteDtoGroupedByNumberOfTrolleybuses<int?>>
        GetRoutesWithTravelTimeMoreThanAndGroupedByNumberOfTrolleybusesWithNameOfStartingAndEndingStopsAndAverageTravelTimeAndLongestRouteInGroup(
            float minutes, string startStopName, string endStopName)
    {
        return entities.Where(x => x.TravelTime > minutes)
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
    
    public List<RouteDtoWhereNumberOfTrolleybusesMoreThan> GetRoutesWithTrolleybusesMoreThanAndAverageTravelTime(
        int trolleybusesCount)
    {
        return entities.Where(x => x.Trolleybuses?.Count == trolleybusesCount)
            .Select(x => new RouteDtoWhereNumberOfTrolleybusesMoreThan
            {
                RouteName = x.Name,
                AverageTravelTime = x.TravelTime
            }).ToList();
    }
    
    public float GetSumTravelTime()
    {
        return entities.Sum(x => x.TravelTime);
    }
}