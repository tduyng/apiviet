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
    public class CustomPulldownButton
    {
        public CustomPulldownButton() {}
        public static PushButton NewButton(RibbonPanel panel, PulldownButton pulldownBtn, string btnName, string btnText,string assemblyName, string className, string largeImageName = "", string btnTooltip = "")
        {
            try
            {
                PushButtonData btnData = CustomPushButtonData.GetButtonData(btnName, btnText, assemblyName, className, largeImageName, btnTooltip);
                PushButton btn = pulldownBtn.AddPushButton(btnData);
                return btn;
            }
            catch(Exception)
            {
                return null;
                throw;
            }
            
        }
    }
}
