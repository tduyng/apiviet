using System.Net;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using adWin = Autodesk.Windows;

namespace ApiViet.Ribbon
{
    /// <summary>
    /// To continued, it no run now, tested 2019/11/05 12:33:32
    /// </summary>
    public class ExistingButton
    {
        public adWin.RibbonItem AdwinButton(string tabName, string panelName, string btnName, bool isSystemTab = false)
        {
            adWin.RibbonControl adWinRibbon = adWin.ComponentManager.Ribbon;
            adWin.RibbonTab adWinSysTab = null;
            adWin.RibbonPanel adWinSysPanel = null;
            adWin.RibbonTab adWinApiTab = null;
            adWin.RibbonPanel adWinApiPanel = null;
            adWin.RibbonItem adWinApiItem = null;

            //If input tab is system tab
            if (isSystemTab)
            {
                foreach (adWin.RibbonTab ribbonTab in adWinRibbon.Tabs)
                {
                    if (ribbonTab.Id != tabName) continue;
                    adWinSysTab = ribbonTab;
                    break;
                }
                if (adWinSysTab != null)
                    foreach (adWin.RibbonPanel ribbonPanel in adWinApiTab.Panels)
                    {
                        if (ribbonPanel.Source.Id != tabName) continue;
                        adWinSysPanel = ribbonPanel;
                        break; ;
                    }

                return null;
            }


            //If input tab is not a system tab
            foreach (adWin.RibbonTab ribbonTab in adWinRibbon.Tabs)
            {
                if (!ribbonTab.Title.Equals(tabName)) continue;
                adWinApiTab = ribbonTab;
                adWinApiTab.IsVisible = false;
                break;
            }

            // Problem: Autodesk.Windows.RibbonTab.Panels = {0}  ???
            // I don't understand here
            if (adWinApiTab != null)
                foreach (adWin.RibbonPanel ribbonPanel in adWinApiTab.Panels)
                {
                    // Look for our API panel.              
                    // The ConvertToPushButton.Id property of an API created 
                    // ribbon panel has the following format: 
                    // CustomCtrl_%[TabName]%[PanelName]
                    if (ribbonPanel.Source.Id != "CustomCtrl_%" + tabName + "%" + panelName) continue;
                    adWinApiPanel = ribbonPanel;
                    break; ;
                }
            if (adWinApiPanel != null)
                foreach (adWin.RibbonItem ribbonItem
                    in adWinApiPanel.Source.Items)
                {
                    // Look for our command button
                    // The Id property of an API created ribbon 
                    // item has the following format: 
                    // CustomCtrl_%CustomCtrl_%[TabName]%[PanelName]%[ItemName]

                    //if(ribbonItem.AutomationName 
                    //  == ApiButtonText) // alternative method

                    if (ribbonItem.Id != "CustomCtrl_%CustomCtrl_%"
                        + tabName + "%" + panelName
                        + "%" + btnName) continue;
                    adWinApiItem = ribbonItem;
                    break;
                }

            if (adWinApiItem != null)
            {
                adWinApiItem.ToolTip = "This button is found by api.";
                TaskDialog.Show("Existing Button", $"Button {btnName} founded");
                // Do something

                return adWinApiItem;
            }

            TaskDialog.Show("Existing Button", $"Button {btnName} is not founded");
            return null;
        }
    }
}
