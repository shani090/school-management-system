using System;
using System.Collections.Generic;

namespace ExamService.Models;

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

    public virtual Class Class { get; set; } = null!;

    public virtual College College { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
