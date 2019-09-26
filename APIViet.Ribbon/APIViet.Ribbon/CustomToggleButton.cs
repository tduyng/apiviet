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
        public static ToggleButton NewToggleButton(RibbonPanel panel,RadioButtonGroup rdoBtnGroup, string togBtnName,string togBtnText, string assemblyName, string className, string normalImageName ="", string btnTooltip = "")
        {
            try
            {
                ToggleButtonData togBtnData =new ToggleButtonData(togBtnName, togBtnText, assemblyName, className);
                togBtnData.LargeImage = Image.ImageSource(normalImageName); //Using image 16x16
                togBtnData.ToolTip = btnTooltip;
                ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com");
                togBtnData.SetContextualHelp(help);

                //Add toggle button in the radio button group
                ToggleButton togBtn =  rdoBtnGroup.AddItem(togBtnData);  
                return togBtn;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }
    }
}
