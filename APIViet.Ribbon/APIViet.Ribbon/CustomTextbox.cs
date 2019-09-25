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
    public class CustomTextBox
    {
        public CustomTextBox() {}
       
        //PushButton
        
        public static TextBox NewTextBox(RibbonPanel panel, string txtName, string imageName, string imageTooltip)
        {
            try
            {
                TextBoxData txtData = new TextBoxData(txtName);
                txtData.Image = Image.ImageSource(imageName);
                txtData.Name = txtName;
                txtData.ToolTip = "Enter text here";
                txtData.LongDescription = "<p>This is APIViet.</p><p>Ribbon Lab</p>";
                txtData.ToolTipImage = Image.ImageSource(imageName);
                TextBox txtBox = panel.AddItem(txtData) as TextBox;
                txtBox.PromptText = "Enter a comment";
                txtBox.ShowImageAsButton = true;

                txtBox.EnterPressed += new EventHandler<Autodesk.Revit.UI.Events.TextBoxEnterPressedEventArgs>(txtBox_EnterPressed);
                txtBox.Width = 180;

                return txtBox;
            }
            catch { return null; }
        }
        private static void txtBox_EnterPressed(object sender, Autodesk.Revit.UI.Events.TextBoxEnterPressedEventArgs e)
        {
            // Cast sender to TextBox to retrieve text value
            TextBox textBox = sender as TextBox;
            TaskDialog.Show("TextBox Input", "This is what you typed in: " + textBox.Value.ToString());
        }

    }
}
