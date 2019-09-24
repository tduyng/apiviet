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
    public abstract class ButtonData
    {
        protected ButtonData() { }

        //PushButton

        public static PushButtonData GetButtonData(string btnName, string assembyName, string className, BitmapImage image, string btnTooltip)
        {
            PushButtonData btnData = new PushButtonData("btn" + btnName, btnName + Environment.NewLine, assembyName, className);

            btnData.ToolTip = btnTooltip;
            ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "http://www.autodesk.com");
            btnData.SetContextualHelp(help);
            if (image != null)
            {
                btnData.LargeImage = image;
            }
            //Add buton to panel
            return btnData;

        }


    }
}
