using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;

namespace ApiViet.Learning
{
    [Transaction(TransactionMode.Manual)]
    class AppEventRevit :IExternalApplication
    {
        public static bool IsShowEvent = false;
        public Result OnStartup(UIControlledApplication application)
        {
            application.ControlledApplication.DocumentChanged += new EventHandler<DocumentChangedEventArgs>(RevitDocumentChanged);
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            application.ControlledApplication.DocumentChanged -= RevitDocumentChanged;
            return Result.Succeeded;
        }

        public void RevitDocumentChanged(object sender, DocumentChangedEventArgs args)
        {
            if (!IsShowEvent) return;

            // You can get the list of ids of element added/changed/modified. 
            Document doc = args.GetDocument();

            ICollection<ElementId> idsAdded = args.GetAddedElementIds();
            ICollection<ElementId> idsDeleted = args.GetDeletedElementIds();
            ICollection<ElementId> idsModified = args.GetModifiedElementIds();

            //Add to parameter comment
            Element elem;
           
            // Put it in a string to show to the user. 
            string msg = "Added: ";
            foreach (ElementId id in idsAdded)
            {
                elem = doc.GetElement(id);
                Parameter param = elem.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                param.Set(DateTime.Today.ToString());
                msg += id.IntegerValue.ToString() + " ";
            }

            msg += "\nDeleted: ";
            foreach (ElementId id in idsDeleted)
            {
                msg += id.IntegerValue.ToString() + " ";
            }

            msg += "\nModified: ";
            foreach (ElementId id in idsModified)
            {
                msg += id.IntegerValue.ToString() + " ";
            }

            // Show a message to a user. 
            TaskDialogResult res = default(TaskDialogResult);
            res = TaskDialog.Show("Revit UI Labs - Event", msg, TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel);

            // If the user chooses to cancel, show no more event. 
            if (res == TaskDialogResult.Cancel)
            {
                IsShowEvent = false;
            }
        }
    }

