using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Assignment> Assignment { get; set; } = new List<Assignment>();
}
