#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiViet.Helpers;
#endregion

namespace ApiViet.Ribbon
{
    //Split button
    public class CustomToggleButton : CustomPushButton
    {

        public CustomToggleButton(string name, string text,
                  Type externalCommandType) : base(name, text, externalCommandType) { }

        public override RibbonItemData GetItemData()
        {
            ToggleButtonData data = new ToggleButtonData(_name,_text,_assemblyLocation,_className);
            if (string.IsNullOrWhiteSpace(_toolTips))
            {
                data.ToolTip = _toolTips;
            }
            if (string.IsNullOrWhiteSpace(_description))
            {
                data.LongDescription = _description;
            }
            if (_smallImage != null)
            {
                data.Image = _smallImage;
            }
            if (_toolTipsImage != null)
            {
                data.ToolTipImage = _toolTipsImage;
            }
            return data;
        }
    }

}
