using System;
using System.Collections.Generic;

namespace AttendanceService.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int CollegeId { get; set; }

    public string? AdmissionNo { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string? Gender { get; set; }

    public int ClassId { get; set; }

    public string? ParentName { get; set; }

    public string? ContactInfo { get; set; }

    public string? Address { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual College College { get; set; } = null!;
}
