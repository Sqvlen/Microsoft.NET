using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Routes.Infrastructure.Database.Generators;
using Routes.Infrastructure.Database.Repositories;
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
        var json = JsonConvert.SerializeObject(generator.GenerateRouteEntity(15));
        
        File.WriteAllText(fileName, json);
        
        var document = JsonDocument.Parse(File.ReadAllText(fileName));
        var jsonNode = JsonNode.Parse(File.ReadAllText(fileName));
        var menuExtension = new MenuExtensions(new RouteRepository(document), new TrolleybusRepository(jsonNode));
        
        menuExtension.Open();
    }
}