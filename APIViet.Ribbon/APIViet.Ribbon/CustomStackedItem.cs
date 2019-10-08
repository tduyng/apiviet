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
    public class CustomStackedItem : CustomRibbonItem
    {
        private readonly CustomPanel _panel;
        private readonly IList<CustomPushButton> _items;


        public CustomStackedItem (CustomPanel panel)
        {
            _panel = panel;
            _items = new List<CustomPushButton>(3);
           
        }

        public CustomStackedItem CreateButton<TExternalCommandClass>(string name,
                                  string text)
            where TExternalCommandClass : class, IExternalCommand
        {
            var commandClassType = typeof(TExternalCommandClass);

            return CreateButton(name, text, commandClassType, null);
        }

        public CustomStackedItem CreateButton<TExternalCommandClass>(string name,
                                  string text,
                                  Action<CustomPushButton> action)
            where TExternalCommandClass : class, IExternalCommand
        {
            var commandClassType = typeof(TExternalCommandClass);

            return CreateButton(name, text, commandClassType, action);
        }

        public CustomStackedItem CreateButton(string name,
                                  string text,
                                  Type externalCommandType)
        {
            return CreateButton(name, text, externalCommandType, null);
        }

        public CustomStackedItem CreateButton(string name,
                                   string text,
                                   Type externalCommandType,
                                   Action<CustomPushButton> action)
        {
            if (Items.Count == 3)
            {
                throw new InvalidOperationException("You cannot create more than three items in the StackedItem");
            }

            var button = new CustomPushButton(name,
                              text,
                              externalCommandType);
            if (action != null)
            {
                action.Invoke(button);
            }

            Items.Add(button);

            return this;
        }
        public CustomStackedItem CreateTextBox(string name, Action<CustomTextBox> action)
        {

            if (Items.Count == 3)
            {
                throw new InvalidOperationException("You cannot create more than three items in the StackedItem");
            }

            var txt = new CustomTextBox(name);
            if (action != null)
            {
                action.Invoke(txt);
            }

            Items.Add(txt);
            return this;
        }

        public int ItemsCount
        {
            get { return Items.Count; }
        }

        public IList<CustomPushButton> Items
        {
            get { return _items; }
        }

    }
}
