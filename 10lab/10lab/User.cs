using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace _10lab
{
    class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public BitmapImage Image { get; set; }

        public User(string id,string email, string password, int roleId, string name,
            string surname, string description, int age, BitmapImage image)
        {
            Id = id;
            Email = email;
            Password = password;
            RoleId = roleId;
            Name = name;
            Surname = surname;
            Description = description;
            Age = age;
            Image = image;
        }
    }
}
