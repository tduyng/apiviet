#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using APIViet.Ribbon.Helpers;
#endregion

namespace APIViet.Ribbon
{
    public class CustomTextBox
    {
        public CustomTextBox() { }

        //PushButton

        public static TextBox NewTextBox(RibbonPanel panel, string txtName, string smallImageName = "", string txtTooltip = "", string txtLongdescription = "", string promptText = "", bool isShowImageButton = true)
        {
            try
            {
                TextBoxData txtData = new TextBoxData(txtName);
                txtData.Image = IconRibbon.GetEmbededImageFromSource(smallImageName); //Using image 16x16
                txtData.Name = txtName;
                if (string.IsNullOrWhiteSpace(txtTooltip))
                {
                    txtData.ToolTip = "Enter text here";
                }
                if (string.IsNullOrWhiteSpace(txtLongdescription))
                {
                    txtData.LongDescription = "<p>This is APIViet.</p><p>CustomRibbon</p>";
                }

                txtData.ToolTipImage = IconRibbon.GetEmbededImageFromSource(smallImageName);

                TextBox txtBox = panel.AddItem(txtData) as TextBox;
                if (string.IsNullOrWhiteSpace(promptText))
                {
                    txtBox.PromptText = "Enter a comment";
                }

                txtBox.ShowImageAsButton = isShowImageButton;

                txtBox.EnterPressed += new EventHandler<Autodesk.Revit.UI.Events.TextBoxEnterPressedEventArgs>(txtBox_EnterPressed);
                txtBox.Width = 180;

                return txtBox;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        private static void txtBox_EnterPressed(object sender, Autodesk.Revit.UI.Events.TextBoxEnterPressedEventArgs e)
        {
            // Cast sender to TextBox to retrieve text value
            TextBox textBox = sender as TextBox;
            TaskDialog.Show("TextBox Input", "This is what you typed in: " + textBox.Value.ToString());
        }

    }
}
