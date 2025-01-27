﻿using System.ComponentModel.DataAnnotations;

namespace BlazorMinimalApis.Features.Contacts;

public class CreateContactForm
{
    [Required] public string Name { get; set; }
    [Required][EmailAddress] public string Email { get; set; }
    [Required] public string City { get; set; }
    [Required][Phone] public string Phone { get; set; }
}