using Bogus;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Generators;

public class AppDataGenerator
{
    public static AppDbContext Generate()
    {
        var cities = GenerateCities();
        
        var context = new AppDbContext
        {
            Cities = cities,
        };
        
        return context;
    }

    private static List<CityEntity> GenerateCities()
    {
        var faker = new Faker();

        var stopFaker = new Faker<StopEntity>()
            .UseSeed(DataGeneratorOptions.Seed)
            .RuleFor(s => s.Id, f => f.Random.Long())
            .RuleFor(s => s.StopName, f => f.Address.City());

        var routeFaker = new Faker<RouteEntity>()
            .UseSeed(DataGeneratorOptions.Seed)
            .RuleFor(r => r.Id, f => f.Random.Long())
            .RuleFor(r => r.Name, f => f.Lorem.Word())
            .RuleFor(r => r.StartStopEntity, f => stopFaker.Generate())
            .RuleFor(r => r.EndStopEntity, f => stopFaker.Generate())
            .RuleFor(r => r.TravelTime, f => f.Date.Future());

        var trolleybusFaker = new Faker<TrolleybusEntity>()
            .UseSeed(DataGeneratorOptions.Seed)
            .RuleFor(t => t.Id, f => f.Random.Long())
            .RuleFor(t => t.Route, f => routeFaker.Generate())
            .RuleFor(t => t.Number, f => f.Random.Int(1, 100));

        var cityFaker = new Faker<CityEntity>()
            .UseSeed(DataGeneratorOptions.Seed)
            .RuleFor(c => c.Id, f => f.Random.Long())
            .RuleFor(c => c.Routes, f => routeFaker.Generate(f.Random.Int(1, 5)));

        return cityFaker.Generate(DataGeneratorOptions.CityCount);
    }
}