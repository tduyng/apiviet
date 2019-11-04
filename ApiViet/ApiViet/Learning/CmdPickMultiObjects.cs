using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ApiViet.Learning
{
    [Transaction(TransactionMode.Manual)]
    public class  CmdPickMultiObjects :IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Selection sel = uidoc.Selection;
            IList<Element> elems = new List<Element>();
            if (sel != null)
            {
                elems = sel.GetElementIds().Select(x => doc.GetElement(x)).ToList();
            }
            else
            {
                elems = uidoc.Selection
                    .PickObjects(ObjectType.Element, "Select multiple elements")
                    .Select(x => doc.GetElement(x)).ToList();
            }
            ShowElementList(elems, "Picked Objects: ");
            return Result.Succeeded;
        }

        // show current selection
        public void ShowElementList(IEnumerable<Element> elems, string header)
        {
            string result;
            StringBuilder s = new StringBuilder("\n\n - Class - Category - Name (or Family:Type Name) - Id - " + "\r\n");
            int count = 0;
            foreach (var e in elems)
            {
                count++;
                s.Append(ElementToString(e));
            }

            result = $"{header}({count}):{s.ToString()}";
            TaskDialog.Show("Picked Element Information", result);
        }

        public string ElementToString(Element e)
        {
            string name = "";
            if (e is null)
                return "none";
            if (e is ElementType)
            {
                Parameter param = e.get_Parameter(BuiltInParameter.SYMBOL_FAMILY_AND_TYPE_NAMES_PARAM);
                name = param?.AsString();
            }
            else
            {
                name = e.Name;
            }
            return
               $"{e.GetType().Name}; {e.Category.Name}; {e.Category.Name}; name; {e.Id.IntegerValue.ToString()}\r\n";

        }
    }
}
