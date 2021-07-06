using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13.Models
{
    public class UnitOfWork : IDisposable
    {
        private TutorContext db = new TutorContext();
        private Repository<Tutor> tutorRepository;

        public Repository<Tutor> Tutors
        {
            get
            {
                if (tutorRepository == null)
                    tutorRepository = new Repository<Tutor>(db);
                return tutorRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
