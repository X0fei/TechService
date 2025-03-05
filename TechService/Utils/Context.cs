using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechService.Context;
using TechService.Models;

namespace TechService.Utils
{
    public static class Context
    {
        public static User21Context DbContext { get; set; } = new();
        public static List<User> Users = new List<User>(DbContext.Users.ToList());
        public static List<Request> Requests = new List<Request>(DbContext.Requests
            .Include(r => r.Equipment)
            .Include(r => r.Malfunction)
            .Include(r => r.Priority)
            .Include(r => r.Client)
            .Include(r => r.Status)
            .ToList());
        public static List<Equipment> Equipment = new List<Equipment>(DbContext.Equipment
            .Include(e => e.EquipmentType)
            .ToList());
        public static List<Malfunction> Malfunctions = new List<Malfunction>(DbContext.Malfunctions.ToList());
        public static int clientId { get; set; }
    }
}
