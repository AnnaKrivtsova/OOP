using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _11lab
{
    /// <summary>
    /// Логика взаимодействия для Insert_Page.xaml
    /// </summary>
    public partial class Insert_Page : Page
    {
        ListBox listBox = new ListBox();

        public Insert_Page()
        {
            InitializeComponent();

            using (UserContext db = new UserContext())
            {
                var query = from p in db.Roles
                            select p;

                foreach (Role r in query)
                {
                    ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = r.RoleName;
                    listBox.Items.Add(listBoxItem);
                }
            }

            Style listBoxStyle = new Style();
            listBoxStyle.Setters.Add(new Setter { Property = Control.VerticalAlignmentProperty, Value = VerticalAlignment.Bottom });
            listBoxStyle.Setters.Add(new Setter { Property = Control.HorizontalAlignmentProperty, Value = HorizontalAlignment.Left });
            listBoxStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(10, 10, 0, 50) });

            listBox.Name = "Role";
            InsertStackPanel.Children.Add(listBox);
            listBox.Style = listBoxStyle;
            listBox.SelectedIndex = 0;
        }

        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            try
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                UserImage.Source = new BitmapImage(fileUri);
            }
            catch
            {
                MessageBox.Show("Add photo");
            }

        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            string email = UserEmail.Text;
            string password = UserPassword.Text;           
            string name = UserName.Text;
            string surname = UserSurname.Text;
            string description = UserDescription.Text;
            int age = Convert.ToInt32(UserAge.Text);
            string image = UserImage.Source.ToString();

            using (UserContext db = new UserContext())
            {
                var query = from p in db.Roles
                            where p.RoleId == listBox.SelectedIndex + 21
                            select p;


                User user = new User
                {
                    UserEmail = email,
                    UserPassword = password,
                    UserName = name,
                    UserSurname = surname,
                    UserDescription = description,
                    UserAge = age,
                    UserImage = image,
                    Role = query.First()
                };


                db.Users.Add(user);
                db.SaveChanges();
            }


            UserEmail.Text = "";
            UserPassword.Text = "";
            UserName.Text = "";
            UserSurname.Text = "";
            UserDescription.Text = "";
            UserAge.Text = "";
            UserImage.Source = new BitmapImage();
            listBox.SelectedIndex = 0;
        }
    }
}
