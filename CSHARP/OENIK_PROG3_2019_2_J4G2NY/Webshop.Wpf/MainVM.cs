using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Webshop.Wpf
{
    class MainVM : ViewModelBase
    {
        private MainLogic logic;
        private ObservableCollection<LocationVM> allLocations;
        private LocationVM selectedLocation;

        public LocationVM SelectedLocation
        {
            get { return selectedLocation; }
            set { Set(ref selectedLocation, value); }
        }
        public ObservableCollection<LocationVM> AllLocations
        {
            get { return allLocations; }
            set { Set(ref allLocations, value); }
        }

        public ICommand AddCmd { get; private set; }
        public ICommand DelCmd { get; private set; }
        public ICommand ModCmd { get; private set; }
        public ICommand LoadCmd { get; private set; }

        public Func<LocationVM, bool> EditorFunc { get; set; }

        public MainVM()
        {
            logic = new MainLogic();

            LoadCmd = new RelayCommand(() =>
                    AllLocations = new ObservableCollection<LocationVM>(logic.ApiGetLocations()));
            DelCmd = new RelayCommand(() => logic.ApiDelLocation(selectedLocation));
            AddCmd = new RelayCommand(() => logic.EditLocation(null, EditorFunc));
            ModCmd = new RelayCommand(() => logic.EditLocation(selectedLocation, EditorFunc));
        }
    }
}
