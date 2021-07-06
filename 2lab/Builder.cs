using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public interface IStudentBuilder
    {
        IStudentBuilder BuildName(string name, string surname, string lastname);
        IStudentBuilder BuildAge(int age);
        IStudentBuilder BuildUniversity(int course, int group, string speciallity);
        string GetResult();
    }
    class StudentBuilder : IStudentBuilder
    {
        private string _page = string.Empty;
        public IStudentBuilder BuildName(string name, string surname, string lastname)
        {
            _page += "Имя: " + name + "\nФамилия: " + surname + "\nОтчество: " + lastname;
            return this;
        }
        public IStudentBuilder BuildAge(int age)
        {
            _page += "\nВозраст: " + age;
            return this;
        }
        public IStudentBuilder BuildUniversity(int course, int group, string speciallity)
        {
            _page += "\nКурс: " + course + "\nГруппа: " + group + "\nСпециальность: " + speciallity;
            return this;
        }
        public string GetResult()
        {
            return _page;
        }
    }
}
