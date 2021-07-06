using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11lab
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DbConnection")
        { }

        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
    }
}
