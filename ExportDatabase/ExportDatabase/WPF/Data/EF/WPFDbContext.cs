using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExportDatabase.WPF
{
    public class WPFDbContext : INotifyPropertyChanged
    {
        private static WPFDbContext instance;
        public static WPFDbContext Instance
        {
            get
            {
                if (instance == null) instance = new WPFDbContext();
                return instance;
            }
        }
        private Task currentTask;
        public Task CurrentTask
        {
            get
            { return currentTask; }
            set
            {
                currentTask = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public ObservableCollection<ParameterName> UsedParameters { get; set; } = new ObservableCollection<ParameterName>();
        public ObservableCollection<ParameterName> UnusedParameters { get; set; } = new ObservableCollection<ParameterName>();
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
