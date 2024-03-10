using Bogus;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Generators;

public class AppDataGenerator(DataGeneratorOptions generatorOptions)
{
    public static AppDbContext Generate()
    {
        var context = new AppDbContext
        {
            Cities = GenerateCities(),
        };

        var faker = new Faker();

        var stopFaker = new Faker<StopEntity>()
            .RuleFor(s => s.Id, f => f.Random.Long())
            .RuleFor(s => s.StopName, f => f.Address.City());

        var routeFaker = new Faker<RouteEntity>()
            .RuleFor(r => r.Id, f => f.Random.Long())
            .RuleFor(r => r.Name, f => f.Lorem.Word())
            .RuleFor(r => r.StartStopEntity, f => stopFaker.Generate())
            .RuleFor(r => r.EndStopEntity, f => stopFaker.Generate())
            .RuleFor(r => r.TravelTime, f => f.Date.Future());

        var trolleybusFaker = new Faker<TrolleybusEntity>()
            .RuleFor(t => t.Id, f => f.Random.Long())
            .RuleFor(t => t.Route, f => routeFaker.Generate())
            .RuleFor(t => t.Number, f => f.Random.Int(1, 100));

        var cityFaker = new Faker<CityEntity>()
            .RuleFor(c => c.Id, f => f.Random.Long())
            .RuleFor(c => c.Routes, f => routeFaker.Generate(f.Random.Int(1, 5)));
        
        var city = cityFaker.Generate();
        
        return context;
    }
}