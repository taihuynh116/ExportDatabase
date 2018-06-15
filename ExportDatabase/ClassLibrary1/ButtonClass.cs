using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClassLibrary1
{
    class ButtonClass
    {
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(x => this.Close(x), x => this.CanSave()));
            }
        }
        public bool CanSave()
        {
            return true;
        }
        public void Close(object o)
        {
            ((Window)o).Hide();
        }
    }
}
