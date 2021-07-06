using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _2lab
{
    public partial class AddCompany : Form
    {
        public AddCompany()
        {
            InitializeComponent();
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

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            var Company = textBox_company.Text;
            var workplace = new WorkPlace(Company);
            XmlSerializeWrapper.SerializeWorkplace<WorkPlace>(workplace, "D:/workplaces.xml");
            //XElement workplaces = XElement.Load("D:/workplaces.xml");
            //foreach (XElement workplaceX in workplaces.Elements("company"))
            //{
            //    Program.f1.comboBox_workplace.Items.Add(workplaceX.Value);
            //}
            
            Close();
            MessageBox.Show("Компания добавится в список после перезагрузки формы");
        }
    }
}
