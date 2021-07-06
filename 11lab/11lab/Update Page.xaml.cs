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
    /// Логика взаимодействия для Update_Page.xaml
    /// </summary>
    public partial class Update_Page : Page
    {
        ListBox listBox = new ListBox();
        int userId;

        public Update_Page()
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
            UpdateStackPanel.Children.Add(listBox);
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

        private void BtnLoadUser_Click(object sender, RoutedEventArgs e)
        {
            userId = Convert.ToInt32(UserId.Text);

            using (UserContext db = new UserContext())
            {
                var query = from p in db.Users
                            where p.UserId == userId
                            select p;

                foreach (User us in query)
                {
                    UserEmail.Text = us.UserEmail;
                    UserPassword.Text = us.UserPassword;
                    listBox.SelectedIndex = Convert.ToInt32(us.RoleId - 21);
                    UserName.Text = us.UserName;
                    UserSurname.Text = us.UserSurname;
                    UserDescription.Text = us.UserDescription;
                    UserAge.Text = us.UserAge.ToString();
                    UserImage.Source = new BitmapImage(new Uri(us.UserImage.ToString()));
                }
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string email = UserEmail.Text;
            string password = UserPassword.Text;
            ListBoxItem selectedItem = (ListBoxItem)listBox.SelectedItem;
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
                var user = from p in db.Users
                           where p.UserId == userId
                           select p;

                User us = user.First();

                us.UserEmail = email;
                us.UserPassword = password;
                us.UserName = name;
                us.UserSurname = surname;
                us.UserDescription = description;
                us.UserAge = age;
                us.UserImage = image;
                us.Role = query.First();

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
            UserId.Text = "";
        }
    }
}
