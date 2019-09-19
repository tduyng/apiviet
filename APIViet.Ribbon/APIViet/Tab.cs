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
    /// <summary>
    /// Create a ribbon tab
    /// </summary>
    //[Transaction(TransactionMode.Manual)]


    public class Tab
    {
        public void AddRibbon(UIControlledApplication app, string tabName)
        {
            app.CreateRibbonTab(tabName);
        }
    }
 
}
