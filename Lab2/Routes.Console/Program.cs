using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Routes.Infrastructure.Database.Generators;
using Routes.Infrastructure.Database.Repositories;
using Routes.Infrastructure.Entities;
using Routes.RestApi.Extensions;
using Routes.Xml.Core.Reader;
using Routes.Xml.Core.Writer;

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

        XmlCustomWriter.Write<IEnumerable<RouteEntity>>(new XmlWriterParams()
            { Data = entities, FileName = fileName, XmlSectionName = "Routes" });
        
        var xmlReader = new XmlCustomReader();
        var data = xmlReader.Read<List<RouteEntity>>(new XmlReaderParams()
            { ElementName = "Routes", FileName = fileName });

        var menuExtension = new MenuExtensions(new RouteRepository(data));
        
        menuExtension.Open();
    }
}