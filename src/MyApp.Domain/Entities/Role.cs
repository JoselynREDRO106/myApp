using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MyApp.Domain.Entities;

public class Role : IdentityRole<string>
{
    public ICollection<UserRole> UserRoles { get; set; }
}
