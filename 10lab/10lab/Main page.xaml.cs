using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

namespace _10lab
{
    /// <summary>
    /// Логика взаимодействия для Main_page.xaml
    /// </summary>

    public sealed partial class Main_page : Page
    {
        ListBox listBox = new ListBox();

        public Main_page()
        {
            this.InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString; ;
            string sqlExpression = "SELECT * FROM USER_ROLE";

            Style listBoxStyle = new Style();
            listBoxStyle.Setters.Add(new Setter { Property = Control.VerticalAlignmentProperty, Value = VerticalAlignment.Bottom });
            listBoxStyle.Setters.Add(new Setter { Property = Control.HorizontalAlignmentProperty, Value = HorizontalAlignment.Left });
            listBoxStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(10, 10, 0, 50) });

            listBox.Name = "Role";
            InsertStackPanel.Children.Add(listBox);
            listBox.Style = listBoxStyle;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        ListBoxItem listBoxItem = new ListBoxItem();
                        listBoxItem.Content = name;
                        listBox.Items.Add(listBoxItem);
                    }
                }
            }
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
            ListBoxItem selectedItem = (ListBoxItem)listBox.SelectedItem;
            int role = listBox.SelectedIndex + 1;
            string name = UserName.Text;
            string surname = UserSurname.Text;
            string description = UserDescription.Text;
            int age = Convert.ToInt32(UserAge.Text);
            string image = UserImage.Source.ToString();

            string sqlExpression = "INSERT INTO USERS (UserEmail, UserPassword, RoleId, UserName, UserSurname, UserDescription, UserAge, UserImage) " +
                "VALUES (@email, @password, @role, @name, @surname, @description, @age, @image)";
            
            
            string connectionString = @"Data Source=DESKTOP-OD6F0DG;Initial Catalog=TUTOR;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.Parameters.Add(new SqlParameter("@email", email));
                command.Parameters.Add(new SqlParameter("@password", password));
                command.Parameters.Add(new SqlParameter("@role", role));
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@surname", surname));
                command.Parameters.Add(new SqlParameter("@description", description));
                command.Parameters.Add(new SqlParameter("@age", age));
                command.Parameters.Add(new SqlParameter("@image", image));
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
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
