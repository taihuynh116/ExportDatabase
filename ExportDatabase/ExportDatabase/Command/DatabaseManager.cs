using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ExportDatabase.ProjectData.EF;
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
            Singleton.Instance.DataForm.ShowDialog();

            return Result.Succeeded;
        }
    }
}
