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
    public class CustomComboBoxMember
    {
        public CustomComboBoxMember() {}
        public static ComboBoxMember NewComboBoxMember(RibbonPanel panel, ComboBox comboBox, string cboMemberDataName, string imageComboBoxMemberDataName, string cboMemberDataGroupName)
        {
            try
            {
                ComboBoxMemberData cboMemberData  = new ComboBoxMemberData("cbo" + cboMemberDataName, cboMemberDataName);
                cboMemberData.GroupName = cboMemberDataGroupName;
                cboMemberData.Image = Image.ImageSource(imageComboBoxMemberDataName);

                ComboBoxMember  cboMember = comboBox.AddItem(cboMemberData);
                return cboMember;
            }
            catch { return null; }
            
        }
    }
}
