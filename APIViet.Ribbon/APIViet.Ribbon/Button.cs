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
    public class Button
    {
        public Button() {}
       
        //PushButton
        
        public void AddButton(RibbonPanel panel, string btnName, string assemblyName, string className, string imageName, string btnTooltip)
        {
            PushButtonData btnData = new PushButtonData("btn" + btnName, btnName + Environment.NewLine, assemblyName, className);

            btnData.ToolTip = btnTooltip;
            ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "http://www.autodesk.com");
            btnData.SetContextualHelp(help);
            btnData.LargeImage = Image.ImageSource(imageName) ;
            //Add buton to panel
            PushButton btn1 = panel.AddItem(btnData) as PushButton;

        }


    }
}
