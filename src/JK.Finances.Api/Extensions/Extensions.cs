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
}