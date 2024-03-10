namespace Routes.Infrastructure.Database.Generators;

public abstract record DataGeneratorOptions
{
    public int StopCount { get; init; } = 50;
    public int Seed { get; init; } = 30;
}