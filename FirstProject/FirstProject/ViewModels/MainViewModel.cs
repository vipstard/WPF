using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FirstProject.ViewModels
{
     class MainViewModel : INotifyPropertyChanged
    {
        private int progressValue;
        public ICommand relayCommand { get; set; }

        public MainViewModel()
        {
            relayCommand = new RelayCommand<object>(ExecuteMyButton, CanMyButton);
        }

        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = value;
                NotifyPropertyChanged(nameof(progressValue));
            }
        }

        bool CanMyButton(object param)
        {
            if (param == null)
            {
                return true;
            }
            return param.ToString().Equals("ABC")?true : false;
        }

        void ExecuteMyButton(object param)
        {
            MessageBox.Show(param.ToString() + "AAA");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
