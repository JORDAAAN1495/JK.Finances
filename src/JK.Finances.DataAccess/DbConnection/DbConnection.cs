namespace JK.Finances.DataAccess.DbConnection;

public class DbConnection : IDbConnection
{
    private const string ConnectionStringName = "Mongo";
    private const string DatabaseName = "JKFinances";

    public MongoClient Client { get; private set; }

    public IMongoCollection<AccountModel> AccountCollection { get; private set; }

    public DbConnection(IConfiguration configuration)
    {
        Client = new(configuration.GetConnectionString(ConnectionStringName));
        var database = Client.GetDatabase(DatabaseName);
        AccountCollection = database.GetCollection<AccountModel>(nameof(AccountCollection));
    }
}