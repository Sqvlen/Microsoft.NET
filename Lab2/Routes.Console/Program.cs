using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Routes.Infrastructure.Database.Generators;
using Routes.RestApi.Extensions;
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

        XmlCustomWriter.Write(new XmlWriterParams()
            { Data = entities, FileName = fileName, XmlSectionName = "Routes" });

        // var document = XDocument.Parse(File.ReadAllText(fileName));
        // var menuExtension = new MenuExtensions(new RouteRepository(document));
        //
        // menuExtension.Open();
    }
}