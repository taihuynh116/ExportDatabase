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
        public static WPFDbContext Instance { get { if (instance == null) instance = new WPFDbContext(); return instance; } }
        #endregion

        #region Task
        private Visibility usedTaskVis = Visibility.Visible;
        public Visibility UsedTaskVisibility { get { return usedTaskVis; } set { if (usedTaskVis == value) return;  usedTaskVis = value; OnPropertyChanged(); } }
        private Visibility unusedTaskVis = Visibility.Collapsed;
        public Visibility UnusedTaskVisibility { get { return unusedTaskVis; } set { if (unusedTaskVis == value) return;  unusedTaskVis = value; OnPropertyChanged(); } }
        private Task selectedusedTask;
        public Task SelectedUsedTask { get { return selectedusedTask; } set {  selectedusedTask = value; OnPropertyChanged(); } }
        public Task SelectedUnusedTask { get; set; }
        public int TempSelectedTaskIndex { get; set; } = -1;
        #endregion

        #region Category
        private Category selectedCategory;
        public Category SelectedCategory { get { return selectedCategory; }set { selectedCategory = value;  OnPropertyChanged();  } }
        public int TempSelectedCategoryIndex { get; set; } = -1;
        #endregion

        #region Parameter
        public ParameterName SelectedUnusedParameter { get; set; }
        public ParameterName SelectedUsedParameter { get; set; }
        #endregion

        #region Tasks, Categories, UsedParameters, UnsedParameters
        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();
        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public ObservableCollection<ParameterName> UsedParameters { get; set; } = new ObservableCollection<ParameterName>();
        public ObservableCollection<ParameterName> UnusedParameters { get; set; } = new ObservableCollection<ParameterName>();
        #endregion

        public ItemTypeEnum RemoveItemType { get; set; }

        #region AddItemForm
        private AddItem addItem;
        public AddItem AddItem { get { if (addItem == null) addItem = new AddItem(); return addItem; } }
        private ItemTypeEnum additemtype;
        public ItemTypeEnum AddItemType { get { return additemtype; } set { if (additemtype == value) return;  additemtype = value; OnPropertyChanged(); } }
        private string itemname;
        public string ItemName { get { return itemname; } set { if (itemname == value) return; itemname = value; OnPropertyChanged(); } }
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
