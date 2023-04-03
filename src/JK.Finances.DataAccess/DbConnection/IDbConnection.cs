namespace JK.Finances.DataAccess.DbConnection;

public interface IDbConnection
{
    IMongoCollection<AccountModel> AccountCollection { get; }
    MongoClient Client { get; }
}