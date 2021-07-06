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
    /// Логика взаимодействия для Search_Page.xaml
    /// </summary>
    public partial class Search_Page : Page
    {
        DataGrid dataGrid = new DataGrid();

        public Search_Page()
        {
            InitializeComponent();

            SearchStackPanel.Children.Add(dataGrid);
        }

        private void BtnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<User> usersList = new List<User>();


                int id = String.IsNullOrEmpty(UserId.Text) ? -1 : Convert.ToInt32(UserId.Text);

                string surname = UserSurname.Text;
                UnitOfWork unitOfWork = new UnitOfWork();

                User user = new User();

                if (UserSurname.Text != "" && UserId.Text != "") {
                    user = unitOfWork.Users.FindById(id);
                    var userable = unitOfWork.Users.Get(x => x.UserSurname == surname);
                    foreach (User us in userable)
                    {
                        if(user.UserSurname == us.UserSurname)
                            usersList.Add(us);
                    }
                }
                else if (UserId.Text != "")
                {
                    user = unitOfWork.Users.FindById(id);
                    usersList.Add(user);
                }
                else if (UserSurname.Text != "")
                {
                    var userable = unitOfWork.Users.Get(x => x.UserSurname == surname);
                    foreach (User us in userable)
                        usersList.Add(us);
                }
                else
                    MessageBox.Show("Error");

                dataGrid.ItemsSource = usersList;
            }
            catch
            {
            }
        }
    }
}
