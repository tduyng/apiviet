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
    public class CustomComboBoxMember: CustomPushButton
    {
        protected readonly string _groupName;
        public CustomComboBoxMember(string name, string text, string groupName): base(name,text, null)
        {
            _groupName = groupName;
        }
        internal new ComboBoxMemberData GetButtonData()
        {
            ComboBoxMemberData cboMemberData = new ComboBoxMemberData(_name, _text) {GroupName = _groupName};
            if (_smallImage != null)
            {
                cboMemberData.Image = _smallImage;
            }
            if (_toolTipsImage != null)
            {
                cboMemberData.ToolTipImage = _toolTipsImage;
            }
            if (!string.IsNullOrWhiteSpace(_toolTips))
            {
                cboMemberData.ToolTip = _toolTips;
            }
            if (!string.IsNullOrWhiteSpace(_description))
            {
                cboMemberData.LongDescription = _description;
            }
            if (_contextualHelp != null)
            {
                cboMemberData.SetContextualHelp(_contextualHelp);
            }
            return cboMemberData;
        }

    }
}
