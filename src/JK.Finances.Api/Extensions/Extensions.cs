namespace JK.Finances.Api.Extensions;

public static class Extensions
{
    public static void RegisterSwagger(this WebApplication app)
    {
        if (bool.TryParse(app.Configuration["UseSwagger"], out var useSwagger) && useSwagger)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }

    public static RouteGroupBuilder MapAccountsApi(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id}", async ([FromRoute]string id, IMongoAccountService accountService) =>
        {
            var result = await accountService.DeleteAccountAsync(id);
            return result ? Results.Ok() : Results.NotFound();
        });

        group.MapGet("/", async (IMongoAccountService accountService) =>
        {
            var result = await accountService.GetAccountsAsync();
            var response = new GetAccountsResponse(result);
            return Results.Ok(response);
        })
        .Produces<GetAccountsResponse>();

        group.MapGet("/{id}", async ([FromRoute]string id, IMongoAccountService accountService) =>
        {
            var result = await accountService.GetAccountAsync(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        });

        group.MapPost("/", async ([FromBody] CreateAccountRequest request, IMongoAccountService accountService) =>
        {
            var result = await accountService.CreateAccountAsync(new()
            {
                Name = request.Name
            });

            return result is null ? Results.NotFound() : Results.Created($"/accounts/{result.Id}", result);
        });

        group.MapPut("/{id}", async ([FromRoute]string id, [FromBody]UpdateAccountRequest request, IMongoAccountService accountService) =>
        {
            var result = await accountService.UpdateAccountAsync(id, request);

            return result is null ? Results.NotFound() : Results.Created($"/accounts/{result}", result);
        });

        return group;
    }
}