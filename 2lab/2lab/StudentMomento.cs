using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public class StudentMomento
    {
        public string Country { get; private set; }
        public string University { get; private set; }
        public StudentMomento(string _country, string _university)
        {
            this.Country = _country;
            this.University = _university;
        }
    }

    class StudentHistory
    {
        public Stack<StudentMomento> History { get; private set; }
        public StudentHistory()
        {
            History = new Stack<StudentMomento>();
        }
    }
}
