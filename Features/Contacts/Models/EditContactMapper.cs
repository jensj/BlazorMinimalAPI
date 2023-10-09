using BlazorMinimalApis.Data;
using Riok.Mapperly.Abstractions;

namespace BlazorMinimalApis.Features.Contacts;

[Mapper]
public partial class EditContactMapper
{
    public partial EditContactForm ContactToForm(Contact contact);
    public partial Contact FormToContact(EditContactForm contact);
}