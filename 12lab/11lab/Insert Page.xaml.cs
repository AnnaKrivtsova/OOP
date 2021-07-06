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
            try
            {
                string email = UserEmail.Text;
                string password = UserPassword.Text;
                string name = UserName.Text;
                string surname = UserSurname.Text;
                string description = UserDescription.Text;
                int age = Convert.ToInt32(UserAge.Text);
                string image = UserImage.Source.ToString();

                UnitOfWork unitOfWork = new UnitOfWork();

                User user = new User
                {
                    UserEmail = email,
                    UserPassword = password,
                    UserName = name,
                    UserSurname = surname,
                    UserDescription = description,
                    UserAge = age,
                    UserImage = image,
                    RoleId = listBox.SelectedIndex + 21
                };

                unitOfWork.Users.Create(user);

                UserEmail.Text = "";
                UserPassword.Text = "";
                UserName.Text = "";
                UserSurname.Text = "";
                UserDescription.Text = "";
                UserAge.Text = "";
                UserImage.Source = new BitmapImage();
                listBox.SelectedIndex = 0;
            }
            catch {
                MessageBox.Show("Enter all values");
            }
        }
    }
}
