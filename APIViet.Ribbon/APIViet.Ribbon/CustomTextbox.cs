#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using APIViet.Ribbon.Helpers;
using System.Windows.Media;
using System.Drawing;
#endregion

namespace APIViet.Ribbon
{
    public class CustomTextBox : CustomPushButton
    {

        public CustomTextBox(string name): base (name,"",null)
        {
        }


        internal new TextBoxData GetButtonData()
        {
            TextBoxData txtData = new TextBoxData(_name);
            if (string.IsNullOrWhiteSpace(_toolTips))
            {
                txtData.ToolTip = _toolTips;
            }
            if(string.IsNullOrWhiteSpace(_description))
            {
                txtData.LongDescription = _description;
            }
            if(_smallImage != null)
            {
                txtData.Image = _smallImage;
            }
            if(_toolTipsImage != null)
            {
                txtData.ToolTipImage = _toolTipsImage;
            }

            return txtData;
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
