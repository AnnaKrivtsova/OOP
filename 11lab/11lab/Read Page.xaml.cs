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

namespace _11lab
{
    /// <summary>
    /// Логика взаимодействия для Read_Page.xaml
    /// </summary>
    public partial class Read_Page : Page
    {
        public static string Data { get; set; }

        public Read_Page()
        {
            InitializeComponent();

            using (UserContext db = new UserContext())
            {
                List<User> usersList = new List<User>();

                IOrderedQueryable query;

                switch (Data)
                {
                    case "ShowReadingPage":
                        query = from p in db.Users
                                orderby p.UserId ascending
                                select p;
                        break;
                    case "SortIdAscending":
                        query = from p in db.Users
                                orderby p.UserId ascending
                                select p;
                        break;
                    case "SortIdDescending":
                        query = from p in db.Users
                                orderby p.UserId descending
                                select p;
                        break;
                    case "SortSurnameAscending":
                        query = from p in db.Users
                                orderby p.UserSurname ascending
                                select p;
                        break;
                    case "SortSurnameDescending":
                        query = from p in db.Users
                                orderby p.UserId descending
                                select p;
                        break;
                    default:
                        query = from p in db.Users
                                orderby p.UserId ascending
                                select p;
                        break;
                }

                foreach (User us in query)
                    usersList.Add(us);

                UsersGrid.ItemsSource = usersList;
            }
        }
    }
}
