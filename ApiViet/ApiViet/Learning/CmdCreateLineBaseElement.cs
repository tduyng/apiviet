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
    class CmdCreateLineBaseElement :IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            XYZ p1 = new XYZ(-10,10,0);
            XYZ p2 = new XYZ(10, 10,0);
            XYZ p3 = new XYZ(15,0,0);
            XYZ p4 = new XYZ(10,-10,0);
            XYZ p5 = new XYZ(-10,-10,0);

            List<Curve> curves = new List<Curve>()
            {
                Line.CreateBound(p1,p2),
                Arc.Create(p2,p4,p3),
                Line.CreateBound(p4,p5),
                Line.CreateBound(p5,p1)
            };

            Level level = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .Cast<Level>()
                .First(x => x.Name == "Level 1");
            CurveLoop curveLoops = CurveLoop.Create(curves);
            double offset = UnitUtils.ConvertToInternalUnits(-10, DisplayUnitType.DUT_CENTIMETERS);
            CurveLoop offsetsrv = CurveLoop.CreateViaOffset(curveLoops,offset,new XYZ(0,0,1));
            CurveArray curveArray = new CurveArray();
            foreach (var c in offsetsrv)
            {
                curveArray.Append(c);
            }
            using (Transaction trans = new Transaction(doc, "Create Wall"))
            {
                trans.Start();
                foreach (Curve curve in curves)
                {
                    Wall.Create(doc, curve, level.Id, true);
                }

                doc.Create.NewFloor(curveArray, true);
                trans.Commit();
            }
            return Result.Succeeded;
        }
    }
}
