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

            List<User> usersList = new List<User>();
            UnitOfWork unitOfWork = new UnitOfWork();

            User user = new User();
            IEnumerable<User> userable = null;
            switch (Data)
            {
                case "ShowReadingPage":
                    userable = unitOfWork.Users.Get().OrderBy(x => x.UserId);
                    break;
                case "SortIdAscending":
                    userable = unitOfWork.Users.Get().OrderBy(x => x.UserId);
                    break;
                case "SortIdDescending":
                    userable = unitOfWork.Users.Get().OrderByDescending(x => x.UserId);
                    break;
                case "SortSurnameAscending":
                    userable = unitOfWork.Users.Get().OrderBy(x => x.UserSurname);
                    break;
                case "SortSurnameDescending":
                    userable = unitOfWork.Users.Get().OrderByDescending(x => x.UserSurname);
                    break;
                default:
                    userable = unitOfWork.Users.Get().OrderBy(x => x.UserId);
                    break;
            }

            foreach (User us in userable)
                usersList.Add(us);

            UsersGrid.ItemsSource = usersList;

        }
    }
}
