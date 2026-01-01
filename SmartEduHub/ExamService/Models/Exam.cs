using System;
using System.Collections.Generic;

namespace ExamService.Models;

public partial class Exam
{
    public int ExamId { get; set; }

    public int CollegeId { get; set; }

    public string ExamName { get; set; } = null!;

    public int SubjectId { get; set; }

    public int ClassId { get; set; }

    public DateOnly ExamDate { get; set; }

    public int MaxMarks { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual College College { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Subject Subject { get; set; } = null!;
}
