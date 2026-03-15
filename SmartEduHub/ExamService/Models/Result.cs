using System;
using System.Collections.Generic;

namespace ExamService.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public int CollegeId { get; set; }

    public int StudentId { get; set; }

    public int ExamId { get; set; }

    public int MarksObtained { get; set; }

    public string? Grade { get; set; }

    public string? Remarks { get; set; }

    public virtual College College { get; set; } = null!;

    public virtual Exam Exam { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
