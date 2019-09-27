#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace APIViet.Ribbon
{
    public class CustomTab
    {
        private readonly CustomRibbon _ribbon;
        private readonly Autodesk.Revit.UI.Tab? _systemTab;
        private readonly string _name;
        //private readonly RibbonTab _tab;

        public CustomTab(CustomRibbon ribbon, string name)
        {
            _ribbon = ribbon;
            _name = name;
        }

        public CustomTab(CustomRibbon ribbon, Autodesk.Revit.UI.Tab systemTab)
        {
            _ribbon = ribbon;
            _systemTab = systemTab;
        }

        internal CustomRibbon Ribbon
        {
            get { return _ribbon; }
        }

        //public string Title { get { return _tab.Title; }}

        public CustomPanel Panel(string panelTitle)
        {
            //foreach (var panel in _tab.Panels)
            //{
            //    if (panel.Source.Title.Equals(panelTitle))
            //    {

            //        return new Panel(this, panel);
            //    }
            //}


            List<RibbonPanel> panels;
            if (_systemTab == null)
            {
                panels = _ribbon.Application.GetRibbonPanels(_name);
            }
            else
            {
                panels = _ribbon.Application.GetRibbonPanels(_systemTab.Value);
            }
            foreach (var panel in panels)
            {
                if (panel.Name.Equals(panelTitle))
                {
                    panel.AddSeparator();
                    return new CustomPanel(this, panel);
                }
            }

            RibbonPanel ribbonPanel;
            if (_systemTab == null)
                ribbonPanel = _ribbon.Application.CreateRibbonPanel(_name, panelTitle);
            else
                ribbonPanel = _ribbon.Application.CreateRibbonPanel(_systemTab.Value, panelTitle);




            return new CustomPanel(this, ribbonPanel);

        }
}
