using Bogus;
using Routes.Infrastructure.Entities;

namespace Routes.Infrastructure.Database.Generators;

public static class AppDataGenerator
{
    public static AppDbContext Generate(this AppDbContext dbContext)
    {
        dbContext.Cities =
        [
            new CityEntity()
            {
                Name = "Миколаїв"
            },

            new CityEntity()
            {
                Name = "Київ"
            },

            new CityEntity()
            {
                Name = "Донецьк"
            }
        ];
        
        return dbContext;
    }
}