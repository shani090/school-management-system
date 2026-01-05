using System;
using System.Collections.Generic;

namespace UserManagementService.Models;

public partial class RevokedToken
{
    public int Id { get; set; }

    public string TokenHash { get; set; } = null!;

    public DateTime? RevokedAt { get; set; }

    public DateTime ExpiresAt { get; set; }
}
