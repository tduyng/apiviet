#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Linq;
#endregion

namespace APIViet.Ribbon
{
    /// <summary>
    /// Create a ribbon tab
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class StartProject : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication uiApp)
        {
            CustomUIRibbon customRibbon = new CustomUIRibbon();
            customRibbon.CreateCustomTabAndPanel(uiApp);
            customRibbon.AddControlsInPanel_1(customRibbon.PanelByName(uiApp, customRibbon.TabName, customRibbon.PanelName1));
            customRibbon.AddControlsInPanel_2(customRibbon.PanelByName(uiApp, customRibbon.TabName, customRibbon.PanelName2));
            customRibbon.AddControlsInPanel_3(customRibbon.PanelByName(uiApp, customRibbon.TabName, customRibbon.PanelName3));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication uiApp)
        {
            return Result.Succeeded;
        }

    }



 }
