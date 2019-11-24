#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
#endregion

namespace ApiViet.Ribbon
{
    public class CustomComboBox : CustomRibbonItem
    {
        private readonly string _name;
        private readonly List<CustomComboBoxItem> _items = new List<CustomComboBoxItem>();
        private EventHandler<ComboBoxCurrentChangedEventArgs> _currentChangeHandler;

        public CustomComboBox(string name)
        {
            this._name = name;
        }

        public CustomComboBox OnCurrentChange(EventHandler<ComboBoxCurrentChangedEventArgs> handler)
        {
            _currentChangeHandler = handler;
            return this;
        }

        public CustomComboBox AddComboBoxItem(CustomComboBoxItem item)
        {
            _items.Add(item);
            return this;
        }

        public CustomComboBox AddComboBoxItems(IEnumerable<CustomComboBoxItem> comboBoxItems)
        {
            _items.AddRange(comboBoxItems);
            return this;
        }

        public override RibbonItemData GetItemData()
        {
            return new ComboBoxData(_name);
        }
        public override void DoPostProcessing(RibbonItem ribbonItem)
        {
            var combo = ribbonItem as ComboBox;

            var members = _items
                .Select(x => new ComboBoxMemberData(x.Name, x.Text) { Image = x.Image })
                .ToList();

            var comboBoxItems = combo.AddItems(members);

            var defaultItem = _items.FirstOrDefault(x => x.IsDefault);

            if (defaultItem != null)
            {
                var index = _items.IndexOf(defaultItem);

                combo.Current = comboBoxItems[index];
            }

            if (_currentChangeHandler != null)
                combo.CurrentChanged += _currentChangeHandler;
        }
    }
}
