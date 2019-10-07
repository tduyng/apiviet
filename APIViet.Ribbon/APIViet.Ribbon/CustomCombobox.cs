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
    public class CustomComboBox : CustomRibbonItem
    {


        //public CustomComboBox() {}
        //public static ComboBox NewComboBox(RibbonPanel panel, string cboDataName,string cboName, string cboTooltip = "", string cboLongDescription = "")
        //{
        //    try
        //    {
        //        ComboBoxData cboData = new ComboBoxData(cboDataName);
        //        ComboBox comboBox = panel.AddItem(cboData) as ComboBox;
        //        if (string.IsNullOrWhiteSpace(cboTooltip))
        //        {
        //            comboBox.ToolTip = "Select an option";
        //        }
        //        if (string.IsNullOrWhiteSpace(cboLongDescription))
        //        {
        //            comboBox.LongDescription = "Select a command you want to run";
        //        }
        //        comboBox.CurrentChanged += new EventHandler<Autodesk.Revit.UI.Events.ComboBoxCurrentChangedEventArgs>(comboBox_CurrentChanged);
        //        return comboBox;
        //    }
        //    catch(Exception)
        //    {
        //        return null;
        //        throw;
        //    }
            
        //}
        //private static void comboBox_CurrentChanged(object sender, Autodesk.Revit.UI.Events.ComboBoxCurrentChangedEventArgs e)
        //{
        //    // Cast sender as TextBox to retrieve text value
        //    ComboBox combodata = sender as ComboBox;
        //    ComboBoxMember member = combodata.Current;
        //    TaskDialog.Show("Combobox Selection", "Your new selection: " + member.ItemText);
        //}


    }
}
