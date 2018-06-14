using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class DataProject
    {
        public static DataProject instance;
        public static DataProject Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProject() { ComboBoxClass = new ComboBoxClass(), ButtonClass = new ButtonClass(), Employee = new Employee() { EmpID = 123, EmpName = "ABC" } };
                return instance;
            }
        }
        public ComboBoxClass ComboBoxClass { get; set; }
        public ButtonClass ButtonClass { get; set; }
        public Employee Employee { get; set; }
        public DataProject()
        {
            ComboBoxClass = new ComboBoxClass();
            ButtonClass = new ButtonClass();
            Employee = new Employee() { EmpID = 123, EmpName = "ABC" };
        }
    }
}
