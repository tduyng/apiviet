using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;

namespace ApiViet.Learning
{
    class EventRegistering : IExternalDBApplication
    {
        public ExternalDBApplicationResult OnStartup(ControlledApplication application)
        {
            try
            {
                //application.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(ElementChangedEvent);
                application.DocumentSaving += new EventHandler<DocumentSavingEventArgs>(RegisterSaveEvent);
            }
            catch (Exception )
            {
                return ExternalDBApplicationResult.Failed;
            }

            return ExternalDBApplicationResult.Succeeded;
        }

        public ExternalDBApplicationResult OnShutdown(ControlledApplication application)
        {
            application.DocumentSaving -= new EventHandler<DocumentSavingEventArgs>(RegisterSaveEvent);
            return ExternalDBApplicationResult.Succeeded;
        }


        public void ElementChangedEvent(object sender, DocumentChangedEventArgs args)
        {
            ElementFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Furniture);
            ElementId elemId = args.GetModifiedElementIds(filter).First();
            string name = args.GetTransactionNames().First();
            TaskDialog.Show("Modified Element", $"{elemId.ToString()} changed by {name}");
        }

        public void RegisterSaveEvent(object sender, DocumentSavingEventArgs args)
        {
            // Tell user what we're doing
            Document doc = args.Document;
            TaskDialog td = new TaskDialog("Alert");
            td.MainInstruction = "Application 'Automatic element creator' needs to reload changes from central in order to proceed.";
            td.MainContent = "Are you sure to save this project?";
            td.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;

            TaskDialogResult result = td.Show();

            if (result == TaskDialogResult.Ok)
            {
                // There are no currently customizable user options for ReloadLatest.
                doc.Save();
                doc.Close();
            }
            else
            {
                doc.Close();
            }

        }

    }
}
