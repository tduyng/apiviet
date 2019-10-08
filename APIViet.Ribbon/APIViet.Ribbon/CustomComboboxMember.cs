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
    public class CustomComboBoxMember: CustomPushButton
    {
        public CustomComboBoxMember(string name, string text): base(name, text,null)
        {

        }
        //public CustomComboBoxMember() { }
        //public static ComboBoxMember NewComboBoxMember(RibbonPanel panel, ComboBox comboBox, string cboMemberDataName, string cboMemberDataText, string cboMemberDataGroupName, string normalImageComboBoxMemberDataName = "")
        //{
        //    try
        //    {
        //        ComboBoxMemberData cboMemberData = new ComboBoxMemberData(cboMemberDataName, cboMemberDataText);
        //        cboMemberData.GroupName = cboMemberDataGroupName;
        //        cboMemberData.Image = IconRibbon.GetEmbededImageFromSource(normalImageComboBoxMemberDataName); //Using image 16x16

        //        ComboBoxMember cboMember = comboBox.AddItem(cboMemberData);
        //        return cboMember;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //        throw;
        //    }

        //}

    }
}
