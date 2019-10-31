using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ApiViet.Learning
{
    [Transaction(TransactionMode.Manual)]
    class CmdCollector : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            //Create Filtered Element collector
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ElementQuickFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Windows);

            //Apply filter
            IList<Element> windows = collector
                    .WherePasses(filter).WhereElementIsNotElementType().ToElements();
            TaskDialog.Show("Windows", $"{windows.Count} windows founds");
            StringBuilder infoWindows = new StringBuilder();
            foreach (var window in windows)
            {
                if (window?.Id != null && window?.Name != null && 
                    window?.Document?.GetElement(window?.LevelId) != null)
                    {
                        infoWindows.Append(
                            $"Id: {window.Id} - Name: {window.Name} - Level: {window.Document.GetElement(window.LevelId).Name}\n");
                    }
            }

            TaskDialog.Show("Window", infoWindows.ToString());
            return Result.Succeeded;
            }
        }
    }
