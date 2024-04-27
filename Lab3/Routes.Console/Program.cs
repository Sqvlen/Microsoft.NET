using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.DependencyInjection;
using Routes.Infrastructure.Database.Generators;
using Routes.Infrastructure.Database.Repositories;
using Routes.Infrastructure.Entities;
using Routes.Json.Core.JsonWriter;
using Routes.RestApi.Extensions;

namespace Routes.RestApi;

public static class Program
{
    internal static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.ConfigureService();

        var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".json";

        var generator = new BogusGenerator();
        var entities = generator.GenerateRouteEntity(15);

        JsonCustomWriter.Write(new JsonWriterParams() { Data = entities, FileName = fileName, Name = "Routes" });

        // var document = JsonDocument;

        // Example 7/Program.cs - зчитування даних з файлу
        var trolleybusEntities = JsonNode.Parse(File.ReadAllText(fileName))!.AsArray()
            .SelectMany(x => x["Trolleybuses"].Deserialize<IEnumerable<TrolleybusEntity>>());
        var routesEntities = JsonNode.Parse(File.ReadAllText(fileName)).Deserialize<IEnumerable<RouteEntity>>()!;

        var menuExtension = new MenuExtensions(new RouteRepository(routesEntities),
            new TrolleybusRepository(trolleybusEntities));
        menuExtension.Open();
    }
}