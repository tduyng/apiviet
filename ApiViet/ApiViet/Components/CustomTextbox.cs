#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiViet.Helpers;
using System.Windows.Media;
using System.Drawing;
#endregion

namespace ApiViet.Ribbon
{
    public class CustomTextBox : CustomPushButton
    {

        public CustomTextBox(string name): base (name,"",null)
        {
        }

        public override RibbonItemData GetItemData()
        {
            TextBoxData tbxData = new TextBoxData(_name);
            if (string.IsNullOrWhiteSpace(_toolTips))
            {
                tbxData.ToolTip = _toolTips;
            }
            if(string.IsNullOrWhiteSpace(_description))
            {
                tbxData.LongDescription = _description;
            }
            if(_smallImage != null)
            {
                tbxData.Image = _smallImage;
            }
            if(_toolTipsImage != null)
            {
                tbxData.ToolTipImage = _toolTipsImage;
            }
            return tbxData;
        }

        // Events pressed for TextBox 
        private static void txtBox_EnterPressed(object sender, Autodesk.Revit.UI.Events.TextBoxEnterPressedEventArgs e)
        {
            // Cast sender to TextBox to retrieve text value
            TextBox textBox = sender as TextBox;
            TaskDialog.Show("TextBox Input", "This is what you typed in: " + textBox.Value.ToString());
        }


    }
}
