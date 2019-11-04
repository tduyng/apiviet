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
    class CmdSelectGeometry:IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Reference pickObj = uidoc.Selection.PickObject(ObjectType.Element);
            ElementId eleId = pickObj.ElementId;
            Element ele = doc.GetElement(eleId);

            //Get Gemetry
            Options gOption = new Options();
            gOption.DetailLevel = ViewDetailLevel.Fine;
            GeometryElement geom = ele.get_Geometry(gOption);
            
            //Traverse Geometry
            foreach (GeometryObject gObj in geom)
            {
                Solid gSolid = gObj as Solid;
                int faces = 0;
                double area = 0.0;
                foreach (Face gFace in gSolid.Faces)
                {
                    area = gFace.Area;
                    faces++;
                }

                area = UnitUtils.ConvertToInternalUnits(area, DisplayUnitType.DUT_METERS);
                TaskDialog.Show("Geometry", $"Number of faces:{faces}\nTotal area: {area}");
               

            }
            return Result.Succeeded;
        }
    }
}
