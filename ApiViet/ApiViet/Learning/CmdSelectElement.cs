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
    class CmdSelectElement : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            try
            {
                Reference pickedObj = uidoc.Selection?.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                //Get Element
                ElementId eleId = pickedObj.ElementId;
                Element ele = doc.GetElement(eleId);

                //Ger Element Type
                ElementId eTypeId = ele.GetTypeId();
                ElementType eType = doc.GetElement(eTypeId) as ElementType;
                if (pickedObj != null)
                {
                    using (var trans = new Transaction(doc, "Delete Element"))
                    {
                        trans.Start();
                        doc.Delete(eleId);
                        TaskDialog tDialog = new TaskDialog("Delete Element");
                        tDialog.MainContent = "Are you sure you want to delete this element?";
                        tDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
                        if (tDialog.Show() == TaskDialogResult.Ok)
                        {
                            trans.Commit();
                            TaskDialog.Show("Delete", $"{eleId.ToString()} deleted.");
                        }
                        else
                        {
                            trans.RollBack();
                        }
                    }

                    //string info = $"Element Id: {eleId.ToString()}{Environment.NewLine}" +
                    //              $"Caterogy: {ele.Category.Name}{Environment.NewLine}" +
                    //              $"Instance: {ele.Name}{Environment.NewLine}" +
                    //              $"Symbol: {eType.Name}{Environment.NewLine}" +
                    //              $"Family: {eType.FamilyName}";
                    //TaskDialog.Show("Element Info",info);
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
