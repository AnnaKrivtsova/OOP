﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11lab
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}