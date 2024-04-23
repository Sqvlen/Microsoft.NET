using System.Reflection;
using System.Xml;
using Microsoft.Extensions.DependencyInjection;
using Routes.Infrastructure.Database.Generators;
using Routes.Infrastructure.Entities;
using Routes.Infrastructure.Serializer;
using Routes.RestApi.Extensions;

namespace Routes.RestApi;

public static class Program
{
    internal static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.ConfigureService();
        
        var fileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
        
        var generator = new BogusGenerator();
        var entities = generator.GenerateRouteEntity(15);

        XmlCustomSerializer.Serialize<RouteEntity>(entities, fileName, "Routes");
        
        

        // var document = XDocument.Parse(File.ReadAllText(fileName));
        // var menuExtension = new MenuExtensions(new RouteRepository(document));
        //
        // menuExtension.Open();
    }
}