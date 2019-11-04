using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace ApiViet.Learning
{
    [Transaction(TransactionMode.Manual)]
    class CmdChangeLocation:IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Reference pickObj = uidoc.Selection.PickObject(ObjectType.Element);
            ElementId eleId = pickObj.ElementId;
            Element ele = doc.GetElement(eleId);

            using (Transaction trans = new Transaction(doc, "Change Location"))
            {
                if (ele.Location is LocationPoint locp)
                {
                    trans.Start();
                    XYZ loc = locp.Point;
                    XYZ newLoc = new XYZ(loc.X +UnitUtils.ConvertToInternalUnits(3, DisplayUnitType.DUT_METERS), 
                        loc.Y+ UnitUtils.ConvertToInternalUnits(10, DisplayUnitType.DUT_METERS), loc.Z);
                    locp.Point = newLoc;
                    trans.Commit();
                    return Result.Succeeded;
                }
            }

            return Result.Failed;
        }

    }
}
