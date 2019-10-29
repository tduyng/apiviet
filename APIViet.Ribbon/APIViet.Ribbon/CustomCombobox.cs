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
    public class CustomComboBox : CustomComboBoxMember
    {
        private readonly IList<CustomComboBoxMember> _cboMembers = new List<CustomComboBoxMember>();

        public CustomComboBox(string name) : base(name, "", "")
        {
        }
        internal new ComboBoxData GetButtonData()
        {
            ComboBoxData cboData = new ComboBoxData(_name);
            if (_smallImage != null)
            {
                cboData.Image = _smallImage;
            }
            if (_toolTipsImage != null)
            {
                cboData.ToolTipImage = _toolTipsImage;
            }
            if (!string.IsNullOrWhiteSpace(_toolTips))
            {
                cboData.ToolTip = _toolTips;
            }
            if (!string.IsNullOrWhiteSpace(_description))
            {
                cboData.LongDescription = _description;
            }
            if (_contextualHelp != null)
            {
                cboData.SetContextualHelp(_contextualHelp);
            }
            return cboData;
        }
        public CustomComboBox CreateComboBoxMember(string name, string text, string groupName, Action<CustomComboBoxMember> action)
        {
            var cboMember = new CustomComboBoxMember(name, text, groupName);
            action?.Invoke(cboMember);
            return this;
        }
        public CustomComboBox CreateComboBoxMember(string name,string text, string groupName)
        {
            return CreateComboBoxMember(name, text,groupName,null);
        }
        public IList<CustomComboBoxMember> CboMembers => _cboMembers;

        public int ItemsCount => CboMembers.Count;

        private static void comboBox_CurrentChanged(object sender, Autodesk.Revit.UI.Events.ComboBoxCurrentChangedEventArgs e)
        {
            // Cast sender as TextBox to retrieve text value
            ComboBox combodata = sender as ComboBox;
            ComboBoxMember member = combodata.Current;
            TaskDialog.Show("Combobox Selection", "Your new selection: " + member.ItemText);
        }

    }
}
