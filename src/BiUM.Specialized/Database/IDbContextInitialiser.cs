namespace BiUM.Specialized.Database;

public partial interface IDbContextInitialiser
{
    Task InitialiseAsync();
    Task SeedAsync();
}