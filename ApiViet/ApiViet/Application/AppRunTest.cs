#region Namespaces
using System;
using System.Collections.Generic;
using ApiViet.Ribbon;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiViet.Helpers;
using ApiViet.Properties;

#endregion

namespace ApiViet
{
    class AppRunTest : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication uiApp)
        {
            CustomRibbon ribbon = new CustomRibbon(uiApp);
            //var myTab = ribbon.Tab("JOTools");
            var ExButton = new ExistingButton();
            var exBtn1 = ExButton.AdwinButton("Architecture", "Build", "Mullion",true);
            var exBtn2 = ExButton.AdwinButton("JOTools", "Copie Proprietes", "Options");
            //var existedTab = myTab.Panel("Compare");
            //var btn = existedTab.CreateButton<HelloWorld>("btnNew", "New\nButton",
            //    b => b.SetLargeImage(Resources.arrow_carribean_blue_32x32));
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }
    }
}
