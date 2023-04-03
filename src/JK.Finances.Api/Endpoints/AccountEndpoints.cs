namespace JK.Finances.Api.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this WebApplication app)
    {
        app.MapGet("/accounts", async (IMongoAccountService accountService) =>
        {
            var result = await accountService.GetAccountsAsync();

            var response = new GetAccountsResponse(result);

            return Results.Ok(response);
        })
        .Produces<GetAccountsResponse>()
        .WithName("GetAccounts")
        .WithOpenApi();

        app.MapPost("/accounts", async ([FromBody]CreateAccountRequest request, IMongoAccountService accountService) =>
        {
            var result = await accountService.CreateAccountAsync(new()
            {
                Name = request.Name
            });

            return string.IsNullOrEmpty(result) ? Results.NotFound() : Results.Created($"/accounts/{result}", result);
        })
        .WithName("CreateAccount")
        .WithOpenApi();
    }
}