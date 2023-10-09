using BlazorMinimalApis.Data;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Features.Contacts;

[Mapper]
public partial class CreateContactMapper
{
    public partial CreateContactForm ContactToForm(Contact contact);
    public partial Contact FormToContact(CreateContactForm contact);
}