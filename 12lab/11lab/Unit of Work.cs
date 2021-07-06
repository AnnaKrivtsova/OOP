using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace _11lab
{
    public class UnitOfWork : IDisposable
    {
        private UserContext db = new UserContext();
        private Repository<User> userRepository;
        private Repository<Role> roleRepository;

        public Repository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<User>(db);
                return userRepository;
            }
        }

        public Repository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new Repository<Role>(db);
                return roleRepository;
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
