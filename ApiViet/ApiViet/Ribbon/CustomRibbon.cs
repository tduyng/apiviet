
/* 
 * Learn solution of Victor Chekalin
 */

#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using UIFramework;
#endregion

namespace ApiViet.Ribbon
{
    public class CustomRibbon
    {
        private readonly UIControlledApplication _application;
        private readonly Autodesk.Windows.RibbonControl _ribbonControl;
        //public bool IsVisible;

        public CustomRibbon(UIControlledApplication application)
        {
            _application = application;
            _ribbonControl = RevitRibbonControl.RibbonControl as Autodesk.Windows.RibbonControl;
            if (_ribbonControl is null)
                throw new NotSupportedException("Could not initialize Revit ribbon control");
        }

        public static CustomRibbon GetApplicationRibbon(UIControlledApplication application)
        {
            return new CustomRibbon(application);
        }

        internal UIControlledApplication Application => _application;

        public CustomTab Tab(string tabTitle)
        {
            foreach (var tab in _ribbonControl.Tabs)
            {
                if (tab.Title.Equals(tabTitle))
                {
                    return new CustomTab(this, tabTitle);
                }
            }

            _application.CreateRibbonTab(tabTitle);
            return new CustomTab(this, tabTitle);
        }


        public CustomTab Tab(Autodesk.Revit.UI.Tab systemTab)
        {
            return new CustomTab(this, systemTab);
        }
    }
}
