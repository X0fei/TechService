using System;
using System.Collections.Generic;

namespace TechService.Models;

public partial class RequestSpecialist
{
    public int RequestId { get; set; }

    public int SpecialistId { get; set; }

    public virtual Request Request { get; set; } = null!;

    public virtual User Specialist { get; set; } = null!;
}
