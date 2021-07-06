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

                using (UserContext db = new UserContext())
                {
                    IQueryable query = null;
                    if (UserSurname.Text != "")
                        query = from p in db.Users
                                where p.UserSurname == surname
                                select p;
                    if (UserSurname.Text != "" && UserId.Text != "")
                        query = from p in db.Users
                                where p.UserSurname == surname && p.UserId == id
                                select p;
                    else if (UserId.Text != "")
                        query = from p in db.Users
                                where p.UserId == id
                                select p;
                    else if (UserSurname.Text != "")
                        query = from p in db.Users
                                where p.UserSurname == surname
                                select p;
                    else
                        MessageBox.Show("Error");


                    if (query != null)
                        foreach (User us in query)
                            usersList.Add(us);
                }

                dataGrid.ItemsSource = usersList;
            }
            catch
            {
            }
        }
    }
}
