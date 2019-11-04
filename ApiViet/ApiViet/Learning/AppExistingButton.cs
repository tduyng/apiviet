using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using adWin = Autodesk.Windows;

namespace ApiViet.Learning
{
    [Transaction(TransactionMode.Manual)]
    class AppExistingButton : IExternalApplication
    {
        //Information of custom tab
        private readonly string _tabName = "TD";
        private readonly string _panelName = "Learning";
        private readonly string _btnName = "Event";
        //private readonly string _btnText = "Event";
        //private readonly string _tooltipsOn = "Turn On Event";
        //private readonly string _toltipsOff = "Turn Off Event";


        public Result OnStartup(UIControlledApplication application)
        {
            application.ControlledApplication.ApplicationInitialized += OnApplicationInitialized;
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public void OnApplicationInitialized(object sender, ApplicationInitializedEventArgs args)
        {

            adWin.RibbonControl adWinRibbon = adWin.ComponentManager.Ribbon;
            adWin.RibbonTab adWinApiTab = null;
            adWin.RibbonPanel adWinApiPanel = null;
            adWin.RibbonItem adWinApiItem = null;

            foreach (adWin.RibbonTab ribbonTab in adWinRibbon.Tabs)
            {
                if (ribbonTab.Id != _tabName) continue;
                adWinApiTab = ribbonTab;
                foreach (adWin.RibbonPanel ribbonPanel in ribbonTab.Panels)
                {
                    // Look for our API panel.              

                    // The ConvertToPushButton.Id property of an API created 
                    // ribbon panel has the following format: 
                    // CustomCtrl_%[TabName]%[PanelName]

                    if (ribbonPanel.Source.Id != "CustomCtrl_%" + _tabName + "%" + _panelName) continue;
                    adWinApiPanel = ribbonPanel;

                    foreach (adWin.RibbonItem ribbonItem
                        in ribbonPanel.Source.Items)
                    {
                        // Look for our command button
                        // The Id property of an API created ribbon 
                        // item has the following format: 
                        // CustomCtrl_%CustomCtrl_%[TabName]%[PanelName]%[ItemName]

                        //if(ribbonItem.AutomationName 
                        //  == ApiButtonText) // alternative method

                        if (ribbonItem.Id != "CustomCtrl_%CustomCtrl_%"
                            + _tabName + "%" + _panelName
                            + "%" + _btnName) continue;
                        adWinApiItem = ribbonItem;
                    }
                }
            }

            if (adWinApiTab == null || adWinApiPanel == null || adWinApiItem == null) return;
            adWinApiItem.ToolTip = "This button is found by api.";
            //switch ((string) adWinApiItem.ToolTip)
            //{
            //    case "Turn On Event":
            //        adWinApiItem.ToolTip = "Turn Off Event";
            //        return;
            //    case "Turn Off Event":
            //        adWinApiItem.ToolTip = "Turn On Event";
            //        return;
            //}
        }
    }
}
