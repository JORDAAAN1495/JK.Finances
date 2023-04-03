namespace JK.Finances.DataAccess.Services.Account;

public class MongoAccountService : IMongoAccountService
{
    private readonly IMongoCollection<AccountModel> _accounts;

    private readonly ReplaceOptions _replaceOptions = new()
    {
        IsUpsert = true
    };

    public MongoAccountService(IDbConnection dbConnection)
    {
        _accounts = dbConnection.AccountCollection;
    }

    public async Task<List<AccountModel>> GetAccountsAsync()
    {
        var results = (await _accounts.FindAsync(x => true)).ToList();

        return results is not null ? results : Enumerable.Empty<AccountModel>().ToList();
    }

    public async Task<AccountModel> GetAccountAsync(string id)
    {
        return (await _accounts.FindAsync(x => x.Id == id)).FirstOrDefault();
    }

    public async Task<string> CreateAccountAsync(AccountModel account)
    {
        await _accounts.InsertOneAsync(account);
        return account.Id;
    }

    public async Task<string> UpdateAccountAsync(AccountModel account)
    {
        var filter = Builders<AccountModel>.Filter.Eq("Id", account.Id);
        var result = await _accounts.ReplaceOneAsync(filter, account, _replaceOptions);

        return result.IsAcknowledged && result.ModifiedCount == 1 ? result.UpsertedId.AsString : string.Empty;
    }

    public async Task<bool> DeleteAccountAsync(string id)
    {
        var result = await _accounts.DeleteOneAsync(x => x.Id == id);
        return result.IsAcknowledged && result.DeletedCount == 1;
    }
}