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
    public class CustomPanel : CustomRibbonItem
    {
        private readonly CustomTab _tab;
        private readonly RibbonPanel _panel;

        public CustomPanel(CustomTab tab, RibbonPanel panel)
        {
            _tab = tab;
            _panel = panel;
        }


        internal RibbonPanel Source
        {
            get { return _panel; }
        }

        internal CustomTab Tab
        {
            get { return _tab; }
        }

        /// <summary>
        /// Create new Stacked items at the panel
        /// </summary>
        /// <param name="action">Action where you must add items to the stacked panel</param>
        /// <returns>Panel where stacked items were created</returns>
        public CustomPanel CreateStackedItems(Action<CustomStackedItem> action)
        {
            if (action is null) throw new ArgumentNullException("action");

            CustomStackedItem stackedItem = new CustomStackedItem(this);

            action.Invoke(stackedItem);

            if (stackedItem.ItemsCount < 2 ||
                stackedItem.ItemsCount > 3)
            {
                throw new InvalidOperationException("You must create 2 or three items in the StackedItems");
            }

            var item1 = stackedItem.Buttons[0].GetButtonData();
            var item2 = stackedItem.Buttons[1].GetButtonData();
            if (stackedItem.ItemsCount == 3)
            {
                var item3 =
                    stackedItem.Buttons[2].GetButtonData();
                _panel.AddStackedItems(item1, item2, item3);
            }
            else
            {
                _panel.AddStackedItems(item1, item2);
            }

            return this;
        }

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
            CustomPushButton button = new CustomPushButton(name,
                text,
                externalCommandType);
            if (action != null)
            {
                action.Invoke(button);
            }

            var buttonData = button.GetButtonData();

            _panel.AddItem(buttonData);

            return this;
        }

        public CustomPanel CreatePullDownButton(string name,
                                  string text,
                                  Action<CustomPulldownButton> action)
        {
            CustomPulldownButton button = new CustomPulldownButton(name,
                text);

            if (action != null)
            {
                action.Invoke(button);
            }

            var buttonData = button.GetButtonData();

            var ribbonItem = _panel.AddItem(buttonData) as Autodesk.Revit.UI.PulldownButton;

            button.BuildButtons(ribbonItem);

            button.RibbonItem = ribbonItem;

            return this;
        }

        //--

        /// <summary>
        /// Create separator on the panel
        /// </summary>
        /// <returns></returns>
        public CustomPanel CreateSeparator()
        {
            _panel.AddSeparator();
            return this;
        }

    }
}
