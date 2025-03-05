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
    }
}
