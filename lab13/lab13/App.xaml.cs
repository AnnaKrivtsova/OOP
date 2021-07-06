using lab13.Models;
using lab13.ViewModels;
using lab13.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace lab13
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            DateTime time = DateTime.Now;
            DateTime time2 = DateTime.Now.AddHours(1.0);
            DateTime date = DateTime.Now;
            string timeResult = time.ToShortTimeString() + " - " + time2.ToShortTimeString();
            List<Tutor> tutors = new List<Tutor>()
            {
                new Tutor("name1", "surname1", "subject1", date.ToShortDateString(),timeResult,0),
                new Tutor("name2", "surname2", "subject2", date.ToShortDateString(),timeResult,0),
                new Tutor("name3", "surname3", "subject3", date.ToShortDateString(),timeResult,0),
                new Tutor("name4", "surname4", "subject4", date.ToShortDateString(),timeResult,0),
            };

            UnitOfWork unitOfWork = new UnitOfWork();

            foreach (Tutor tutor in tutors)
                unitOfWork.Tutors.Create(tutor);

            //UnitOfWork unitOfWork = new UnitOfWork();

            MainView view = new MainView(); // создали View
            //var tutors = unitOfWork.Tutors.Get();
            //MainViewModel viewModel = new MainViewModel(tutors.ToList()); // Создали ViewModel
            MainViewModel viewModel = new MainViewModel(tutors); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
