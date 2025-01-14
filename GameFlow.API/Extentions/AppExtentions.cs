namespace GameFlow.API.Extensions;

public static class AppExtensions
{
    public static WebApplication UseSwaggerWithUI(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameFlow API V1");
            c.RoutePrefix = string.Empty; // Acessar diretamente em https://localhost:7056/
        });

        return app;
    }
}
