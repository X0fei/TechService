using System;
using System.Collections.Generic;

namespace TechService.Models;

public partial class Report
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public int Time { get; set; }

    public decimal Cost { get; set; }

    public virtual Request Request { get; set; } = null!;
}
