using System;
using System.Collections.Generic;
using System.Data;
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
using System.Configuration;

namespace _10lab
{
    /// <summary>
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Page
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(UserId.Text);

                string sqlExpression = String.Format($"DELETE FROM USERS WHERE UserId={id}");

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString; ;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction sqlTran = connection.BeginTransaction();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Transaction = sqlTran;
                    int number = command.ExecuteNonQuery();
                    MessageBoxResult Result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (Result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Delete successfully");
                        sqlTran.Commit();
                    }
                    else if (Result == MessageBoxResult.No)
                    {
                        sqlTran.Rollback();
                        return;
                    }
                    Console.WriteLine("Добавлено объектов: {0}", number);
                }
                UserId.Text = "";

                Result.Text = "User was deleted";

                using (var conn = new SqlConnection(connectionString))
                using (var command = new SqlCommand("getUsers", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    List<User> usersList = new List<User>();

                    while (reader.Read()) // построчно считываем данные
                    {
                        object userId = reader["UserId"];
                        object email = reader["UserEmail"];
                        object password = reader["UserPassword"];
                        object roleId = reader["RoleId"];
                        object name = reader["UserName"];
                        object surname = reader["UserSurname"];
                        object description = reader["UserDescription"];
                        object age = reader["UserAge"];
                        object image = reader["UserImage"];
                        User user = new User(userId.ToString(), email.ToString(), password.ToString(), Convert.ToInt32(roleId), name.ToString(), surname.ToString(), description.ToString(), Convert.ToInt32(age), new BitmapImage(new Uri(image.ToString())));
                        usersList.Add(user);
                    }
                    DataGrid dataGrid = new DataGrid();
                    dataGrid.ItemsSource = usersList;
                    DeleteStackPanel.Children.Add(dataGrid);

                    reader.Close();
                }
            }
            catch
            {
                Result.Text = "Enter id of the user";
            }
        }
    }
}
