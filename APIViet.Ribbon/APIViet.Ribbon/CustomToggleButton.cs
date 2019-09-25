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
    //Split button
    public class CustomToggleButton
    {
        public CustomToggleButton() {}
        public static ToggleButton NewToggleButton(RibbonPanel panel,RadioButtonGroup rdoBtnGroup, string togBtnName, string assemblyName, string className, string imageName, string btnTooltip)
        {
            try
            {
                ToggleButtonData togBtnData =new ToggleButtonData("tog" + togBtnName, togBtnName, assemblyName, className);
                togBtnData.Image = Image.BmpImageSource(imageName);
                togBtnData.ToolTip = btnTooltip;
                ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com");
                togBtnData.SetContextualHelp(help);

                //Add toggle button in the radio button group
                ToggleButton togBtn =  rdoBtnGroup.AddItem(togBtnData);  
                return togBtn;
            }
            catch { return null; }
            
        }
    }
}
