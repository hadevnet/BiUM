namespace BiUM.Core.Database;

public partial interface IDbContextInitialiser
{
    Task InitialiseAsync();
    Task SeedAsync();
}