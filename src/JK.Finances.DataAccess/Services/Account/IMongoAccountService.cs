namespace JK.Finances.DataAccess.Services.Account;

public interface IMongoAccountService
{
    Task<string> CreateAccountAsync(AccountModel account);
    Task<bool> DeleteAccountAsync(string id);
    Task<AccountModel> GetAccountAsync(string id);
    Task<List<AccountModel>> GetAccountsAsync();
    Task<string> UpdateAccountAsync(AccountModel account);
}