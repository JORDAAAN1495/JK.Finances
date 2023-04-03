namespace JK.Finances.Infrastructure.Models.Account.Responses;

public class GetAccountsResponse
{
    public List<AccountModel> Accounts { get; set; } = Enumerable.Empty<AccountModel>().ToList();
    public int AccountsCount { get; set; }

    public GetAccountsResponse(List<AccountModel> accounts) : this()
    {
        Accounts = Guard.Against.Null(accounts);
        AccountsCount = accounts.Count;
    }

    private GetAccountsResponse() { }
}