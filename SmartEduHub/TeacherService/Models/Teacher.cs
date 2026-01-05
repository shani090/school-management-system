using System;
using System.Collections.Generic;

namespace TeacherService.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public int CollegeId { get; set; }

    public string Name { get; set; } = null!;

    public int SubjectId { get; set; }

    public string? ContactInfo { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual College College { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
