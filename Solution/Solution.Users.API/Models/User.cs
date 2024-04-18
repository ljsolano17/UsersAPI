using System;
using System.Collections.Generic;

namespace Solution.Users.API.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    public string? Email { get; set; }

    public DateTime? RegistrationDate { get; set; }
}
