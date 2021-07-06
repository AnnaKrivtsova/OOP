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
    /// Логика взаимодействия для Show_Page.xaml
    /// </summary>
    public partial class Reading_Page : Page
    {
        public static string Data { get; set; }

        public Reading_Page()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString; ;
            string sqlExpressionSelect = "";
            switch (Data) {
                case "ShowReadingPage":
                    sqlExpressionSelect = "SELECT * FROM USERS";
                    break;
                case "SortIdAscending":
                    sqlExpressionSelect = "SELECT * FROM USERS ORDER BY UserId ASC";
                    break;
                case "SortIdDescending":
                    sqlExpressionSelect = "SELECT * FROM USERS ORDER BY UserId DESC";
                    break;
                case "SortSurnameAscending":
                    sqlExpressionSelect = "SELECT * FROM USERS ORDER BY UserSurname ASC";
                    break;
                case "SortSurnameDescending":
                    sqlExpressionSelect = "SELECT * FROM USERS ORDER BY UserSurname DESC";
                    break;
                default:
                    sqlExpressionSelect = "SELECT * FROM USERS";
                    break;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpressionSelect, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<User> usersList = new List<User>();

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader["UserId"];
                    object email = reader["UserEmail"];
                    object password = reader["UserPassword"];
                    object roleId = reader["RoleId"];
                    object name = reader["UserName"];
                    object surname = reader["UserSurname"];
                    object description = reader["UserDescription"];
                    object age = reader["UserAge"];
                    object image = reader["UserImage"];
                    User user = new User(id.ToString(),email.ToString(), password.ToString(), Convert.ToInt32(roleId), name.ToString(), surname.ToString(), description.ToString(), Convert.ToInt32(age), new BitmapImage(new Uri(image.ToString())));
                    usersList.Add(user);
                }

                UsersGrid.ItemsSource = usersList;

                reader.Close();
            }

            Console.Read();
        }
    }
}
