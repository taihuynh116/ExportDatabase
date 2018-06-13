using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    class MyCustomClass
    {
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.SaveObject(),
                        param => this.CanSave()
                        );
                }
                return _saveCommand;
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
