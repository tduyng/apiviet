#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace APIViet.Ribbon
{
    public class Panel
    {
        //Creat a panel in a tab specific
        public RibbonPanel Add(UIControlledApplication app, string tabName, string panelName)
        {
            return app.CreateRibbonPanel(tabName, panelName);
        }
        
        
        //Create a Panel in tab AddIn
        public RibbonPanel Add (UIControlledApplication app, string panelName)
        {
            return app.CreateRibbonPanel(panelName);
        }
    }
}
