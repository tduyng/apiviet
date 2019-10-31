using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ApiViet.Learning
{
    [Transaction(TransactionMode.Manual)]
    class CmdCollectorWithLINQ : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            FamilySymbol symbol = collector.OfClass(typeof(FamilySymbol))
                .WhereElementIsElementType()
                .Cast<FamilySymbol>()
                .First(x => x.Name == "M_RPC Beetle");

            try
            {
                using (Transaction trans = new Transaction(doc, "Place Family"))
                {
                    trans.Start();
                    if (!symbol.IsActive)
                    {
                        symbol.Activate();
                    }
                    doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), symbol,Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    TaskDialog tDialog = new TaskDialog("Create Family");
                    tDialog.MainContent = $"Are you sure de create a family instance {nameof(symbol)}";
                    tDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
                    if (tDialog.Show() == TaskDialogResult.Ok)
                    {
                        trans.Commit();
                        return Result.Succeeded;
                    }
                    trans.RollBack();
                    return Result.Failed;
                }
            }
            catch (Exception e)
            {
                message = e.Message;
                throw;
            }

        }
    }
}
