using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class AssignmentStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Assignment> Assignment { get; set; } = new List<Assignment>();
}
