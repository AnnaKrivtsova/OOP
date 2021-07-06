using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Xml.Linq;

namespace _6_7lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            InitializeComponent();
            Uri iconUri = new Uri("D:/4 sem/ООП/6-7lab/Cursors/tutor.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

            StreamResourceInfo sri = Application.GetResourceStream(new Uri("Luxus alternate.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = new CultureInfo("en-US");

            history.History.Push(SaveState(Main_page_control));

            //Заполняем меню смены языка:
            menuItemLanguage.Items.Clear();

            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuItemLanguage.Items.Add(menuLang);
            }
            MenuItem help = new MenuItem();
            menuLanguage.Items.Add(help);
            help.Header = Application.Current.Resources[key: "Help"];
            help.Command = ApplicationCommands.Help;

            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = ApplicationCommands.Help;
            commandBinding.Executed += CommandBinding_Executed;
            help.CommandBindings.Add(commandBinding);

            MenuItem undo = new MenuItem();
            menuLanguage.Items.Add(undo);
            undo.Header = Application.Current.Resources[key: "Undo"];
            Image photoUndo = new Image();
            photoUndo.Source = new BitmapImage(new Uri("file:///D:/4 sem/ООП/6-7lab/Photos/undo.png"));
            photoUndo.Width = 10;
            photoUndo.Height = 10;
            undo.Icon = photoUndo;
            undo.Command = ApplicationCommands.Undo;

            CommandBinding commandBindingUndo = new CommandBinding();
            commandBindingUndo.Command = ApplicationCommands.Undo;
            commandBindingUndo.Executed += button_Undo;
            undo.CommandBindings.Add(commandBindingUndo);

            MenuItem redo = new MenuItem();
            menuLanguage.Items.Add(redo);
            redo.Header = Application.Current.Resources[key: "Redo"];
            Image photoRedo = new Image();
            photoRedo.Source = new BitmapImage(new Uri("file:///D:/4 sem/ООП/6-7lab/Photos/redo.png"));
            photoRedo.Width = 10;
            photoRedo.Height = 10;
            redo.Icon = photoRedo;
            redo.Command = ApplicationCommands.Redo;

            CommandBinding commandBindingRedo = new CommandBinding();
            commandBindingRedo.Command = ApplicationCommands.Redo;
            commandBindingRedo.Executed += button_Redo;
            redo.CommandBindings.Add(commandBindingRedo);           
        }

        TextBlock textBloc = new TextBlock();


        private void tunnel_Click(object sender, MouseButtonEventArgs e)
        {
            textBloc.Text += "sender: " + sender.ToString() + "\n" + "source: " + e.Source.ToString() + "\n\n";
            MessageBox.Show(textBloc.Text);
        }

        private void bubbling_Click(object sender, MouseButtonEventArgs e)
        {
            textBloc.Text += "sender: " + sender.ToString() + "\n" + "source: " + e.Source.ToString() + "\n\n";
            MessageBox.Show(textBloc.Text);
        }

        private void customControl_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Справка по приложению\nАвтор: Кривцова А.П.");
        }

        StudentHistory history = new StudentHistory();
        StudentHistory history2 = new StudentHistory();

        public UserControl RestoreState(TutorMomento memento)
        {
            return memento.Page;
        }

        private void button_Undo(object sender, RoutedEventArgs e)
        {
            try
            {
                UserControl page = new UserControl();
                page = RestoreState(history.History.Pop());
                history2.History.Push(SaveState(page));
                if (page.IsVisible)
                {
                    page = RestoreState(history.History.Pop());
                    history2.History.Push(SaveState(page));
                }

                Add_tutors_control.Visibility = Visibility.Hidden;
                Tutors_control.Visibility = Visibility.Hidden;
                Main_page_control.Visibility = Visibility.Hidden;

                if (page == Tutors_control)
                    Button_Tutors_Click(sender, e);
                else
                    page.Visibility = Visibility.Visible;
            }
            catch
            {
                Main_page_control.Visibility = Visibility.Visible;
                MessageBox.Show("This is your start page");
            }
        }

        private void button_Redo(object sender, RoutedEventArgs e)
        {
            try
            {
                UserControl page = new UserControl();
                page = RestoreState(history2.History.Pop()); 
                history.History.Push(SaveState(page));
                if (page.IsVisible)
                {
                    page = RestoreState(history2.History.Pop());
                    history.History.Push(SaveState(page));
                }

                Add_tutors_control.Visibility = Visibility.Hidden;
                Tutors_control.Visibility = Visibility.Hidden;
                Main_page_control.Visibility = Visibility.Hidden;

                if (page == Tutors_control)
                    Button_Tutors_Click(sender, e);
                else
                    page.Visibility = Visibility.Visible;
            }
            catch
            {
                MessageBox.Show("This is your last page");
            }
        }

        private void OnMouseDownHandler(object sender, MouseEventArgs e)
        {
            ((e.Source as FrameworkElement).Parent as UIElement).RaiseEvent(e);
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuItemLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }

        private void ThemeDark_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            string theme = item.Tag.ToString();
            if (theme == "Light")
            {
                DarkTheme.IsChecked = false;
                var app = App.Current as App;
                app.ChangeTheme(new Uri("Resources/Theme.xaml", UriKind.Relative), new Uri("Resources/Theme.Dark.xaml", UriKind.Relative));
            }
            else
            {
                LightTheme.IsChecked = false;
                var app = App.Current as App;
                app.ChangeTheme(new Uri("Resources/Theme.Dark.xaml", UriKind.Relative), new Uri("Resources/Theme.xaml", UriKind.Relative));
            }
        }

        public void OpenProfile(Object sender, EventArgs e)
        {
            Profile.ProfileInfo.Children.Clear();
            Profile.Visibility = Visibility.Visible;
            Tutors_control.Visibility = Visibility.Hidden;

            Style itemTextStyle = new Style();
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 18.0 });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = FontWeights.Bold });

            Style itemLanguageStyle = new Style();
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 30, 0, 0) });

            Style itemAddTextStyle = new Style();
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 14.0 });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 60, 0, 20) });

            Style descriptionStyle = new Style();
            descriptionStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            descriptionStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 14.0 });
            descriptionStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 120, 0, 20) });

            Style imageStyle = new Style();
            imageStyle.Setters.Add(new Setter { Property = Control.WidthProperty, Value = 200.0 });
            imageStyle.Setters.Add(new Setter { Property = Control.HeightProperty, Value = 200.0 });
            imageStyle.Setters.Add(new Setter { Property = Control.VerticalAlignmentProperty, Value = VerticalAlignment.Top });
            imageStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 20, 0, 20) });

            Style buttonStyle = new Style();
            buttonStyle.Setters.Add(new Setter { Property = Control.WidthProperty, Value = 120.0 });
            buttonStyle.Setters.Add(new Setter { Property = Control.HeightProperty, Value = 40.0 });
            buttonStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            buttonStyle.Setters.Add(new Setter { Property = Control.VerticalAlignmentProperty, Value = VerticalAlignment.Top });
            buttonStyle.Setters.Add(new Setter { Property = Control.HorizontalAlignmentProperty, Value = HorizontalAlignment.Right });
            buttonStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(30, 20, 0, 20) });

            Style gridStyle = new Style();
            gridStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(20, 20, 0, 20) });

            var gridMain = Profile.ProfileInfo;

            StackPanel stackPanel = sender as StackPanel;
            TutorPerson tutor = (TutorPerson)stackPanel.Tag;

            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Orientation = Orientation.Horizontal;

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
            descritption.Text += $"{descr}:\n {tutor.Description}";
            descritption.Style = descriptionStyle;

            Image photo = new Image();
            photo.Source = new BitmapImage(new Uri(tutor.Photo));
            photo.Style = imageStyle;

            var bc = new BrushConverter();

            Button update = new Button();
            update.Style = buttonStyle;
            update.Background = (Brush)bc.ConvertFrom("#edfff2");
            update.BorderBrush = (Brush)bc.ConvertFrom("#80BA91");
            update.Content = Application.Current.Resources[key: "Update"];
            update.Tag = tutor;
            update.Command = ApplicationCommands.Copy;

            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = ApplicationCommands.Copy;
            commandBinding.Executed += LoadUpdateTutorPage;

            update.CommandBindings.Add(commandBinding);
            //update.Click += LoadUpdateTutorPage;

            Button delete = new Button();
            delete.Style = buttonStyle;
            delete.Background = (Brush)bc.ConvertFrom("#ff8585");
            delete.BorderBrush = (Brush)bc.ConvertFrom("#b03131");
            delete.Content = Application.Current.Resources[key: "Delete"];
            delete.Tag = tutor;
            delete.Command = ApplicationCommands.Delete;

            CommandBinding commandBindingDelete = new CommandBinding();
            commandBindingDelete.Command = ApplicationCommands.Delete;
            commandBindingDelete.Executed += DeleteTutor;

            delete.CommandBindings.Add(commandBindingDelete);
            //delete.Click += DeleteTutor;

            wrapPanel.Children.Add(gridForPhoto);
            wrapPanel.Children.Add(grid);
            wrapPanel.Children.Add(gridUpdate);
            wrapPanel.Children.Add(gridDelete);

            gridForPhoto.Children.Add(photo);

            grid.Children.Add(fullName);
            grid.Children.Add(raitingAndPrice);
            grid.Children.Add(language);
            grid.Children.Add(descritption);

            gridUpdate.Children.Add(update);
            gridDelete.Children.Add(delete);

            gridMain.Children.Add(wrapPanel);
        }

        private void Button_Tutors_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                history.History.Push(SaveState(Tutors_control));
            }

            Tutors_control.TutorsList.Items.Clear();
            Tutors_control.Visibility = Visibility.Visible;
            Add_tutors_control.Visibility = Visibility.Hidden;
            Main_page_control.Visibility = Visibility.Hidden;
            Profile.Visibility = Visibility.Hidden;
            TutorPerson[] tutorsAray = XmlSerializeWrapper.DeserializeArrayTutors("D:/tutors.xml");
            var listBox = Tutors_control.TutorsList;
            Style itemTextStyle = new Style();
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = FontWeights.Bold});

            Style itemLanguageStyle = new Style();
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 14.0 });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 30, 0, 0) });


            Style itemAddTextStyle = new Style();
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 12.0 });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 50, 0, 20) });

            Style imageStyle = new Style();
            imageStyle.Setters.Add(new Setter { Property = Control.WidthProperty, Value = 100.0 });
            imageStyle.Setters.Add(new Setter { Property = Control.HeightProperty, Value = 100.0 });

            Style gridStyle = new Style();
            gridStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(20, 20, 0, 0) });


            foreach (var tutor in tutorsAray)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Tag = tutor;
                stackPanel.MouseLeftButtonUp += OpenProfile;

                stackPanel.Orientation = Orientation.Horizontal;
                Grid gridForPhoto = new Grid();
                Grid grid = new Grid();
                gridForPhoto.Style = gridStyle;
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
                raitingAndPrice.Text += $"{raiting}: {tutor.Rating} \n{price}: {tutor.Price}";
                raitingAndPrice.Style = itemAddTextStyle;

                Image photo = new Image();
                photo.Source = new BitmapImage(new Uri(tutor.Photo));
                photo.Style = imageStyle;

                stackPanel.Children.Add(gridForPhoto);
                stackPanel.Children.Add(grid);

                gridForPhoto.Children.Add(photo);
                grid.Children.Add(fullName);
                grid.Children.Add(raitingAndPrice);
                grid.Children.Add(language);

                listBox.Items.Add(stackPanel);
            }
        }

        private void Button_Subjects_Click(object sender, RoutedEventArgs e)
        {
            history.History.Push(SaveState(Main_page_control));
                //if (count == 1)
                //{
                //    history.History.Push(SaveState(Main_page_control)); // сохраняем 
                //    count = 0;
                //}
                //else
                //{
                //    history2.History.Push(SaveState(Main_page_control)); // сохраняем 
                //    count++;
                //}

            Add_tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.TutorsList.Items.Clear();
            Main_page_control.Visibility = Visibility.Visible;
            Main_page_control.UniformGrid.Visibility = Visibility.Visible;
            Main_page_control.GridCategory.Visibility = Visibility.Hidden;
            Profile.Visibility = Visibility.Hidden;
        }

        private void Button_Add_Tutor_Click(object sender, RoutedEventArgs e)
        {
            history.History.Push(SaveState(Add_tutors_control));
            //if (count == 1)
            //    {
            //        history.History.Push(SaveState(Add_tutors_control)); // сохраняем 
            //        count = 0;
            //    }
            //    else
            //    {
            //        history2.History.Push(SaveState(Add_tutors_control)); // сохраняем 
            //        count++;
            //    }

            Tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.TutorsList.Items.Clear();
            Add_tutors_control.Visibility = Visibility.Visible;
            Main_page_control.Visibility = Visibility.Hidden;
            Profile.Visibility = Visibility.Hidden;
        }

        public void DeleteTutor(Object sender, EventArgs e)
        {
            Add_tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.TutorsList.Items.Clear();
            Main_page_control.Visibility = Visibility.Visible;
            Main_page_control.UniformGrid.Visibility = Visibility.Visible;
            Main_page_control.GridCategory.Visibility = Visibility.Hidden;
            Profile.Visibility = Visibility.Hidden;

            Button delete = sender as Button;
            TutorPerson objTutor = (TutorPerson)delete.Tag;

            XDocument element = null;
            using (var stream = new FileStream("D:/tutors.xml", FileMode.Open, FileAccess.Read))
            {
                element = XDocument.Load(stream);
            }

            element.Element("tutors").Elements("tutor").Where(el => el.Element("surname").Value == objTutor.Surname.ToString()).Remove();

            element.Save("D:/tutors.xml");

        }

        public void LoadUpdateTutorPage(Object sender, EventArgs e)
        {
            Add_tutors_control.Visibility = Visibility.Visible;
            Add_tutors_control.Add_tutor_button.Visibility = Visibility.Hidden;
            Tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.TutorsList.Items.Clear();
            Main_page_control.Visibility = Visibility.Hidden;
            Profile.Visibility = Visibility.Hidden;
            Add_tutors_control.Update_tutor_button.Visibility = Visibility.Visible;

            Button delete = sender as Button;
            TutorPerson objTutor = (TutorPerson)delete.Tag;

            Add_tutors_control.Name.Text = objTutor.Name;
            Add_tutors_control.Surname.Text = objTutor.Surname;
            Add_tutors_control.Lastname.Text = objTutor.Lastname;
            Add_tutors_control.Price.Text = objTutor.Price.ToString();
            Add_tutors_control.Description.Text = objTutor.Description;
            Add_tutors_control.Raiting.Text = objTutor.Rating.ToString();
            Add_tutors_control.LenguagesList.SelectedIndex = -1;
            Add_tutors_control.Age.Text = objTutor.Age.ToString();
            Add_tutors_control.imgDynamic.Source = new BitmapImage(new Uri(objTutor.Photo));

            Add_tutors_control.Update_tutor_button.Tag = objTutor;

            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = ApplicationCommands.Undo;
            commandBinding.Executed += UpdateTutor;

            Add_tutors_control.Update_tutor_button.Command = ApplicationCommands.Undo;
            Add_tutors_control.Update_tutor_button.CommandBindings.Add(commandBinding);
            //Add_tutors_control.Update_tutor_button.Click += UpdateTutor;
        }

        public void UpdateTutor(Object sender, EventArgs e)
        {
            var raiting = Convert.ToInt32(Add_tutors_control.Raiting.Text);
            var price = Convert.ToDouble(Add_tutors_control.Price.Text);
            int age = Convert.ToInt32(Add_tutors_control.Age.Text);
            var path = Add_tutors_control.imgDynamic.Source.ToString();
            TextBlock selectedItem = (TextBlock)Add_tutors_control.LenguagesList.SelectedItem;
            string lenguage = selectedItem.Text;

            TutorPerson[] tutorsAray = XmlSerializeWrapper.DeserializeArrayTutors("D:/tutors.xml");

            var tutor = new TutorPerson(tutorsAray.Length + 1, Add_tutors_control.Name.Text, Add_tutors_control.Surname.Text, Add_tutors_control.Lastname.Text,
                age, lenguage, Add_tutors_control.Description.Text, path, raiting, price);

            Button update = sender as Button;
            TutorPerson objTutor = (TutorPerson)update.Tag;

            Add_tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.Visibility = Visibility.Hidden;
            Tutors_control.TutorsList.Items.Clear();
            Main_page_control.Visibility = Visibility.Visible;
            Main_page_control.UniformGrid.Visibility = Visibility.Visible;
            Main_page_control.GridCategory.Visibility = Visibility.Hidden;
            Profile.Visibility = Visibility.Hidden;

            XDocument element = null;
            using (var stream = new FileStream("D:/tutors.xml", FileMode.Open, FileAccess.Read))
            {
                element = XDocument.Load(stream);
            }

            XElement tutortList = new XElement("tutor");
            tutortList.Add(new XElement("id", objTutor.Id),
                new XElement("name", objTutor.Name), new XElement("surname", objTutor.Surname), new XElement("lastname", objTutor.Lastname),
                new XElement("age", objTutor.Age), new XElement("language", objTutor.Lenguage), new XElement("description", objTutor.Description),
                new XElement("photo", objTutor.Photo), new XElement("rating", objTutor.Rating), new XElement("price", objTutor.Price));


            var replacedNode = element.Descendants("tutor")
                           .SingleOrDefault(x => x.Descendants("surname")
                                                  .Single()
                                                  .Value == objTutor.Surname.ToString());
            replacedNode?.ReplaceWith(new XElement("tutor",
                new XElement("name", tutor.Name), new XElement("surname", tutor.Surname), new XElement("lastname", tutor.Lastname),
                new XElement("age", tutor.Age), new XElement("language", tutor.Lenguage), new XElement("description", tutor.Description),
                new XElement("photo", tutor.Photo), new XElement("rating", tutor.Rating), new XElement("price", tutor.Price)));
            element.Save("D:/tutors.xml");

        }

        public void Button_Open_List_Category_Click(object sender, RoutedEventArgs e)
        {
            Main_page_control.UniformGrid.Visibility = Visibility.Hidden;
            Main_page_control.GridCategory.Visibility = Visibility.Visible;
            Button button = sender as Button;
            var selectedLenguage = button.Tag.ToString();

            var bc = new BrushConverter();
            Style listBoxStyle = new Style();
            listBoxStyle.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = (Brush)bc.ConvertFrom("#ffe5b5") });
            listBoxStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(20, 20, 20, 20) });

            ListBox listBox = new ListBox();
            listBox.Style = listBoxStyle;

            Style itemTextStyle = new Style();
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            itemTextStyle.Setters.Add(new Setter { Property = Control.FontWeightProperty, Value = FontWeights.Bold });

            Style itemLanguageStyle = new Style();
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 14.0 });
            itemLanguageStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 30, 0, 0) });

            Style itemAddTextStyle = new Style();
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 12.0 });
            itemAddTextStyle.Setters.Add(new Setter { Property = Control.MarginProperty, Value = new Thickness(0, 50, 0, 20) });


            Style imageStyle = new Style();
            imageStyle.Setters.Add(new Setter { Property = Control.WidthProperty, Value = 100.0 });
            imageStyle.Setters.Add(new Setter { Property = Control.HeightProperty, Value = 100.0 });

            Style noResultStyle = new Style();
            noResultStyle.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("Verdana") });
            noResultStyle.Setters.Add(new Setter { Property = Control.FontSizeProperty, Value = 16.0 });
            noResultStyle.Setters.Add(new Setter { Property = Control.VerticalAlignmentProperty, Value = VerticalAlignment.Center });
            noResultStyle.Setters.Add(new Setter { Property = Control.HorizontalAlignmentProperty, Value = HorizontalAlignment.Center });

            TutorPerson[] tutorsAray = XmlSerializeWrapper.DeserializeArrayTutors("D:/tutors.xml");

            foreach (var tutor in tutorsAray)
            {
                if (tutor.Lenguage == selectedLenguage)
                {
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Tag = tutor;
                    stackPanel.MouseLeftButtonUp += OpenProfile;

                    stackPanel.Orientation = Orientation.Horizontal;
                    Grid gridForPhoto = new Grid();
                    Grid grid = new Grid();

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
                    raitingAndPrice.Text += $"{raiting}: {tutor.Rating} \n{price}: {tutor.Price}";
                    raitingAndPrice.Style = itemAddTextStyle;

                    Image photo = new Image();
                    photo.Source = new BitmapImage(new Uri(tutor.Photo));
                    photo.Style = imageStyle;

                    stackPanel.Children.Add(gridForPhoto);
                    stackPanel.Children.Add(grid);

                    gridForPhoto.Children.Add(photo);
                    grid.Children.Add(fullName);
                    grid.Children.Add(raitingAndPrice);
                    grid.Children.Add(language);

                    listBox.Items.Add(stackPanel);
                }
            }
            Main_page_control.GridCategory.Children.Add(listBox);
            if (listBox.Items.Count == 0)
            {
                Grid grid = new Grid();
                TextBlock result = new TextBlock();
                var no_result = Application.Current.Resources[key: "No_Result"];
                result.Text += $"{no_result} {selectedLenguage.ToLower()}";
                result.Style = noResultStyle;
                Main_page_control.GridCategory.Children.Add(result);
            }
        }

        public TutorMomento SaveState(UserControl page)
        {
            return new TutorMomento(page);
        }
    }

    public class TutorMomento
    {
        public UserControl Page { get; private set; }

        public TutorMomento(UserControl _page)
        {
            this.Page = _page;
        }
    }

    class StudentHistory
    {
        public Stack<TutorMomento> History { get; private set; }
        public StudentHistory()
        {
            History = new Stack<TutorMomento>();
        }
    }

    public class WindowCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
            (
                "Exit",
                "Exit",
                typeof(WindowCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.F4, ModifierKeys.Alt)
                }
            );
    }
}
 
