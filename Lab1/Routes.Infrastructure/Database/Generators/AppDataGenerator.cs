using Bogus;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Generators;

public static class AppDataGenerator
{
    public static AppDbContext Generate(this AppDbContext dbContext)
    {
        var stop1 = new StopEntity()
        {
            StopName = "Майдан Незалежності"
        };

        var stop2 = new StopEntity()
        {
            StopName = "Лук'янівська"
        };

        var stop3 = new StopEntity()
        {
            StopName = "Соборна"
        };

        var stop4 = new StopEntity()
        {
            StopName = "Зупинка 4"
        };

        var stop5 = new StopEntity()
        {
            StopName = "Зупинка 5"
        };

        var stop6 = new StopEntity()
        {
            StopName = "Зупинка 6"
        };

        var stop7 = new StopEntity()
        {
            StopName = "Зупинка 7"
        };

        var stop8 = new StopEntity()
        {
            StopName = "Зупинка 8"
        };

        var stop9 = new StopEntity()
        {
            StopName = "Майдан Незалежності"
        };

        var stop10 = new StopEntity()
        {
            StopName = "Лук'янівська"
        };

        var stop11 = new StopEntity()
        {
            StopName = "Соборна"
        };

        var stop12 = new StopEntity()
        {
            StopName = "Зупинка 12"
        };

        var stop13 = new StopEntity()
        {
            StopName = "Зупинка 13"
        };

        var stop14 = new StopEntity()
        {
            StopName = "Зупинка 14"
        };

        var stop15 = new StopEntity()
        {
            StopName = "Зупинка 15"
        };

        var stop16 = new StopEntity()
        {
            StopName = "Зупинка 16"
        };

        var stop17 = new StopEntity()
        {
            StopName = "Зупинка 17"
        };

        var stop18 = new StopEntity()
        {
            StopName = "Зупинка 18"
        };

        dbContext.Stops =
        [
            stop1, stop2, stop3, stop4, stop5, stop6, stop7, stop8, stop9, stop10, stop11, stop12, stop13, stop14,
            stop15, stop16, stop17, stop18
        ];

        var route1 = new RouteEntity()
        {
            Name = "Київ - Зелений",
            Number = 1,
            StartStopEntity = stop1,
            EndStopEntity = stop2,
            TravelTime = 50
        };

        var route2 = new RouteEntity()
        {
            Name = "Київ - Червоний",
            Number = 2,
            StartStopEntity = stop3,
            EndStopEntity = stop4,
            TravelTime = 20
        };

        var route3 = new RouteEntity()
        {
            Name = "Київ - Синій",
            Number = 3,
            StartStopEntity = stop5,
            EndStopEntity = stop6,
            TravelTime = 100
        };

        var route4 = new RouteEntity()
        {
            Name = "Миколаїв - Зелений",
            Number = 4,
            StartStopEntity = stop7,
            EndStopEntity = stop8,
            TravelTime = 50
        };

        var route5 = new RouteEntity()
        {
            Name = "Миколаїв - Червоний",
            Number = 5,
            StartStopEntity = stop9,
            EndStopEntity = stop10,
            TravelTime = 20
        };

        var route6 = new RouteEntity()
        {
            Name = "Миколаїв - Синій",
            Number = 6,
            StartStopEntity = stop11,
            EndStopEntity = stop12,
            TravelTime = 100
        };

        var route7 = new RouteEntity()
        {
            Name = "Донецьк - Зелений",
            Number = 7,
            StartStopEntity = stop13,
            EndStopEntity = stop14,
            TravelTime = 50
        };

        var route8 = new RouteEntity()
        {
            Name = "Донецьк - Червоний",
            Number = 8,
            StartStopEntity = stop15,
            EndStopEntity = stop16,
            TravelTime = 20
        };

        var route9 = new RouteEntity()
        {
            Name = "Донецьк - Синій",
            Number = 9,
            StartStopEntity = stop17,
            EndStopEntity = stop18,
            TravelTime = 100
        };

        var trolleybus1 = new TrolleybusEntity()
        {
            Number = 1,
            Routes = new List<RouteEntity>()
            {
                route1, route2
            }
        };

        var trolleybus2 = new TrolleybusEntity()
        {
            Number = 2,
            Routes = new List<RouteEntity>()
            {
                route1
            }
        };

        var trolleybus3 = new TrolleybusEntity()
        {
            Number = 3,
            Routes = new List<RouteEntity>()
            {
                route2, route3
            }
        };

        var trolleybus4 = new TrolleybusEntity()
        {
            Number = 4,
            Routes = new List<RouteEntity>()
            {
                route1, route4
            }
        };

        var trolleybus5 = new TrolleybusEntity()
        {
            Number = 5,
            Routes = new List<RouteEntity>()
            {
                route6, route4
            }
        };

        var trolleybus6 = new TrolleybusEntity()
        {
            Number = 6,
            Routes = new List<RouteEntity>()
            {
                route8, route1
            }
        };

        var trolleybus7 = new TrolleybusEntity()
        {
            Number = 7,
            Routes = new List<RouteEntity>()
            {
                route1, route9
            }
        };

        var trolleybus8 = new TrolleybusEntity()
        {
            Number = 8,
            Routes = new List<RouteEntity>()
            {
                route5
            }
        };

        var trolleybus9 = new TrolleybusEntity()
        {
            Number = 9,
            Routes = new List<RouteEntity>()
            {
                route4
            }
        };

        var trolleybus10 = new TrolleybusEntity()
        {
            Number = 10,
            Routes = new List<RouteEntity>()
            {
                route1, route2
            }
        };

        var trolleybus11 = new TrolleybusEntity()
        {
            Number = 11,
            Routes = new List<RouteEntity>()
            {
                route4
            }
        };

        var trolleybus12 = new TrolleybusEntity()
        {
            Number = 12,
            Routes = new List<RouteEntity>()
            {
                route5
            }
        };

        var trolleybus13 = new TrolleybusEntity()
        {
            Number = 13,
            Routes = new List<RouteEntity>()
            {
                route4, route5
            }
        };

        var trolleybus14 = new TrolleybusEntity()
        {
            Number = 14,
            Routes = new List<RouteEntity>()
            {
                route4
            }
        };

        var trolleybus15 = new TrolleybusEntity()
        {
            Number = 15,
            Routes = new List<RouteEntity>()
            {
                route5
            }
        };

        var trolleybus16 = new TrolleybusEntity()
        {
            Number = 16,
            Routes = new List<RouteEntity>()
            {
                route7, route8
            }
        };

        var trolleybus17 = new TrolleybusEntity()
        {
            Number = 17,
            Routes = new List<RouteEntity>()
            {
                route8
            }
        };

        var trolleybus18 = new TrolleybusEntity()
        {
            Number = 18,
            Routes = new List<RouteEntity>()
            {
                route9, route7
            }
        };

        route1.Trolleybuses = new List<TrolleybusEntity>
            { trolleybus10, trolleybus7, trolleybus6, trolleybus4, trolleybus2, trolleybus1 };
        route2.Trolleybuses = new List<TrolleybusEntity> { trolleybus10, trolleybus3, trolleybus1 };
        route3.Trolleybuses = new List<TrolleybusEntity> { trolleybus3 };
        route4.Trolleybuses = new List<TrolleybusEntity>
            { trolleybus14, trolleybus13, trolleybus11, trolleybus9, trolleybus5, trolleybus4 };
        route5.Trolleybuses = new List<TrolleybusEntity> { trolleybus13, trolleybus15, trolleybus12, trolleybus8 };
        route6.Trolleybuses = new List<TrolleybusEntity> { trolleybus5 };
        route7.Trolleybuses = new List<TrolleybusEntity> { trolleybus18, trolleybus16 };
        route8.Trolleybuses = new List<TrolleybusEntity> { trolleybus17, trolleybus16, trolleybus6 };
        route9.Trolleybuses = new List<TrolleybusEntity> { trolleybus18, trolleybus7 };

        dbContext.Trolleybuses =
        [
            trolleybus1, trolleybus2, trolleybus3, trolleybus4, trolleybus5, trolleybus6, trolleybus7, trolleybus8,
            trolleybus9, trolleybus10, trolleybus11, trolleybus12, trolleybus13, trolleybus14, trolleybus15,
            trolleybus16, trolleybus17, trolleybus18
        ];

        dbContext.Routes =
        [
            route1, route2, route3, route4, route5, route6, route7, route8, route9
        ];

        dbContext.Cities =
        [
            new CityEntity()
            {
                Name = "Миколаїв",
                Routes = new List<RouteEntity>()
                {
                    route1, route2, route3
                }
            },

            new CityEntity()
            {
                Name = "Київ",
                Routes = new List<RouteEntity>()
                {
                    route4, route5, route6
                }
            },

            new CityEntity()
            {
                Name = "Донецьк",
                Routes = new List<RouteEntity>()
                {
                    route7, route8, route9
                }
            }
        ];

        return dbContext;
    }
}