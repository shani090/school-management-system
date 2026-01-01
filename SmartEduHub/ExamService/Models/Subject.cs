using System;
using System.Collections.Generic;

namespace ExamService.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public int CollegeId { get; set; }

    public string SubjectName { get; set; } = null!;

    public int ClassId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual College College { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
