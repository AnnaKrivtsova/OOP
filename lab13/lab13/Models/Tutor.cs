using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Subject{ get; set; }
        public string Date{ get; set; }
        public string Time{ get; set; }
        public int IsSelected { get; set; }

        public Tutor(string name, string surname, string subject, string date, string time, int isSelected)
        {
            this.Surname = surname;
            this.Subject = subject;
            this.Date = date;
            this.Time = time;
            this.Name = name;
            this.IsSelected = isSelected;
        }
        public Tutor() { }
    }
}
