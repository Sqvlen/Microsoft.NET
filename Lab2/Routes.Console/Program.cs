using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Routes.Infrastructure.Database.Generators;
using Routes.Infrastructure.Database.Repositories;
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
        var xml = XmlCustomSerializer.Serialize(generator.GenerateRouteEntity(15));
        
        using (var writer = new StreamWriter(fileName))
        {
            writer.Write(xml);
        }
        
        var document = XDocument.Parse(File.ReadAllText(fileName));
        var menuExtension = new MenuExtensions(new RouteRepository(document));
        
        menuExtension.Open();
    }
}