using BlazorMinimalApis.Data;
using BlazorMinimalApis.Features.Contacts.Components;
using BlazorMinimalApis.Features.Contacts.Models;
using BlazorMinimalApis.Lib.Routing;
using BlazorMinimalApis.Lib.Session;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMinimalApis.Features.Contacts;

public class ContactHandler : PageHandler
{
    public IResult List()
    {
        var model = new ContactModel
        {
            Contacts = Database.Contacts
        };
        var parameters = new { Model = model };
        return Page<List>(parameters);
    }

    public IResult Search([FromQuery] string contactSearch)
    {
        var contacts = Database.Contacts
                               .Where(c => c.Name.Contains(contactSearch, StringComparison.OrdinalIgnoreCase))
                               .ToList();
        var model = new { Contacts = contacts };
        return Page<ContactsTable>(model);
    }

    public IResult Create()
    {
        var model = new { Form = new CreateContactForm() };
        return Page<Create>(model);
    }

    [HttpPost]
    public IResult Store([FromForm] CreateContactForm form, SessionManager Session)
    {
        if (Validate(form).HasErrors)
        {
            var model = new { Form = form };
            return Page<Create>(model);
        }

        var newContact = new CreateContactMapper().FormToContact(form);
        newContact.Id = Database.Contacts.OrderByDescending(contact => contact.Id).First().Id + 1;

        Database.Contacts.Add(newContact);

        Session.SetFlash("success", "Contact successfully added.");
        return List();
    }

    public IResult Edit(int id)
    {
        var record = Database.Contacts.FirstOrDefault(x => x.Id == id);
        if (record == null) return List();

        var form = new EditContactMapper().ContactToForm(record);
        var model = new { Form = form };

        return Page<Edit>(model);
    }

    public IResult Update(int id, [FromForm] EditContactForm form)
    {
        var validation = Validate(form);
        if (validation.HasErrors)
        {
            var model = new { Form = form };
            return Page<Edit>(model);
        }

        var oldContact = Database.Contacts.FirstOrDefault(x => x.Id == id);
        if (oldContact == null) return List();
        var newContact = new EditContactMapper().FormToContact(form);
        newContact.Id = oldContact.Id;
        Database.Contacts.Add(newContact);
        Database.Contacts.Remove(oldContact);

        return List();
    }

    public IResult Delete(int id)
    {
        var contact = Database.Contacts.FirstOrDefault(x => x.Id == id);
        if (contact == null) return List();
        Database.Contacts.Remove(contact);
        return List();
    }

    public IResult Redir([FromServices] LinkGenerator Link)
    {
        return Redirect(Link.GetPathByName("Contacts"));
    }
}