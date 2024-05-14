using System.Xml;
using Routes.Infrastructure.Database.Abstractions;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Repositories;

public class TrolleybusRepository(XmlDocument xmlDocument) : ITrolleybusRepository
{
    public TrolleybusEntity? GetTrolleybusWithLargestNumberRoutes()
    {
        return null;
    }
}