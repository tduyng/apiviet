
/* 
 * Learn solution of Victor Chekalin: https://github.com/chekalin-v/VCRevitRibbonUtil
 * Improve by solution of CADBIMDeveloper: https://github.com/CADBIMDeveloper/RevitRibbonSample
 * Posibility using the solution Autodesk.Revit.UI(create ribbon items direct with the api autodesk)
 * and Autodesk.Windows(solution advance to search and modify the existed ribbon items)
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
using ApiViet.Ribbon.Extensions;
#endregion

namespace ApiViet.Ribbon
{
    public class CustomRibbon
    {
        //using the Autodesk.Windows and UIFramework to search the existing RibbonItem created in revit
        private readonly UIApplication _uiapp;
        private readonly Autodesk.Windows.RibbonControl _ribbonControl;
        public UIControlledApplication ControlledApplication { get; }
        //public bool IsVisible;

        #region Input for creating ribbon
        public CustomRibbon(UIControlledApplication uiControlApp) : this()
        {
            ControlledApplication = uiControlApp;
        }
        private CustomRibbon(UIApplication uiapp) : this()
        {
            _uiapp = uiapp;
        }

        private CustomRibbon()
        {
            _ribbonControl = UIFramework.RevitRibbonControl.RibbonControl;
            if (_ribbonControl is null)
                throw new NotSupportedException("Could not initialize Revit ribbon control");
        }

        public static CustomRibbon GetApplicationRibbon(UIControlledApplication uiControlApp)
        {
            return new CustomRibbon(uiControlApp);
        }
        #endregion

        #region Input for creating tab
        public CustomTab Tab(string tabTitle)
        {
            var ribbonTab = _ribbonControl.FindTabByTitle(tabTitle);
            if (ribbonTab != null)
                return new CustomTab(this, ribbonTab);
            ribbonTab = CreateRibbonTab(tabTitle);
            return Tab(ribbonTab);
        }
        private CustomTab Tab(RibbonTab ribbonTab)
        {
            return new CustomTab(this, ribbonTab);
        }
        public CustomTab Tab(Autodesk.Revit.UI.Tab systemTab)
        {
            return new CustomTab(this, systemTab);
        }
        #endregion //Input for craeting tab
        
        //Create ribbon tab by given name
        private RibbonTab CreateRibbonTab(string tabTitle)
        {
            if (ControlledApplication != null)
                ControlledApplication.CreateRibbonTab(tabTitle);
            else
                _uiapp.CreateRibbonTab(tabTitle);

            return _ribbonControl.FindTabByTitle(tabTitle);
        }

        #region get the panels
        //Get a tab to modify(to add, modify item in this tab)
        public CustomTab GetModifyTab()
        {
            return Tab(_ribbonControl.FindTab(ContextualTabHelper.IdModifyTab));
        }

        public bool HasTab(string tabTitle)
        {
            return _ribbonControl.FindTabByTitle(tabTitle) != null;
        }


        public IEnumerable<Autodesk.Revit.UI.RibbonPanel> GetRibbonPanels(string tabName)
        {
            return ControlledApplication != null
                       ? ControlledApplication.GetRibbonPanels(tabName)
                       : _uiapp.GetRibbonPanels(tabName);
        }

        public IEnumerable<Autodesk.Revit.UI.RibbonPanel> GetRibbonPanels(Autodesk.Revit.UI.Tab systemTab)
        {
            return ControlledApplication != null
                       ? ControlledApplication.GetRibbonPanels(systemTab)
                       : _uiapp.GetRibbonPanels(systemTab);
        }

        //Create a panel in the custom tab given by name
        public Autodesk.Revit.UI.RibbonPanel CreateRibbonPanel(string tabName, string panelName)
        {
            return ControlledApplication != null
                       ? ControlledApplication.CreateRibbonPanel(tabName, panelName)
                       : _uiapp.CreateRibbonPanel(tabName, panelName);
        }

        //Create a panel in the given system tab
        public Autodesk.Revit.UI.RibbonPanel CreateRibbonPanel(Autodesk.Revit.UI.Tab systemTab, string panelName)
        {
            return ControlledApplication != null
                       ? ControlledApplication.CreateRibbonPanel(systemTab, panelName)
                       : _uiapp.CreateRibbonPanel(systemTab, panelName);
        }

        #endregion


    }
}
