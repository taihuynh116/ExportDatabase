using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

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
        
        private Visibility taskLabelVis = Visibility.Visible;
        public Visibility TaskLabelVisibility
        {
            get { return taskLabelVis; }
            set
            {
                if (taskLabelVis != value)
                {
                    taskLabelVis = value;
                    OnPropertyChanged();
                }
            }
        }
        private Visibility taskComboBoxVis = Visibility.Collapsed;
        public Visibility TaskComboBoxVisibility
        {
            get { return taskComboBoxVis; }
            set
            {
                if (taskComboBoxVis != value)
                {
                    taskComboBoxVis = value;
                    OnPropertyChanged();
                }
            }
        }
        public Category SelectedCategory { get; set; }
        private Task selectedlabeltask;
        public Task SelectedLabelTask
        {
            get
            { return selectedlabeltask; }
            set
            {
                selectedlabeltask = value;
                OnPropertyChanged();
            }
        }
        public Task SelectedComboBoxTask { get; set; }
        public ParameterName SelectedUnusedParameter { get; set; }
        public ParameterName SelectedUsedParameter { get; set; }
        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
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
