using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    public class ButtonClass
    {
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(x => this.SaveObject(), x => this.CanSave()));
            }
        }
        public bool CanSave()
        {
            return true;
        }
        public void SaveObject()
        {
            MessageBox.Show("OK");
        }
    }
}
