using System;
using System.Collections.Generic;

namespace AttendanceService.Models;

public partial class College
{
    public int CollegeId { get; set; }

    public string CollegeName { get; set; } = null!;

    public string CollegeCode { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
