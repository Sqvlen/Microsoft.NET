namespace Lab4.Infrastructure.Applicant.PolymorphicFactoryMethod;

public class LoggerProviderFactory
{
    public enum LoggingProvider
    {
        Json,
        Xml,
        Console
    }
    
    public static ILogger GetLoggingProvider(LoggingProvider loggingProvider)
    {
        switch (loggingProvider)
        {
            case LoggingProvider.Json:
                return new JsonLogger();
            case LoggingProvider.Xml:
                return new XmlLogger();
            case LoggingProvider.Console:
                return new ConsoleLogger();
            default:
                return new ConsoleLogger();
        }
    }
}