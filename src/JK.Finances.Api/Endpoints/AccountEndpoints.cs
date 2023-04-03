namespace JK.Finances.Api.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this WebApplication app)
    {
        app.MapGet("/accounts", async (IMongoAccountService accountService) =>
        {
            var result = await accountService.GetAccountsAsync();
            return Results.Ok(result);
        })
        .WithName("GetAccounts")
        .WithOpenApi();

        app.MapPost("/accounts", async ([FromBody] AccountModel account, IMongoAccountService accountService) =>
        {
            var result = await accountService.CreateAccountAsync(account);
            return string.IsNullOrEmpty(result) ? Results.NotFound() : Results.Created($"/accounts/{result}", result);
        })
        .WithName("CreateAccount")
        .WithOpenApi();
    }
}