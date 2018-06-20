using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportDatabase.Command
{
    [Transaction(TransactionMode.Manual)]
    public class ExportDatabase : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            Transaction tx = new Transaction(doc, "Export Database");
            tx.Start();

            tx.Commit();
            return Result.Succeeded;
        }
    }
}
