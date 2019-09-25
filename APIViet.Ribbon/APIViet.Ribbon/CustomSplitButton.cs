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
    public class CustomSplitButton
    {
        public CustomSplitButton() {}
        public static PushButton NewButton(RibbonPanel panel, SplitButton splButton, string btnName, string assemblyName, string className, string imageName, string btnTooltip)
        {
            try
            {
                PushButtonData btnData = CustomPushButtonData.GetButtonData(btnName, assemblyName, className, imageName, btnTooltip);
                PushButton btn = splButton.AddPushButton(btnData);
                return btn;
            }
            catch { return null; }
            
        }
    }
}
