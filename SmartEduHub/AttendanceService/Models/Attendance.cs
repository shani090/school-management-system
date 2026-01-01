using System;
using System.Collections.Generic;

namespace AttendanceService.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int CollegeId { get; set; }

    public int StudentId { get; set; }

    public DateOnly Date { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

    public virtual College College { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
