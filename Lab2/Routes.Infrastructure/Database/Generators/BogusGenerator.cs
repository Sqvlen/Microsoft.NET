using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Generators;

public class BogusGenerator
{
    private readonly Bogus.Faker<RouteEntity> _routeFaker;
    private readonly Bogus.Faker<StopEntity> _stopFaker;
    private readonly Bogus.Faker<TrolleybusEntity> _trolleybusFaker;

    public BogusGenerator()
    {
        _stopFaker = new Bogus.Faker<StopEntity>()
            .RuleFor(s => s.Id, f => f.IndexFaker)
            .RuleFor(s => s.StopName, f => f.Address.StreetName());

        _trolleybusFaker = new Bogus.Faker<TrolleybusEntity>()
            .RuleFor(t => t.Id, f => f.IndexFaker)
            .RuleFor(t => t.Number, f => f.Random.Int(1, 100));

        _routeFaker = new Bogus.Faker<RouteEntity>()
            .RuleFor(r => r.Id, f => f.IndexFaker)
            .RuleFor(r => r.Name, f => f.Address.State())
            .RuleFor(r => r.Number, f => f.Random.Int(1, 100))
            .RuleFor(r => r.StartStopEntity, _stopFaker.Generate())
            .RuleFor(r => r.EndStopEntity, _stopFaker.Generate())
            .RuleFor(r => r.Trolleybuses, f => _trolleybusFaker.Generate(f.Random.Int(1, 5)).ToList())
            .RuleFor(r => r.TravelTime, f => f.Random.Int(25, 50));
    }

    public List<RouteEntity> GenerateRouteEntity(int count)
    {
        return _routeFaker.Generate(count);
    }

    public List<StopEntity> GenerateStopEntity(int count)
    {
        return _stopFaker.Generate(count);
    }

    public List<TrolleybusEntity> GenerateTrolleybusEntity(int count)
    {
        return _trolleybusFaker.Generate(count);
    }
}
