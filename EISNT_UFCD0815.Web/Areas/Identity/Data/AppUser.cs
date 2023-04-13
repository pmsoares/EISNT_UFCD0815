using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EISNT_UFCD0815.Web.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [Required]
    public string Name { get; set; } = null!;

    public string? StreetAddress { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }
}

