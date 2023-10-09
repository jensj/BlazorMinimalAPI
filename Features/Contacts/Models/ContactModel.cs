using BlazorMinimalApis.Data;

namespace BlazorMinimalApis.Features.Contacts.Models;

public class ContactModel
{
    public List<Contact> Contacts { get; set; } = new();
}