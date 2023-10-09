using BlazorMinimalApis.Endpoints.Pages.Home;

namespace BlazorMinimalApis.Endpoints;

public static class PageEndpoints
{
    public static WebApplication MapPageEndpoints(this WebApplication app)
    {
        app.MapGet("/", new HomeHandler().Index)
            .WithName("Home");

		app.MapGet("/random-number", new HomeHandler().RandomNumber)
			.WithName("Home.RandomNumber");

		return app;
    }
}

