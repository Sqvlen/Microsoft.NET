using Routes.Infrastructure.Database;
using Routes.Infrastructure.Database.Generators;
using Routes.Infrastructure.Database.Repositories;
using Routes.RestApi.Extensions;

public static class Program
{
    internal static void Main(string[] args)
    {
        var dbContext = new AppDbContext().Generate();
        var menuExtension = new MenuExtensions(new CityRepository(dbContext), new RouteRepository(dbContext),
            new TrolleybusRepository(dbContext), new StopRepository(dbContext));
        menuExtension.Open();
    }
}