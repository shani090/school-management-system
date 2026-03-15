using System;
using System.Collections.Generic;

namespace UserManagementService.Models;

public partial class College
{
    public int CollegeId { get; set; }

    public string CollegeName { get; set; } = null!;

    public string CollegeCode { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
