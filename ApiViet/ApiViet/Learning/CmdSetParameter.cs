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
    class CmdSetParameter :IExternalCommand 
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Reference pickObj = uidoc.Selection.PickObject(ObjectType.Element);
            ElementId eleId = pickObj.ElementId;
            Element ele = doc.GetElement(eleId);
            if (pickObj != null)
            {
                //Get Parameter
                Parameter param = ele.get_Parameter(BuiltInParameter.INSTANCE_HEAD_HEIGHT_PARAM);
                TaskDialog.Show("Parameters", $"Parameter storage type " +
                                              $"{param.StorageType.ToString()} " +
                                              $"and value {param.AsDouble()}");

                //Set parameter
                using (Transaction trans = new Transaction(doc, "Set Parameter"))
                {
                    trans.Start();
                    double headHeight = UnitUtils.ConvertToInternalUnits(3, DisplayUnitType.DUT_METERS);
                    param.Set(headHeight);
                    trans.Commit();
                    return Result.Succeeded;
                }
            }

            return Result.Failed;
        }
    }
}
