namespace JK.Finances.DataAccess.Services.Account;

public interface IMongoAccountService
{
    Task<AccountModel> CreateAccountAsync(AccountModel account);
    Task<bool> DeleteAccountAsync(string id);
    Task<AccountModel> GetAccountAsync(string id);
    Task<List<AccountModel>> GetAccountsAsync();
    Task<AccountModel> UpdateAccountAsync(string id, UpdateAccountRequest updateAccountRequest);
}