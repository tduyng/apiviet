#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class CustomTab
    {
        private readonly CustomRibbon _ribbon;
        private readonly Autodesk.Revit.UI.Tab? _systemTab;
        private readonly Autodesk.Windows.RibbonTab _ribbonTab;

        public CustomRibbon Ribbon => _ribbon;

        public CustomTab(CustomRibbon ribbon)
        {
            this._ribbon = ribbon;
        }
        public CustomTab(CustomRibbon ribbon, Autodesk.Windows.RibbonTab ribbonTab)
            : this(ribbon)
        {
            this._ribbonTab = ribbonTab;
        }

        public CustomTab(CustomRibbon ribbon, Autodesk.Revit.UI.Tab systemTab)
            : this(ribbon)
        {
            this._systemTab = systemTab;
        }

        public bool Visible
        {
            get
            {
                if (_ribbonTab is null)
                    return true;
                return _ribbonTab.IsVisible;
            }
            set
            {
                if (_ribbonTab != null)
                    _ribbonTab.IsVisible = value;
            }
        }

        public string Title
        {
            get
            {
                if (_systemTab.HasValue)
                {
                    //Suppporting get title of AddIns Tab and Analyze tab
                    switch (_systemTab.Value)
                    {
                        case Autodesk.Revit.UI.Tab.AddIns:
                            return "Add-Ins";

                        case Autodesk.Revit.UI.Tab.Analyze:
                            return "Analyze";

                        default:
                            throw new NotSupportedException($"tab {_systemTab.Value} is not supported now");
                    }
                }
                return _ribbonTab.Title;
            }
        }
    
        public CustomPanel Panel(string panelTitle, bool addSeparatorToExistingPanel = true)
        {
            //Search if panel existed in this tab
            var panels = _systemTab is null
                ? _ribbon.GetRibbonPanels(_ribbonTab.Id) //if input is not system tab, get the custom panel
                : _ribbon.GetRibbonPanels(_systemTab.Value);
            ;

            foreach (var panel in panels.Where(panel => panel.Name.Equals(panelTitle)))
            {
                if(addSeparatorToExistingPanel)
                    panel.AddSeparator();
                return new CustomPanel(this, panel);
            }


            //If not exit, create new panel
            Autodesk.Revit.UI.RibbonPanel ribbonPanel;
            ribbonPanel = _systemTab is null
                ? _ribbon.CreateRibbonPanel(_ribbonTab.Name ?? _ribbonTab.Title, panelTitle)
                : _ribbon.CreateRibbonPanel(_systemTab.Value, panelTitle);
            ;
            return new CustomPanel(this, ribbonPanel);
        }
    }
}
