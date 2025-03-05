using System;
using System.Collections.Generic;

namespace TechService.Models;

public partial class ReportMaterial
{
    public int ReportId { get; set; }

    public int MaterialId { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Report Report { get; set; } = null!;
}
