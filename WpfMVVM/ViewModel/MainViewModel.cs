using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Command;
using WpfMVVM.View;

namespace WpfMVVM.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
		private object currentView;

		public object CurrentView
		{
			get { return currentView; }
			set { 
                currentView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentView"));
            }
		}

        private GreenView greenView;
        private YellowView yellowView;
        private LillaView lillaView;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged() {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentView"));
        }

        public RelayCommand YellowViewCommand { get; } 
        public RelayCommand GreenViewCommand { get; } 
        public RelayCommand LillaViewCommand { get; } 

        public MainViewModel()
        {

            yellowView = new YellowView();
            greenView = new GreenView();
            lillaView = new LillaView();
            CurrentView = greenView;

            YellowViewCommand = new RelayCommand(setYellow);

            GreenViewCommand = new RelayCommand(x=>CurrentView=greenView);
            LillaViewCommand = new RelayCommand(x => CurrentView = lillaView);
        }

        private void setYellow(object v) { 
            CurrentView = yellowView;
        }
    }
}
