using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _6_7lab.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Add_tutors.xaml
    /// </summary>
    public partial class Add_tutors : System.Windows.Controls.UserControl
    {
        public Add_tutors()
        {
            InitializeComponent();
            Update_tutor_button.Visibility = Visibility.Hidden;
        }

        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            try
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgDynamic.Source = new BitmapImage(fileUri);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Add photo");
            }

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!((Char.IsLetter(ch) || ch.Equals('-'))))
                {
                    e.Handled = true;

                    break;
                }
            }
        }

        private void TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string Symbol = e.Key.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.Key != Key.Enter && e.Key != Key.OemMinus || e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Description_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var ch in e.Text)
            {
                if (!((Char.IsLetter(ch) || ch.Equals('-') || ch.Equals(',') || ch.Equals('.'))))
                {
                    e.Handled = true;

                    break;
                }
            }
        }

        private void Description_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string Symbol = e.Key.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]|[a-zA-Z]").Success && e.Key != Key.Enter)
            {
                e.Handled = true;
            }
        }

        private static readonly Regex _regex = new Regex("[^0-9,-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text))
            {
                e.Handled = true; // отклоняем ввод
            }
        }

        private void Numbers_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }

        private void BtnAddTutor_Click(object sender, RoutedEventArgs e)
        {
           
            int age = Convert.ToInt32(Age.Text);
            
            TextBlock selectedItem = (TextBlock)LenguagesList.SelectedItem;
            string lenguage = selectedItem.Text;

            var raiting = Convert.ToInt32(Raiting.Text);
            var price = Convert.ToDouble(Price.Text);

            var path = imgDynamic.Source.ToString();

            TutorPerson[] tutorsAray = XmlSerializeWrapper.DeserializeArrayTutors("D:/tutors.xml");

            var tutor = new TutorPerson(tutorsAray.Length + 1, Name.Text, Surname.Text, Lastname.Text,
                age, lenguage, Description.Text, path, raiting, price);


            XmlSerializeWrapper.Serialize<TutorPerson>(tutor, "D:/tutor.xml");
            XmlSerializeWrapper.SerializeTutor<TutorPerson>(tutor, "D:/tutors.xml");

            Name.Text = "";
            Surname.Text = "";
            Lastname.Text = "";
            Price.Text = "";
            Description.Text = "";
            Raiting.Text = "";
            Description.Text = "";
            LenguagesList.SelectedIndex = -1;
            Age.Text = "";
            imgDynamic.Source = new BitmapImage();
        }
    }
}
