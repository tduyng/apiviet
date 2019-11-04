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
    class CmdGetParameter : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                Reference pickObj = uidoc.Selection.PickObject(ObjectType.Element);
                if (pickObj != null)
                {
                    var eleId = pickObj.ElementId;
                    var ele = doc.GetElement(eleId);

                    //Get parameter
                    Parameter param = ele.LookupParameter("Head Height");
                    InternalDefinition paramDef = param.Definition as InternalDefinition;
                    TaskDialog.Show("Parameters",
                        $"{paramDef.Name} parameter of type {paramDef.UnitType} with builtinparameer {paramDef.BuiltInParameter}");
                }
                return Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
        }
    }
}
