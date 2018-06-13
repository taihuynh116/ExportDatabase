using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ExportDatabase.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.Command
{
    [Transaction(TransactionMode.Manual)]
    class DatabaseManager : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            DatabaseManagement dm = new DatabaseManagement();
            dm.ShowDialog();

            return Result.Succeeded;
        }
    }
}
