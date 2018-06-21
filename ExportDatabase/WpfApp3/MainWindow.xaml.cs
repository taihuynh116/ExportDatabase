using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System;

namespace TestBindingError
{
    /// <summary> 
    /// Interaction logic for Window1.xaml 
    /// </summary> 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var appViewModel = new AppViewModel
            {
                Persons = new ObservableCollection<PersonViewModel>
                                                     {
                                                         new PersonViewModel
                                                             {Name = "Joe"},
                                                         new PersonViewModel
                                                             {Name = "Eddy"},
                                                         new PersonViewModel
                                                             {Name = "Francois"}
                                                     }
            };
            DataContext = appViewModel;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class AppViewModel : ViewModelBase
    {
        private ObservableCollection<PersonViewModel> persons;
        private PersonViewModel person;

        public ObservableCollection<PersonViewModel> Persons
        {
            get
            {
                return persons;
            }
            set
            {
                persons = value;
                OnPropertyChanged("Persons");
            }
        }

        public PersonViewModel SelectedPerson
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
                OnPropertyChanged("SelectedPerson");
            }
        }
    }
    public class Country
    {
        public string Code
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
    }
    public class PersonViewModel : ViewModelBase
    {
        private string name;
        private ObservableCollection<Country> countries;
        private Country selectedCountry;
        private Country selectedCountry2;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<Country> Countries
        {
            get
            {
                if (countries == null)
                {
                    countries = new ObservableCollection<Country>
                                    {
                                        new Country {Code = "BE", Name = "Belgium"},
                                        new Country {Code = "NL", Name = "Netherlands"},
                                        new Country {Code = "US", Name = "United States"},
                                        new Country {Code = "FR", Name = "France"}
                                    };
                }
                return countries;
            }
            set
            {
                countries = value;
                OnPropertyChanged("Countries");
            }
        }
        public Country SelectedCountry
        {
            get
            {
                return selectedCountry;
            }
            set
            {
                selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
            }
        }
        public Country SelectedCountry2
        {
            get
            {
                return selectedCountry2;
            }
            set
            {
                selectedCountry2 = value;
                OnPropertyChanged("SelectedCountry2");
            }
        }
    }
}