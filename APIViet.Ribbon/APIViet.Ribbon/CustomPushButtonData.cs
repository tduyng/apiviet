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
    public abstract class CustomPushButtonData
    {
        protected CustomPushButtonData() { }

        //PushButton

        public static PushButtonData GetButtonData(string btnName, string assembyName, string className, string imageName, string btnTooltip)
        {
            PushButtonData btnData = new PushButtonData("btn" + btnName, btnName + Environment.NewLine, assembyName, className);

            btnData.ToolTip = btnTooltip;
            ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com");
            btnData.SetContextualHelp(help);
            btnData.LargeImage = Image.ImageSource(imageName);
            return btnData;
        }


    }
}
