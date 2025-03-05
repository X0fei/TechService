using System;
using System.Collections.Generic;

namespace TechService.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public int EquipmentTypeId { get; set; }

    public virtual EquipmentType EquipmentType { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
