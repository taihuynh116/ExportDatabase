using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Singleton.Instance.People.Add(new Person(0, "Tài"));
            Singleton.Instance.People.Add(new Person(1, "Tuấn"));
            Singleton.Instance.People.Add(new Person(2, "Vũ"));
            Singleton.Instance.People.Add(new Person(3, "Như"));

            UserControl1 form = new UserControl1();
            form.ShowDialog();

            Singleton.Instance.People.Add(new Person(4, "Đông"));
            Singleton.Instance.People.Add(new Person(5, "Phong"));

            form.ShowDialog();


            return Result.Succeeded;
        }
    }
}
