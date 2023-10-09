namespace BlazorMinimalApis.Features.Contacts;

public static class PageEndpoints
{
    public static WebApplication AddContactFeature(this WebApplication app)
    {
        app.MapGet("/contacts", new ContactHandler().List)
           .WithName("Contacts");

        app.MapGet("/contacts/search", new ContactHandler().Search)
           .WithName("Contacts.Search");

        app.MapGet("/contacts/create", new ContactHandler().Create)
           .WithName("Contacts.Create");

        app.MapPost("/contacts/create", new ContactHandler().Store)
           .WithName("Contacts.Store");

        app.MapGet("/contacts/{id:int}/edit", new ContactHandler().Edit)
           .WithName("Contacts.Edit");

        app.MapPost("/contacts/{id:int}/edit", new ContactHandler().Update)
           .WithName("Contacts.Update");

        app.MapDelete("/contacts/{id:int}/delete", new ContactHandler().Delete)
           .WithName("Contacts.Delete");

        app.MapGet("/contacts/{*all}", new ContactHandler().Redir)
           .WithName("CatchAll");

        return app;
    }
}