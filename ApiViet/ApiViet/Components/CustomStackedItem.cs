#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace ApiViet.Ribbon
{
    public class CustomStackedItem : CustomRibbonItem
    {
        private readonly CustomPanel _panel;

        
        public IList<CustomRibbonItem> Items { get; }
        public int ItemsCount => Items.Count;


        //Given a input panel
        public CustomStackedItem(CustomPanel panel)
        {
            this._panel = panel;
            Items = new List<CustomRibbonItem>();
        }


        #region Create the buttons for StackedItem
        public CustomStackedItem CreateButton<TExternalCommandClass>(string name,string text)
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

        public CustomStackedItem CreateButton<TExternalCommandClass>(string text, Action<CustomPushButton> action)
           where TExternalCommandClass : class, IExternalCommand
        {
            string name = typeof(TExternalCommandClass).ToString();
            return CreateButton<TExternalCommandClass>(name, text, action);
        }
        public CustomStackedItem CreateButton<TExternalCommandClass>(string text)
            where TExternalCommandClass : class, IExternalCommand
        {
            return CreateButton<TExternalCommandClass>(text, button => { });
        }
        public CustomStackedItem CreateButton(string name, string text, Type externalCommandType)
        {
            return CreateButton(name, text, externalCommandType, null);
        }

        public CustomStackedItem CreateButton(string name,
                                   string text,
                                   Type externalCommandType,
                                   Action<CustomPushButton> action)
        {
            var button = new CustomPushButton(name,
                              text,
                              externalCommandType);
            action?.Invoke(button);
            Items.Add(button);
            return this;
        }
        #endregion // Create the buttons for the stackeditem

        #region Create textbox
        public CustomStackedItem CreateTextBox(string name, Action<CustomTextBox> action)
        {
            var tbx = new CustomTextBox(name);
            action?.Invoke(tbx);
            Items.Add(tbx);
            return this;
        }

        #endregion //Create textbox

        #region Create the combobox
        public CustomStackedItem CreateComboBox(string name, Action<CustomComboBox> action)
        {
            var comboBox = new CustomComboBox(name);
            action?.Invoke(comboBox);
            Items.Add(comboBox);
            return this;
        }
        #endregion //Create the combobox

        #region Create SplitButton
        public CustomStackedItem CreatePullDownButton(string name,string text, Action<CustomPulldownButton> action)
        {
            var pdb = new CustomPulldownButton(name, text);
            action?.Invoke(pdb);
            Items.Add(pdb);
            return this;
        }
        #endregion

        #region Create SplitButton
        public CustomStackedItem CreateSplitButton(CustomPanel panel, string name, string text, Action<CustomSplitButton> action)
        {
            var spl = new CustomSplitButton(panel, name,text);
            action?.Invoke(spl);
            Items.Add(spl);
            return this;
        }
        #endregion


        public int GetDefaultButtonIndex()
        {
            return Items
                .Select((x, i) => new
                {
                    Index = i,
                    IsDefault = (x as CustomPushButton)?.IsDefault ?? false
                })
                .FirstOrDefault(x => x.IsDefault)?.Index ?? Items.Count - 1;
        }


        public override RibbonItemData GetItemData()
        {
            return null;
        }

    }
}
