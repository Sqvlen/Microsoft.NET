using Lab4.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lab4.Console;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLab4Services();

        var menu = new MenuExtensions();
        menu.Process();
    }
}