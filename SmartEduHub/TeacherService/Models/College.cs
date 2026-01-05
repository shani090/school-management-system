using System;
using System.Collections.Generic;

namespace TeacherService.Models;

public partial class College
{
    public int CollegeId { get; set; }

    public string CollegeName { get; set; } = null!;

    public string CollegeCode { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
