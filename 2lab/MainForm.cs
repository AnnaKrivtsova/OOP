using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace _2lab
{
    public partial class form_studentF : Form
    {
        int position = -1;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        ToolStripLabel objectLabel;
        ToolStripLabel countLabel;
        ToolStripLabel actionLabel;
        ToolStripLabel addLabel;
        ToolStripLabel removeLabel;
        ToolStripLabel searchLabel;
        ToolStripLabel sortLabel;
        Timer timer;
        
        public form_studentF(StyleForm myStyle)
        {
            Program.f1 = this;
            InitializeComponent();

            infoLabel = new ToolStripLabel("Текущие дата и время:");
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            objectLabel = new ToolStripLabel("Количество объектов:");
            var arr = XmlSerializeWrapper.DeserializeArrayStudent<Student>("D:/students.xml");
            countLabel = new ToolStripLabel(arr.Length.ToString());
            actionLabel = new ToolStripLabel("Последнее действие:");
            addLabel = new ToolStripLabel(" добавление");
            removeLabel = new ToolStripLabel(" очистка");
            searchLabel = new ToolStripLabel(" поиск");
            sortLabel = new ToolStripLabel(" сортировка");

            groupBox_info.BackColor = myStyle.Style.BackgroundColor;
            groupBox_infoUniversity.ForeColor = myStyle.Style.FontColor;
            groupBox_workPlace.Width = myStyle.Style.Width;
            groupBox_info.Height = myStyle.Style.Height;
            groupBox_infoUniversity.Height = myStyle.Style.Height;
            groupBox_infoUniversity.BackColor = myStyle.Style.BackgroundColor;
            groupBox_workPlace.BackColor = myStyle.Style.BackgroundColor;
            groupBox_address.BackColor = myStyle.Style.BackgroundColor;
            groupBox_addInfo.BackColor = myStyle.Style.BackgroundColor;
            groupBox_infoMark.BackColor = myStyle.Style.BackgroundColor;


            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(objectLabel);
            statusStrip1.Items.Add(countLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBox_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar!= 8 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox_surname_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox_lastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void textBox_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void trackBar_aver_Scroll(object sender, EventArgs e)
        {
            label_aver.Text = String.Format("Средний балл {0}", trackBar_aver.Value);
        }

        private void textBox_city_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void textBox_street_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void textBox_house_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox_flat_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                var FirstName = textBox_name.Text;
                var Surname = textBox_surname.Text;
                var LastName = textBox_lastName.Text;
                var Age = Convert.ToInt32(numericUpDown_age.Value);
                var Group = Convert.ToInt32(comboBox_group.Text);
                var Course = Convert.ToInt32(comboBox_course.Text);
                var Average = trackBar_aver.Value;
                var Birthday = dateTimePicker_birthday.Value;
                string genderType;
                if (radioButton_man.Checked)
                {
                    genderType = radioButton_man.Text;
                }
                else
                {
                    genderType = radioButton_woman.Text;
                }
                string cpecType;
                if (radioButton_POIT.Checked)
                {
                    cpecType = radioButton_POIT.Text;
                }
                else if (radioButton_ISiT.Checked)
                {
                    cpecType = radioButton_ISiT.Text;
                }
                else if (radioButton_POiBMS.Checked)
                {
                    cpecType = radioButton_POiBMS.Text;
                }
                else
                {
                    cpecType = radioButton_DEiVI.Text;
                }
                var City = textBox_city.Text;
                var Street = textBox_street.Text;
                var House = Convert.ToInt32(textBox_house.Text);
                var Flat = Convert.ToInt32(textBox_flat.Text);
                var Index = Convert.ToInt32(maskedTextBox1.Text);
                var Company = comboBox_workplace.Text;
                var Position = textBox_position.Text;
                var Experience = Convert.ToInt32(numericUpDown_experience.Value);

                var student = new Student(FirstName, Surname, LastName, Age, cpecType, genderType, Group, Course, Average, Birthday,
                    City, Street, House, Flat, Index, Company, Position, Experience);
                var clonableStudent = student.Clone();
                richTextBox_output.Text = "";
                richTextBox_output.Text = clonableStudent.GetInfo();
                    var results = new List<ValidationResult>();
                var context = new ValidationContext(student);
                if (!Validator.TryValidateObject(student, context, results, true))
                {
                    foreach (var error in results)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                XmlSerializeWrapper.Serialize<Student>(student, "D:/student.xml");
                XmlSerializeWrapper.SerializeStudent<Student>(student, "D:/students.xml");
                textBox_name.Text = "";
                textBox_surname.Text = "";
                textBox_lastName.Text = "";
                numericUpDown_age.Value = 1;
                comboBox_group.SelectedIndex = -1;
                comboBox_course.SelectedIndex = -1;
                trackBar_aver.Value = trackBar_aver.Minimum;
                label_aver.Text = "Средний балл ";
                textBox_city.Text = "";
                textBox_street.Text = "";
                textBox_house.Text = "";
                textBox_flat.Text = "";
                maskedTextBox1.Text = "";
                radioButton_man.Checked = true;
                radioButton_POIT.Checked = true;
                comboBox_workplace.SelectedIndex = -1;
                textBox_position.Text = "";
                numericUpDown_experience.Value = 0;
                statusStrip1.Items.Add(actionLabel);
                statusStrip1.Items.Add(addLabel);
                int count = Convert.ToInt32(countLabel.Text);
                count++;
                countLabel.Text = count.ToString();
            }
            catch 
            {
                MessageBox.Show("Заполните все поля");
            }   
        }

        private void button_output_Click(object sender, EventArgs e)
        {
            var deserializeStudent = XmlSerializeWrapper.DeserializeStudent<Student>("D:/student.xml");
            richTextBox_output.Text = Convert.ToString(deserializeStudent);
        }

        private void textBox_company_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void textBox_position_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void button_form2_Click(object sender, EventArgs e)
        {
            AddCompany workplace = new AddCompany();
            workplace.Show();

        }

        private void form_student_Load(object sender, EventArgs e)
        {
            XElement workplaces = XElement.Load("D:/workplaces.xml");
            foreach (XElement workplace in workplaces.Elements("company"))
            {
                comboBox_workplace.Items.Add(workplace.Value);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кривцова Анна Павловна");
        }

        private void toolStripButton_fix_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = true;
        }

        private void toolStripButton_hide_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = false;
        }

        private void панельИнструментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = true;
        }

        private void toolStripButton_clear_Click(object sender, EventArgs e)
        {
            textBox_name.Text = "";
            textBox_surname.Text = "";
            textBox_lastName.Text = "";
            numericUpDown_age.Value = 1;
            comboBox_group.SelectedIndex = -1;
            comboBox_course.SelectedIndex = -1;
            trackBar_aver.Value = trackBar_aver.Minimum;
            label_aver.Text = "Средний балл ";
            textBox_city.Text = "";
            textBox_street.Text = "";
            textBox_house.Text = "";
            textBox_flat.Text = "";
            maskedTextBox1.Text = "";
            radioButton_man.Checked = true;
            radioButton_POIT.Checked = true;
            comboBox_workplace.SelectedIndex = -1;
            textBox_position.Text = "";
            numericUpDown_experience.Value = 0;
            statusStrip1.Items.Remove(addLabel);
            statusStrip1.Items.Add(removeLabel);
        }

        private void ToolStripMenuItem_initials_Click(object sender, EventArgs e)
        {
            Initials initials = new Initials("initials");
            initials.Text = "Поиск по ФИО";
            initials.Show();
        }

        private void ToolStripMenuItem_spec_Click(object sender, EventArgs e)
        {
            Initials initials = new Initials("speciallity");
            initials.Text = "Поиск по специальности";
            initials.Show();
        }

        private void ToolStripMenuItem_course_Click(object sender, EventArgs e)
        {
            Initials initials = new Initials("course");
            initials.Text = "Поиск по курсу";
            initials.Show();
        }

        private void ToolStripMenuItem_aver_Click(object sender, EventArgs e)
        {
            Initials initials = new Initials("average");
            initials.Text = "Поиск по среднему баллу";
            initials.Show();
        }

        private void ToolStripMenuItem_experienceSort_Click(object sender, EventArgs e)
        {
            Initials initials = new Initials("experienceSort");
            initials.Text = "Сортировка по стажу";
            initials.Show();
        }

        private void ToolStripMenuItem_groupeSort_Click(object sender, EventArgs e)
        {
            Initials initials = new Initials("groupeSort");
            initials.Text = "Сортировка по группе";
            initials.Show();
        }

        private void ToolStripMenuItem_courseSort_Click(object sender, EventArgs e)
        {
            Initials initials = new Initials("courseSort");
            initials.Text = "Сортировка по курсу";
            initials.Show();
        }

        private void ToolStripMenuItem_search_Click(object sender, EventArgs e)
        {
            statusStrip1.Items.Add(actionLabel);
            statusStrip1.Items.Add(searchLabel);
        }

        private void ToolStripMenuItem_sort_Click(object sender, EventArgs e)
        {
            statusStrip1.Items.Add(actionLabel);
            statusStrip1.Items.Add(sortLabel);
        }

        private void toolStripButton_back_Click(object sender, EventArgs e)
        {
            position--;
            var students = XmlSerializeWrapper.DeserializeArrayStudent<Student>("D:/students.xml");
            if (position > students.Length || position < 0)
                position = students.Length-1;
            propertyGrid1.SelectedObject = students[position];
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void toolStripButton_forward_Click(object sender, EventArgs e)
        {
            position++;
            var students = XmlSerializeWrapper.DeserializeArrayStudent<Student>("D:/students.xml");
            if (position == students.Length)
                position = 0;
            propertyGrid1.SelectedObject = students[position];
        }

        private void button_aboutStudent_Click(object sender, EventArgs e)
        {
            IFactory factory = new FactoryStudent();
            var person = factory.CreatePerson();
            var goal = factory.CreateGoal();

            richTextBox_output.Text = "";
            richTextBox_output.Text = $"Этот человек: {person.GetInfoPerson()}\nПришел сюда с этой целью: {goal.GetInfoGoal()}";
        }

        private void button_aboutTutor_Click(object sender, EventArgs e)
        {
            IFactory factory = new FactoryTutor();
            var person = factory.CreatePerson();
            var goal = factory.CreateGoal();

            richTextBox_output.Text = "";
            richTextBox_output.Text = $"Этот человек: {person.GetInfoPerson()}\nПришел сюда с этой целью: {goal.GetInfoGoal()}";
        }

        private void button_builder_Click(object sender, EventArgs e)
        {
            try
            {
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
                var pageBuilder = new StudentBuilder();
                var page = pageBuilder.BuildName(textBox_name.Text, textBox_surname.Text, textBox_lastName.Text)
                    .BuildAge((int)numericUpDown_age.Value)
                    .BuildUniversity(Convert.ToInt32(comboBox_course.Text), Convert.ToInt32(comboBox_group.Text), specType);
                richTextBox_output.Text = "";
                richTextBox_output.Text = page.GetResult();
            }
            catch
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void ToolStripMenuItem_addInfo_Click(object sender, EventArgs e)
        {
            CoursesForm formCourses = new CoursesForm();
            formCourses.Show();
        }

        private void textBox_university_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();


            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void textBox_country_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();


            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        Student student = new Student();
        StudentHistory history = new StudentHistory();
        StudentHistory history2 = new StudentHistory();
        int count = 1;

        private void button_outputAddInfo_Click(object sender, EventArgs e)
        {
            student.SetCountry(textBox_country.Text);
            student.SetUniversity(textBox_university.Text);

            if (count == 1) {
                history.History.Push(student.SaveState()); // сохраняем 
                count = 0;
            }
            else
            {
                history2.History.Push(student.SaveState()); // сохраняем 
                count++;
            }
            richTextBox_outputAddInfo.Text = student.GetAddInfo();
            textBox_country.Text = "";
            textBox_university.Text = "";
        }

        private void button_changeAddInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (count == 1 )
                {
                    richTextBox_outputAddInfo.Text = student.RestoreState(history.History.Pop());
                }
                else
                {
                    richTextBox_outputAddInfo.Text = student.RestoreState(history2.History.Pop());
                }
            }
            catch
            {
                MessageBox.Show("Вводите новую информацию");
            }
        }

        private void button_generateMark_Click(object sender, EventArgs e)
        {
            Mark mark = new Mark();
            Tutor tutor = new Tutor(textBox_tutor.Text, mark);

            richTextBox_markInfo.Text = mark.GenerateMark();
        }

        private void button_outputstudy_Click(object sender, EventArgs e)
        {
            Tutor tutor = new Tutor();
            if (radioButton_semester.Checked)
            {
                University university = new University();
                richTextBox_markInfo.Text = tutor.Study(university);
            }
            else
            {
                Distance distance = new Distance();
                ITeach distanceStuding = new DistanceToTeachingAdapter(distance);
                richTextBox_markInfo.Text = tutor.Study(distanceStuding);
            }
        }
    }
}
