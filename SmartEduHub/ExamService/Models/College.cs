using System;
using System.Collections.Generic;

namespace ExamService.Models;

public partial class College
{
    public int CollegeId { get; set; }

    public string CollegeName { get; set; } = null!;

    public string CollegeCode { get; set; } = null!;

    public string? Address { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
