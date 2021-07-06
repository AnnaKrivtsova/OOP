using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Xml.Linq;

namespace _6_7lab.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Open_List_Category_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.Button_Open_List_Category_Click(sender,e);
        }

        public void OpenProfile(Object sender, EventArgs e)
        {
            GridCategory.Children.Clear();

            Style itemTextStyle = new Style();
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 20.0 });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = FontWeights.Bold });

            Style itemLanguageStyle = new Style();
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 18.0 });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 30, 0, 0) });

            Style itemAddTextStyle = new Style();
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 14.0 });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 60, 0, 20) });

            Style descriptionStyle = new Style();
            descriptionStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            descriptionStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            descriptionStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 120, 0, 20) });

            Style imageStyle = new Style();
            imageStyle.Setters.Add(new Setter { Property = Control.WidthProperty, Value = 200.0 });
            imageStyle.Setters.Add(new Setter { Property = Control.HeightProperty, Value = 200.0 });
            imageStyle.Setters.Add(new Setter { Property = Control.VerticalAlignmentProperty, Value = VerticalAlignment.Top });
            imageStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 20, 0, 20) });

            Style buttonStyle = new Style();
            buttonStyle.Setters.Add(new Setter { Property = Control.WidthProperty, Value = 80.0 });
            buttonStyle.Setters.Add(new Setter { Property = Control.HeightProperty, Value = 40.0 });
            buttonStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            buttonStyle.Setters.Add(new Setter { Property = Control.VerticalAlignmentProperty, Value = VerticalAlignment.Top });
            buttonStyle.Setters.Add(new Setter { Property = Control.HorizontalAlignmentProperty, Value = HorizontalAlignment.Right });
            buttonStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(30, 20, 0, 20) });

            Style gridStyle = new Style();
            gridStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 20, 0, 20) });

            StackPanel stackPanel = sender as StackPanel;
            TutorPerson tutor = (TutorPerson)stackPanel.Tag;

            StackPanel stackPanelNew = new StackPanel();
            stackPanelNew.Orientation = Orientation.Horizontal;
            Grid gridForPhoto = new Grid();
            Grid grid = new Grid();
            Grid gridDelete = new Grid();
            Grid gridUpdate = new Grid();
            grid.Style = gridStyle;

            TextBlock fullName = new TextBlock();
            fullName.Text = $"{tutor.Surname} {tutor.Name} {tutor.Lastname}";
            fullName.Style = itemTextStyle;

            TextBlock language = new TextBlock();
            var leng = Application.Current.Resources[key: "Lenguage"];
            language.Text += $"{leng}: {tutor.Lenguage}";
            language.Style = itemLanguageStyle;

            TextBlock raitingAndPrice = new TextBlock();
            var price = Application.Current.Resources[key: "Price"];
            var raiting = Application.Current.Resources[key: "Raiting"];
            var age = Application.Current.Resources[key: "Age"];
            raitingAndPrice.Text += $"{raiting}: {tutor.Rating} \n{price}: {tutor.Price} \n{age}: {tutor.Age}";
            raitingAndPrice.Style = itemAddTextStyle;

            TextBlock descritption = new TextBlock();
            var descr = Application.Current.Resources[key: "Description"];
            descritption.Text += $"{descr}: {tutor.Description}";
            descritption.Style = descriptionStyle;

            Image photo = new Image();
            photo.Source = new BitmapImage(new Uri(tutor.Photo));
            photo.Style = imageStyle;

            var bc = new BrushConverter();
            MainWindow m = new MainWindow();

            Button update = new Button();
            update.Style = buttonStyle;
            update.Background = (Brush)bc.ConvertFrom("#edfff2");
            update.BorderBrush = (Brush)bc.ConvertFrom("#80BA91");
            update.Content = "Update";
            update.Tag = tutor;
            update.Click += m.LoadUpdateTutorPage;

            Button delete = new Button();
            delete.Style = buttonStyle;
            delete.Background = (Brush)bc.ConvertFrom("#ff8585");
            delete.BorderBrush = (Brush)bc.ConvertFrom("#b03131");
            delete.Content = "Delete";
            delete.Tag = tutor;
            delete.Click += m.DeleteTutor;

            stackPanelNew.Children.Add(gridForPhoto);
            stackPanelNew.Children.Add(grid);
            stackPanelNew.Children.Add(gridUpdate);
            stackPanelNew.Children.Add(gridDelete);

            gridForPhoto.Children.Add(photo);

            grid.Children.Add(fullName);
            grid.Children.Add(raitingAndPrice);
            grid.Children.Add(language);
            grid.Children.Add(descritption);

            gridUpdate.Children.Add(update);
            gridDelete.Children.Add(delete);

            GridCategory.Children.Add(stackPanelNew);
        }
    }
}
