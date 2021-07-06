using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _11lab
{
    public class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserDescription { get; set; }
        public int UserAge { get; set; }
        public string UserImage { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}