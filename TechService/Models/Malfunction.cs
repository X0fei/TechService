using System;
using System.Collections.Generic;

namespace TechService.Models;

public partial class Malfunction
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
