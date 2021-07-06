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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            frame.Source = new Uri("Insert Page.xaml", UriKind.Relative);
        }

        private void ShowInsertPage(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("Insert Page.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void ShowReadingPage(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("Read Page.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void ShowDeletePage(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("Delete Page.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void ShowUpdatePage(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("Update Page.xaml",
             UriKind.RelativeOrAbsolute));
        }

        private void SortIdAscending(object sender, RoutedEventArgs e)
        {
            string Param = "SortIdAscending";
            Read_Page.Data = Param;
            frame.Navigate(new Uri("Read Page.xaml",
             UriKind.RelativeOrAbsolute), Param);
        }

        private void SortIdDescending(object sender, RoutedEventArgs e)
        {
            string Param = "SortIdDescending";
            Read_Page.Data = Param;
            frame.Navigate(new Uri("Read Page.xaml",
             UriKind.RelativeOrAbsolute), Param);
        }

        private void SortSurnameAscending(object sender, RoutedEventArgs e)
        {
            string Param = "SortSurnameAscending";
            Read_Page.Data = Param;
            frame.Navigate(new Uri("Read Page.xaml",
             UriKind.RelativeOrAbsolute), Param);
        }

        private void SortSurnameDescending(object sender, RoutedEventArgs e)
        {
            string Param = "SortSurnameDescending";
            Read_Page.Data = Param;
            frame.Navigate(new Uri("Read Page.xaml",
             UriKind.RelativeOrAbsolute), Param);
        }

        private void ShowSearchPage(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Uri("Search Page.xaml",
             UriKind.RelativeOrAbsolute));
        }

    }
}
