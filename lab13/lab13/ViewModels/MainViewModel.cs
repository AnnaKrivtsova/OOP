using lab13.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TutorViewModel> TutorsList { get; set; }

        #region Constructor

        public MainViewModel(List<Tutor> tutors)
        {
            TutorsList = new ObservableCollection<TutorViewModel>(tutors.Select(b => new TutorViewModel(b)));
        }

        #endregion
    }
}
