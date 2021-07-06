using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _2lab
{
    public partial class Initials : Form
    {
        public string Search;
        public Initials(string search)
        {
            InitializeComponent();
            Search = search;
            switch (search)
            {
                case "initials":
                    groupBox_spec.Visible = false;
                    groupBox_average.Visible = false;
                    groupBox_course.Visible = false;
                    groupBox_howSort.Visible = false;
                    break;
                case "speciallity":
                    groupBox_initials.Visible = false;
                    groupBox_average.Visible = false;
                    groupBox_course.Visible = false;
                    groupBox_spec.Visible = true;
                    groupBox_howSort.Visible = false;
                    break;
                case "course":
                    groupBox_initials.Visible = false;
                    groupBox_spec.Visible = false;
                    groupBox_average.Visible = false;
                    groupBox_howSort.Visible = false;
                    break;
                case "average":
                    groupBox_initials.Visible = false;
                    groupBox_spec.Visible = false;
                    groupBox_course.Visible = false;
                    groupBox_howSort.Visible = false;
                    break;
                case "experienceSort":
                    groupBox_spec.Visible = false;
                    groupBox_average.Visible = false;
                    groupBox_course.Visible = false;
                    groupBox_initials.Visible = false;
                    button_search.Text = "Сортировать";
                    break;
                case "groupeSort":
                    groupBox_spec.Visible = false;
                    groupBox_average.Visible = false;
                    groupBox_course.Visible = false;
                    groupBox_initials.Visible = false;
                    button_search.Text = "Сортировать";
                    break;
                case "courseSort":
                    groupBox_spec.Visible = false;
                    groupBox_average.Visible = false;
                    groupBox_course.Visible = false;
                    groupBox_initials.Visible = false;
                    button_search.Text = "Сортировать";
                    break;
             
            }         
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            richTextBox_search.Text = "";
            var students = XmlSerializeWrapper.DeserializeArrayStudent<Student>("D:/students.xml");
            dynamic selectedItems = null;
            switch (Search)
            {
                case "initials":
                    Regex rgx = new Regex($@"{Regex.Escape(textBox_name.Text)}\w*");
                    Regex rgxSurname = new Regex(@"\w*textBox_surname.Text\w*");
                    Regex rgxLastname = new Regex(@"\w*textBox_lastname.Text\w*");

                    selectedItems = from t in students
                                    where rgx.IsMatch(t.FirstName)
                                    select t;
                    break;
                case "speciallity":
                    string specType;
                    if (radioButton_POIT.Checked)
                    {
                        specType = radioButton_POIT.Text;
                    }
                    else if (radioButton_ISiT.Checked)
                    {
                        specType = radioButton_ISiT.Text;
                    }
                    else if (radioButton_POiBMS.Checked)
                    {
                        specType = radioButton_POiBMS.Text;
                    }
                    else
                    {
                        specType = radioButton_DEiVI.Text;
                    }
                    selectedItems = from t in students
                                        where t.SpecType == specType
                                        select t;
                    break;
                case "course":
                    selectedItems = from t in students
                                    where t.Course == Convert.ToInt32(comboBox_course.Text)
                                    select t;
                    break;
                case "average":
                    selectedItems = from t in students
                                    where t.Average == trackBar_aver.Value
                                    select t;
                    break;         
                case "experienceSort":
                    this.Text = "Сортировка по стажу";
                    if(radioButton_asc.Checked)
                        selectedItems = from t in students
                                    orderby t.workplace.Experience
                                    select t;
                    else
                        selectedItems = from t in students
                                        orderby t.workplace.Experience descending
                                        select t;
                    break;
                case "groupeSort":

                    if (radioButton_asc.Checked)
                        selectedItems = from t in students
                                    orderby t.Group
                                    select t;
                    else
                        selectedItems = from t in students
                                        orderby t.Group descending
                                        select t;
                    break;
                case "courseSort":
                    if (radioButton_asc.Checked)
                        selectedItems = from t in students
                                    orderby t.Course
                                    select t;
                    else
                        selectedItems = from t in students
                                        orderby t.Course descending
                                        select t;
                    break;
            }
            foreach (Student item in selectedItems)
            {
                richTextBox_search.Text += "Имя:";
                richTextBox_search.Text += item.FirstName;
                richTextBox_search.Text += " Фамиия:";
                richTextBox_search.Text += item.Surname;
                richTextBox_search.Text += " Отчество:";
                richTextBox_search.Text += item.LastName;
                richTextBox_search.Text += " Группа:";
                richTextBox_search.Text += item.Group;
                richTextBox_search.Text += " Специальность:";
                richTextBox_search.Text += item.SpecType;
                richTextBox_search.Text += " Средний балл:";
                richTextBox_search.Text += item.Average;
                richTextBox_search.Text += " Курс:";
                richTextBox_search.Text += item.Course;
                richTextBox_search.Text += " Стаж:";
                richTextBox_search.Text += item.workplace.Experience;
                richTextBox_search.Text += "\n\n";
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            XmlSerializeWrapper.Serialize(richTextBox_search.Text, "D:/results.xml");
            MessageBox.Show("Результаты созранены");
        }

        private void trackBar_aver_Scroll(object sender, EventArgs e)
        {
            label_aver.Text = String.Format("Средний балл {0}", trackBar_aver.Value);
        }
    }
}
