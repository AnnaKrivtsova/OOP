using lab13.Commands;
using lab13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab13.ViewModels
{
    class TutorViewModel : ViewModelBase
    {
        public Tutor Tutor;

        public TutorViewModel(Tutor tutor)
        {
            this.Tutor = tutor;
        }

        public string Name
        {
            get { return Tutor.Name; }
            set
            {
                Tutor.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return Tutor.Surname; }
            set
            {
                Tutor.Surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Subject 
        {
            get { return Tutor.Subject; }
            set
            {
                Tutor.Subject = value;
                OnPropertyChanged("Subject");
            }
        }

        public string Date
        {
            get { return Tutor.Date; }
            set
            {
                Tutor.Date = value;
                OnPropertyChanged("Date");
            }
        }

        public string Time
        {
            get { return Tutor.Time; }
            set
            {
                Tutor.Time = value;
                OnPropertyChanged("Time");
            }
        }

        public int IsSelected
        {
            get { return Tutor.IsSelected; }
            set
            {
                Tutor.IsSelected = value;
                OnPropertyChanged("Time");
            }
        }

        #region Commands

        #region Отменить

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem,CanGetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            IsSelected--;
        }

        private bool CanGetItem()
        {
            return IsSelected != 0;
        }

        #endregion

        #region Забронировать

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(GiveItem, CanGiveItem);
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            IsSelected++;
        }

        private bool CanGiveItem()
        {
            return IsSelected == 0;
        }

        #endregion

        #endregion
    }
}
