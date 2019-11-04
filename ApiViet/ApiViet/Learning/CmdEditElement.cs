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
    class CmdEditElement:IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Reference pickObj = uidoc.Selection.PickObject(ObjectType.Element);
            ElementId eleId = pickObj.ElementId;
            Element ele = doc.GetElement(eleId);
            using (Transaction trans = new Transaction(doc, "Edit Element"))
            {
                trans.Start();
                //Move element
                XYZ moveVec = new XYZ(3,3,0);
                ElementTransformUtils.MoveElement(doc,eleId,moveVec);

                //Rotate element
                LocationPoint locp = ele.Location as LocationPoint;
                XYZ p1 = locp.Point;
                XYZ p2 = new XYZ(p1.X,p1.Y,p1.Z+10);
                Line axis = Line.CreateBound(p1, p2);
                double angle = 30 * Math.PI / 180;
                ElementTransformUtils.RotateElement(doc,eleId,axis,angle);
                trans.Commit();
                return Result.Succeeded;
            }
        }
    }
}
