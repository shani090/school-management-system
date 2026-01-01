using System;
using System.Collections.Generic;

namespace AuthenticationService.Models;

public partial class User
{
    public int UserId { get; set; }

    public int CollegeId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual College College { get; set; } = null!;
}
