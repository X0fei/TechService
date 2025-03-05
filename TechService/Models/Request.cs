using System;
using System.Collections.Generic;

namespace TechService.Models;

public partial class Request
{
    public int Id { get; set; }

    public int EquipmentId { get; set; }

    public int MalfunctionId { get; set; }

    public string? ProblemDescription { get; set; }

    public int? PriorityId { get; set; }

    public DateOnly Date { get; set; }

    public int ClientId { get; set; }

    public int StatusId { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual Malfunction Malfunction { get; set; } = null!;

    public virtual Priority? Priority { get; set; }

    public virtual Status Status { get; set; } = null!;
}