    /// <summary>
    /// External command to toggle event message on/off 
    /// </summary> 
    [Transaction(TransactionMode.Manual)]
    public class UIEvent : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            AppEventRevit.IsShowEvent = !AppEventRevit.IsShowEvent;
            TaskDialog.Show("Event", $"Event is enabled: {AppEventRevit.IsShowEvent}");
            return Result.Succeeded;
        }

    }

    [Transaction(TransactionMode.Manual)]
    public class UIEventOn : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            AppEventRevit.IsShowEvent = true;
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class UIEventOff : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            AppEventRevit.IsShowEvent = false;

            return Result.Succeeded;
        }
    }

    //======================================================== 
    // dynamic model update - derive from IUpdater class 
    //======================================================== 

    public class WindowDoorUpdater : IUpdater
    {
        // Unique id for this updater = addin GUID + GUID for this specific updater. 
        UpdaterId m_updaterId = null;

        // Flag to indicate if we want to perform 
        public static bool m_updateActive = false;

        /// <summary>
        /// Constructor 
        /// </summary>
        public WindowDoorUpdater(AddInId id)
        {
            m_updaterId = new UpdaterId(id, new Guid("EF43510F-38CB-4980-844C-72174A674D56"));
        }

        /// <summary>
        /// This is the main function to do the actual job. 
        /// For this exercise, we assume that we want to keep the door and window always at the center. 
        /// </summary>
        public void Execute(UpdaterData data)
        {
            if (!m_updateActive) return;

            Document rvtDoc = data.GetDocument();
            ICollection<ElementId> idsModified = data.GetModifiedElementIds();

            foreach (ElementId id in idsModified)
            {
                //  Wall aWall = rvtDoc.get_Element(id) as Wall; // For 2012
                Wall aWall = rvtDoc.GetElement(id) as Wall; // For 2013
                CenterWindowDoor(rvtDoc, aWall);
            }
        }

        /// <summary>
        /// Helper function for Execute. 
        /// Checks if there is a door or a window on the given wall. 
        /// If it does, adjust the location to the center of the wall. 
        /// For simplicity, we assume there is only one door or window. 
        /// (TBD: or evenly if there are more than one.) 
        /// </summary>
        public void CenterWindowDoor(Document rvtDoc, Wall aWall)
        {
            // Find a winow or a door on the wall. 
            FamilyInstance e = FindWindowDoorOnWall(rvtDoc, aWall);
            if (e == null) return;

            // Move the element (door or window) to the center of the wall. 

            // Center of the wall

            LocationCurve wallLocationCurve = aWall.Location as LocationCurve;

            //XYZ pt1 = wallLocationCurve.Curve.get_EndPoint( 0 ); // 2013
            //XYZ pt2 = wallLocationCurve.Curve.get_EndPoint( 1 ); // 2013
            XYZ pt1 = wallLocationCurve.Curve.GetEndPoint(0); // 2014
            XYZ pt2 = wallLocationCurve.Curve.GetEndPoint(1); // 2014

            XYZ midPt = (pt1 + pt2) * 0.5;

            LocationPoint loc = e.Location as LocationPoint;
            loc.Point = new XYZ(midPt.X, midPt.Y, loc.Point.Z);
        }

        /// <summary>
        /// Helper function 
        /// Find a door or window on the given wall. 
        /// If it does, return it. 
        /// </summary>
        public FamilyInstance FindWindowDoorOnWall(Document rvtDoc, Wall aWall)
        {
            // Collect the list of windows and doors 
            // No object relation graph. So going hard way. 
            // List all the door instances 
            var windowDoorCollector = new FilteredElementCollector(rvtDoc);
            windowDoorCollector.OfClass(typeof(FamilyInstance));

            ElementCategoryFilter windowFilter = new ElementCategoryFilter(BuiltInCategory.OST_Windows);
            ElementCategoryFilter doorFilter = new ElementCategoryFilter(BuiltInCategory.OST_Doors);
            LogicalOrFilter windowDoorFilter = new LogicalOrFilter(windowFilter, doorFilter);

            windowDoorCollector.WherePasses(windowDoorFilter);
            IList<Element> windowDoorList = windowDoorCollector.ToElements();

            // This is really bad in a large model!
            // You might have ten thousand doors and windows.
            // It would make sense to add a bounding box containment or intersection filter as well.

            // Check to see if the door or window is on the wall we got. 
            foreach (FamilyInstance e in windowDoorList)
            {
                if (e.Host.Id.Equals(aWall.Id))
                {
                    return e;
                }
            }

            // If you come here, you did not find window or door on the given wall. 

            return null;
        }

        /// <summary>
        /// This will be shown when the updater is not loaded. 
        /// </summary>
        public string GetAdditionalInformation()
        {
            return "Door/Window updater: keeps doors and windows at the center of walls.";
        }

        /// <summary>
        /// Specify the order of executing updaters. 
        /// </summary>
        public ChangePriority GetChangePriority()
        {
            return ChangePriority.DoorsOpeningsWindows;
        }

        /// <summary>
        /// Return updater id. 
        /// </summary>
        public UpdaterId GetUpdaterId()
        {
            return m_updaterId;
        }

        /// <summary>
        /// User friendly name of the updater 
        /// </summary>
        public string GetUpdaterName()
        {
            return "Window/Door Updater";
        }
    }

    /// <summary>
    /// External command to toggle windowDoor updater on/off 
    /// </summary> 
    [Transaction(TransactionMode.Manual)]
    public class UIDynamicModelUpdate : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            if (WindowDoorUpdater.m_updateActive)
            {
                WindowDoorUpdater.m_updateActive = false;
            }
            else
            {
                WindowDoorUpdater.m_updateActive = true;
            }
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class UIDynamicModelUpdateOn : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            WindowDoorUpdater.m_updateActive = true;

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class UIDynamicModelUpdateOff : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            WindowDoorUpdater.m_updateActive = false;

            return Result.Succeeded;
        }
    }

}

