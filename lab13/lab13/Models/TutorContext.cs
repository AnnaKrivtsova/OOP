using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13.Models
{
    class TutorContext : DbContext
    {
        public TutorContext() : base("DbConnection") { }

        public DbSet<Tutor> Tutors { get; set; }
    }
}
