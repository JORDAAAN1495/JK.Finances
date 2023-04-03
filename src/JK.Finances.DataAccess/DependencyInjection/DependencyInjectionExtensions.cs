namespace JK.Finances.DataAccess.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static void AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IDbConnection, DbConnection.DbConnection>();
        services.AddScoped<IMongoAccountService, MongoAccountService>();
    }
}