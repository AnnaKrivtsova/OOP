using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2lab
{
    public partial class CoursesForm : Form
    {
        public CoursesForm()
        {
            InitializeComponent();
        }

        private void button_outputAboutCourse_Click(object sender, EventArgs e)
        {
            Courses course;
            if (radioButton_placeUniversity.Checked)
            {
                course = new UniversityCourses();
            }
            else 
            {
                course = new CompanyCourses();
            }

            if (checkBox_Java.Checked)
            {
                course = new Java(course);
            }
            if (checkBox_Plus.Checked)
            {
                course = new Plus(course);
            }
            if (checkBox_Sharp.Checked)
            {
                course = new Sharp(course);
            }

            if(!checkBox_Java.Checked && !checkBox_Plus.Checked && !checkBox_Sharp.Checked)
            {
                richTextBox_outputAboutCourse.Text = $"Название: {course.Name}\nВыберите предмет, чтобы узнать цену";
            }
            else
            {
                richTextBox_outputAboutCourse.Text = $"Название: {course.Name}\nЦена: {course.GetCost()}";
            }
        }
    }
}
