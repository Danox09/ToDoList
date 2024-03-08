using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class Assignment
{
    public int Id { get; set; }

    public string AssignmentName { get; set; } = null!;

    public string AssignmentDescription { get; set; } = null!;

    public DateTime AssignmentDate { get; set; }

    public int StatusId { get; set; }

    public int PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual AssignmentStatus Status { get; set; } = null!;

    public static explicit operator Assignment(Task<Assignment?> v)
    {
        throw new NotImplementedException();
    }
}