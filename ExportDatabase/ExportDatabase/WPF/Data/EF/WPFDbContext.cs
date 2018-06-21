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
        #region Instance
        private static WPFDbContext instance;
        public static WPFDbContext Instance
        {
            get
            {
                if (instance == null) instance = new WPFDbContext();
                return instance;
            }
        }
        #endregion

        #region UnusedTask and UsedTask
        private Visibility usedTaskVis = Visibility.Visible;
        public Visibility UsedTaskVisibility
        {
            get { return usedTaskVis; }
            set
            {
                if (usedTaskVis != value)
                {
                    usedTaskVis = value;
                    OnPropertyChanged();
                }
            }
        }
        private Visibility unusedTaskVis = Visibility.Collapsed;
        public Visibility UnusedTaskVisibility
        {
            get { return unusedTaskVis; }
            set
            {
                if (unusedTaskVis != value)
                {
                    unusedTaskVis = value;
                    OnPropertyChanged();
                }
            }
        }
        public Category SelectedCategory { get; set; }
        public Task SelectedUsedTask { get; set; }
        private int selectedUsedTaskIndex = -1;
        public int SelectedUsedTaskIndex
        {
            get { return selectedUsedTaskIndex; }
            set { if (selectedUsedTaskIndex != value) { selectedUsedTaskIndex = value; OnPropertyChanged(); } }
        }
        public Task SelectedUnusedTask { get; set; }
        #endregion

        #region UnusedParameter and UsedParameter
        public ParameterName SelectedUnusedParameter { get; set; }
        public ParameterName SelectedUsedParameter { get; set; }
        #endregion

        #region Tasks, Categories, UsedParameters, UnsedParameters
        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public ObservableCollection<ParameterName> UsedParameters { get; set; } = new ObservableCollection<ParameterName>();
        public ObservableCollection<ParameterName> UnusedParameters { get; set; } = new ObservableCollection<ParameterName>();
        #endregion

        #region AddItemForm
        private AddItem addItem;
        public AddItem AddItem { get { if (addItem == null) addItem = new AddItem(); return addItem; } }
        public string Title
        {
            get
            {
                switch (AddItemType)
                {
                    case AddItemType.Category: return "Add Category";
                    case AddItemType.Task: return "Add Task";
                    case AddItemType.ParameterName: return "Add ParameterName";
                }
                throw new Exception();
            }
        }
        private AddItemType additemtype;
        public AddItemType AddItemType
        {
            get
            {
                return additemtype;
            }
            set
            {
                if (additemtype == value) return;
                additemtype = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
