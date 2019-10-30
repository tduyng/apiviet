#region Namespaces
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
#endregion

namespace ApiViet.Ribbon
{
    public class CustomPanel : CustomRibbonItem
    {
        private readonly CustomTab _tab;
        private readonly Autodesk.Revit.UI.RibbonPanel _panel;

        public CustomPanel(CustomTab tab, Autodesk.Revit.UI.RibbonPanel panel)
        {
            _tab = tab;
            _panel = panel;
        }

        internal Autodesk.Revit.UI.RibbonPanel Source => _panel;
        internal CustomTab Tab => _tab;


        /// <summary>
        /// Create push button on the panel
        /// </summary>
        /// <param name="name">Internal name of the button</param>
        /// <param name="text">Text user will see</param>
        /// <returns>Panel where button were created</returns>
        public CustomPanel CreateButton<TExternalCommandClass>(string name,
                                  string text) where TExternalCommandClass : class, IExternalCommand
        {
            return CreateButton<TExternalCommandClass>(name, text, null);
        }

        /// <summary>
        /// Create push button on the panel
        /// </summary>
        /// <param name="name">Internal name of the button</param>
        /// <param name="text">Text user will see</param>
        /// <param name="action">Additional action with whe button</param>
        /// <returns>Panel where button were created</returns>
        public CustomPanel CreateButton<TExternalCommandClass>(string name,
                                  string text,
                                  Action<CustomPushButton> action)
            where TExternalCommandClass : class, IExternalCommand
        {
            var commandClassType = typeof(TExternalCommandClass);

            return CreateButton(name, text, commandClassType, action);
        }

        /// <summary>
        /// Create push button on the panel
        /// </summary>
        /// <param name="name">Internal name of the button</param>
        /// <param name="text">Text user will see</param>
        /// <param name="externalCommandType">Class which implements IExternalCommand interface. 
        /// This command will be execute when user push the button</param>
        /// <returns>Panel where button were created</returns>
        public CustomPanel CreateButton(string name,
                                  string text,
                                  Type externalCommandType)
        {
            return CreateButton(name, text, externalCommandType, null);
        }

        /// <summary>
        /// Create push button on the panel
        /// </summary>
        /// <param name="name">Internal name of the button</param>
        /// <param name="text">Text user will see</param>
        /// <param name="externalCommandType">Class which implements IExternalCommand interface. 
        /// This command will be execute when user push the button</param>
        /// <param name="action">Additional action with whe button</param>
        /// <returns>Panel where button were created</returns>
        public CustomPanel CreateButton(string name,
                                  string text,
                                  Type externalCommandType,
                                  Action<CustomPushButton> action)
        {
            var button = new CustomPushButton(name,
                text,
                externalCommandType);
            action?.Invoke(button);
            var buttonData = button.GetButtonData();
            try { _panel.AddItem(buttonData); }
            catch { }
            return this;
        }

        /// <summary>
        /// Create new Stacked items at the panel
        /// </summary>
        /// <param name="action">Action where you must add items to the stacked panel</param>
        /// <returns>Panel where stacked items were created</returns>
        public CustomPanel CreateStackedItems(Action<CustomStackedItem> action)
        {

            if (action is null) throw new ArgumentNullException(nameof(action));

            var stackedItem = new CustomStackedItem(this);

            action.Invoke(stackedItem);

            if (stackedItem.ItemsCount < 2 ||
                stackedItem.ItemsCount > 3)
            {
                throw new InvalidOperationException("You must create 2 or three items in the StackedItems");
            }

            var item1 = stackedItem.Items[0].GetButtonData();
            var item2 = stackedItem.Items[1].GetButtonData();
            if (stackedItem.ItemsCount == 3)
            {
                var item3 =
                    stackedItem.Items[2].GetButtonData();
                try { _panel.AddStackedItems(item1, item2, item3); }
                catch { }
            }
            else
            {
                try { _panel.AddStackedItems(item1, item2); }
                catch { }
            }

            return this;
        }

        public CustomPanel CreatePullDownButton(string name,
                                  string text,
                                  Action<CustomPulldownButton> action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            var pulldownButton = new CustomPulldownButton(name,
                text);
            action?.Invoke(pulldownButton);
            var pulldownButtonData = pulldownButton.GetButtonData();
            var ribbonItem = _panel.AddItem(pulldownButtonData) as PulldownButton;
            pulldownButton.BuildButtons(ribbonItem);
            pulldownButton.RibbonItem = ribbonItem;
            return this;
        }
        public CustomPanel CreateSplitButton(string name, string text,Action<CustomSplitButton> action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            var splitButton = new CustomSplitButton(name, text);
            action?.Invoke(splitButton);
            var splitButtonData = splitButton.GetButtonData();
            var ribbonItem = _panel.AddItem(splitButtonData) as SplitButton;
            splitButton.BuildButtons(ribbonItem);
            splitButton.RibbonItem = ribbonItem;
            return this;
        }
        public CustomPanel CreateTextBox(string name, Action<CustomTextBox> action) 
        {
            var txt = new CustomTextBox(name);
            action?.Invoke(txt);
            var txtData = txt.GetButtonData();
             _panel.AddItem(txtData);
            return this;
        }

        public CustomPanel CreateSeparator()
        {
            _panel.AddSeparator();
            return this;
        }

    }
}
