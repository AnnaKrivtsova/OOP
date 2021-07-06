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
            UnitOfWork unitOfWork = new UnitOfWork();
            var role = unitOfWork.Roles.Get();

            foreach (Role r in role)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = r.RoleName;
                listBox.Items.Add(listBoxItem);
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
            try
            {
                userId = Convert.ToInt32(UserId.Text);

                UnitOfWork unitOfWork = new UnitOfWork();
                User us = unitOfWork.Users.FindById(userId);

                UserEmail.Text = us.UserEmail;
                UserPassword.Text = us.UserPassword;
                listBox.SelectedIndex = Convert.ToInt32(us.RoleId - 21);
                UserName.Text = us.UserName;
                UserSurname.Text = us.UserSurname;
                UserDescription.Text = us.UserDescription;
                UserAge.Text = us.UserAge.ToString();
                UserImage.Source = new BitmapImage(new Uri(us.UserImage.ToString()));
            }
            catch { 
                MessageBox.Show("Enter id to search user"); 
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = UserEmail.Text;
                string password = UserPassword.Text;
                ListBoxItem selectedItem = (ListBoxItem)listBox.SelectedItem;
                string name = UserName.Text;
                string surname = UserSurname.Text;
                string description = UserDescription.Text;
                int age = Convert.ToInt32(UserAge.Text);
                string image = UserImage.Source.ToString();

                UnitOfWork unitOfWork = new UnitOfWork();
                User us = unitOfWork.Users.FindById(userId);
                us.UserEmail = email;
                us.UserPassword = password;
                us.UserName = name;
                us.UserSurname = surname;
                us.UserDescription = description;
                us.UserAge = age;
                us.UserImage = image;
                us.RoleId = listBox.SelectedIndex + 21;

                unitOfWork.Users.Update(us);

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
            catch
            {
                MessageBox.Show("Enter all values");
            }
        }
    }
}
