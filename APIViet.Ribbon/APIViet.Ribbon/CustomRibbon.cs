
/* 
 * Learn solution of Victor Chekalin
 * 
 * THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
 * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 * PARTICULAR PURPOSE.
 * 
 */

#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using adWin = Autodesk.Windows;
using UIFramework;
#endregion

namespace APIViet.Ribbon
{
    public class CustomRibbon
    {
        private readonly UIControlledApplication _application;
        private readonly adWin.RibbonControl _ribbonControl;
        //public bool IsVisible;

        public CustomRibbon(UIControlledApplication application)
        {
            _application = application;
            _ribbonControl = RevitRibbonControl.RibbonControl as adWin.RibbonControl;
            if (_ribbonControl == null)
                throw new NotSupportedException("Could not initialize Revit ribbon control");
        }

        public static CustomRibbon GetApplicationRibbon(UIControlledApplication application)
        {
            return new CustomRibbon(application);
        }

        internal UIControlledApplication Application
        {
            get { return _application; }
        }

        public CustomTab Tab(string tabTitle)
        {
            foreach (var tab in _ribbonControl.Tabs)
            {
                if (tab.Title.Equals(tabTitle))
                {
                    return new CustomTab(this, tabTitle);
                }
            }

            //RibbonTab ribbonTab =
            //    new RibbonTab()
            //        {
            //            Title = tabTitle,
            //            IsVisible = true,
            //            Name = tabTitle,

            //        };
            //_ribbonControl.Tabs.Add(ribbonTab);

            _application.CreateRibbonTab(tabTitle);
            return new CustomTab(this, tabTitle);
        }


        public CustomTab Tab(Autodesk.Revit.UI.Tab systemTab)
        {
            return new CustomTab(this, systemTab);
        }
        //public void SetVisibleTab(CustomTab tab,bool isVisible)
        //{
        //    IsVisible = isVisible;
        //    return this;
        //}
    }
}
