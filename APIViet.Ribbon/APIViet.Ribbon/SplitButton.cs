#region Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace APIViet.Ribbon
{
    public class SplitButton
    {
        private RibbonPanel ribbonPanel { get; }
        public SplitButton(RibbonPanel  ribbonPanel)
        {
            this.ribbonPanel = ribbonPanel;
        }

        //PushButton
        public void AddSplitButton<T>(params IEnumerable<T>[] buttonDatas)
        {
            foreach (var btnData in buttonDatas )
            {
                var btnDataValid = btnData as RibbonItemData;
                if( btnDataValid != null)
                {
                    ribbonPanel.AddItem(btnDataValid);
                }
                
            }
        }
       
    }
}
