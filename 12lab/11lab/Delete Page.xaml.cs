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
    /// Логика взаимодействия для Delete_Page.xaml
    /// </summary>
    public partial class Delete_Page : Page
    {
        public Delete_Page()
        {
            InitializeComponent();
        }

        void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<User> usersList = new List<User>();

                int id = Convert.ToInt32(UserId.Text);
                UnitOfWork unitOfWork = new UnitOfWork();
                User us = unitOfWork.Users.FindById(id);


                unitOfWork.Users.Remove(us);

                var users = unitOfWork.Users.Get();
                foreach (User user in users)
                    usersList.Add(user);

                UserId.Text = "";

                Result.Text = "User was deleted";

                DataGrid dataGrid = new DataGrid();
                dataGrid.ItemsSource = usersList;
                DeleteStackPanel.Children.Add(dataGrid);
            }
            catch
            {
                Result.Text = "Enter id of the user";
            }
        }
    }
}
