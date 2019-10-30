#region Namespaces

using System;
using System.Collections.Generic;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;

#endregion

namespace ApiViet
{
    [Transaction(TransactionMode.Manual)]
    public class AppUIRibbon
    {
        public Result OnStartup(UIControlledApplication a)
        {
            // Method to add Tab and Panel 
            RibbonPanel panel = ribbonPanel(a);
            // Reflection to look for this assembly path 
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            // Add button to panel
            PushButton button = panel.AddItem(new PushButtonData("Button", "API Button", thisAssemblyPath, "MyTest.Command")) as PushButton;
            // Add tool tip 
            button.ToolTip = "this is a sample";
            // Reflection of path to image 
            var globePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "LACMA DOORS.png");
            Uri uriImage = new Uri(globePath);
            // Apply image to bitmap
            BitmapImage largeImage = new BitmapImage(uriImage);
            // Apply image to button 
            button.LargeImage = largeImage;

            a.ApplicationClosing += a_ApplicationClosing;

            //Set Application to Idling
            a.Idling += a_Idling;

            return Result.Succeeded;
        }

        //*****************************a_Idling()*****************************
        void a_Idling(object sender, Autodesk.Revit.UI.Events.IdlingEventArgs e)
        {

        }

        //*****************************a_ApplicationClosing()*****************************
        void a_ApplicationClosing(object sender, Autodesk.Revit.UI.Events.ApplicationClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        //*****************************ribbonPanel()*****************************
        public RibbonPanel ribbonPanel(UIControlledApplication a)
        {
            string tab = "By Danny Bentley"; // Tab name
            // Empty ribbon panel 
            RibbonPanel ribbonPanel = null;
            // Try to create ribbon tab. 
            try
            {
                a.CreateRibbonTab(tab);
            }
            catch { }
            // Try to create ribbon panel.
            try
            {
                RibbonPanel panel = a.CreateRibbonPanel(tab, "test");
            }
            catch { }
            // Search existing tab for your panel.
            List<RibbonPanel> panels = a.GetRibbonPanels(tab);
            foreach (RibbonPanel p in panels)
            {
                if (p.Name == "test")
                {
                    ribbonPanel = p;
                }
            }
            //return panel 
            return ribbonPanel;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}

