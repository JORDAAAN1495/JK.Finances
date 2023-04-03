namespace JK.Finances.DataAccess.Services.Account;

public class MongoAccountService : IMongoAccountService
{
    private readonly IMongoCollection<AccountModel> _accounts;

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

    public async Task<AccountModel> CreateAccountAsync(AccountModel account)
    {
        await _accounts.InsertOneAsync(account);
        return account;
    }

    public async Task<AccountModel> UpdateAccountAsync(string id, UpdateAccountRequest updateAccountRequest)
    {
        var result = await _accounts.FindOneAndUpdateAsync<AccountModel>(x => x.Id == id,
            Builders<AccountModel>.Update
            .Set(x => x.UpdatedDateTime, DateTime.UtcNow)
            .Set(x => x.Name, updateAccountRequest.Name),
            new()
            {
                ReturnDocument = ReturnDocument.After
            });

        return result;
    }

    public async Task<bool> DeleteAccountAsync(string id)
    {
        var result = await _accounts.DeleteOneAsync(x => x.Id == id);
        return result.IsAcknowledged && result.DeletedCount == 1;
    }
}