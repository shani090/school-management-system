using System;
using System.Collections.Generic;

namespace ExamService.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int CollegeId { get; set; }

    public string ClassName { get; set; } = null!;

    public string? Section { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual College College { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
