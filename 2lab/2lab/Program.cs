using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _2lab
{
    static class Program
    {
        public static form_studentF f1;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StyleForm myStyle = new StyleForm();
            myStyle.Launch(System.Drawing.Color.LavenderBlush, System.Drawing.Color.Brown, 240, 300);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form_studentF(myStyle));
        }
    }
}
