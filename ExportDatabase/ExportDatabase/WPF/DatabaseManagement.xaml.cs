using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExportDatabase.WPF
{
    /// <summary>
    /// Interaction logic for DatabaseManagement.xaml
    /// </summary>
    public partial class DatabaseManagement : Window
    {
        public DatabaseManagement()
        {
            InitializeComponent();
            cbbCategory.ItemsSource = CategoryDao.GetCategories();
            //cbbCategory.DisplayMemberPath = "Name";
            //cbbCategory.SelectedValuePath = "ID";
        }

        private void cbbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Category cate = cbbCategory.SelectedItem as Category;
            List<ParameterName> usedParams = ParameterNameDao.GetParameterNames((int)cbbCategory.SelectedValue);
            List<ParameterName> unusedParams = ParameterNameDao.GetParameterNames((int)cbbCategory.SelectedValue, false);

            lbUsedParameter.ItemsSource = usedParams;
            lbUnusedParameter.ItemsSource = unusedParams;
        }

        private void lbUsedParameter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task task = TaskDao.GetTask(TaskDao.GetId((int)cbbCategory.SelectedValue, (int)lbUsedParameter.SelectedValue));
            lbTask.Content = task == null ? "" : task.Name;
        }
    }
}
