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
        public PushButtonData ButtonData() { return null; }
        public PushButtonData ButtonData(string btnName, string assembyName, string className, BitmapImage image, string btnTooltip)
        {
            PushButtonData btnData = new PushButtonData("btn" + btnName, btnName + Environment.NewLine, assembyName, className);

            btnData.ToolTip = btnTooltip;
            ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "http://www.autodesk.com");
            btnData.SetContextualHelp(help);
            IconControl img = new IconControl();
            if (image != null)
            {
                btnData.LargeImage = image;
            }
            return btnData;
        }

        //PushButton
        public void AddButton(RibbonPanel panel)
        {
            ButtonData btnData = new ButtonData() ;
            //Add buton to panel
            PushButton btn1 = panel.AddItem(btnData) as PushButton;

        }


    }
}
