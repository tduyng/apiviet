#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using RibbonItem = Autodesk.Revit.UI.RibbonItem;

#endregion

namespace ApiViet.Ribbon
{
    //Create the panel
    public class CustomPanel : CustomRibbonItem
    {
        private readonly CustomTab _tab;
        private readonly Autodesk.Revit.UI.RibbonPanel _panel;
        public PushButton RvtPushButton { get; set; }
        public PulldownButton RvtPulldownButton { get; set; }
        public SplitButton RvtSpliButton { get; set; }
        public RibbonItem RvtStackedItem { get; set; }
        public RibbonItem RvtComboBox { get; set; }
        public RibbonItem RvtTextBox { get; set; }

        public Autodesk.Revit.UI.RibbonPanel RvtPanel => _panel; //Get defaut panel of revit
        public CustomTab Tab => _tab;
        public string Title => _panel.Title;
        public string Name => _panel.Name;

        public CustomPanel(CustomTab tab, Autodesk.Revit.UI.RibbonPanel panel)
        {
            _tab = tab;
            _panel = panel;
        }
        public override bool IsVisible
        {
            get { return RvtPanel.Visible; }
            set { RvtPanel.Visible = value; }
        }

        #region Create the button
        public CustomPanel CreateButton<TExternalCommandClass>(string name,
                                  string text) where TExternalCommandClass : class, IExternalCommand
        {
            return CreateButton<TExternalCommandClass>(name, text, null);
        }


        public CustomPanel CreateButton<TExternalCommandClass>(string name,
                                  string text,
                                  Action<CustomPushButton> action)
            where TExternalCommandClass : class, IExternalCommand
        {
            var commandClassType = typeof(TExternalCommandClass);

            return CreateButton(name, text, commandClassType, action);
        }


        public CustomPanel CreateButton(string name,
                                  string text,
                                  Type externalCommandType)
        {
            return CreateButton(name, text, externalCommandType, null);
        }

        public CustomPanel CreateButton(string name,
                                  string text,
                                  Type externalCommandType,
                                  Action<CustomPushButton> action)
        {
            var button = new CustomPushButton(name,
                text,
                externalCommandType);
            action?.Invoke(button);
            var buttonData = button.GetItemData();
            RvtPushButton = _panel.AddItem(buttonData) as PushButton;
            return this;
        }
        #endregion //Create the buttons

        #region Create the stacked item
        //The maxi button of stackedItem accepted is 3
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

            var item1 = stackedItem.Items[0].GetItemData();
            var item2 = stackedItem.Items[1].GetItemData();
            IList<RibbonItem> ribbonItems;
            if (stackedItem.ItemsCount == 3)
            {
                RibbonItemData item3 = stackedItem.Items[2].GetItemData();
                ribbonItems = _panel.AddStackedItems(item1, item2, item3);
            }
            else
                ribbonItems = _panel.AddStackedItems(item1, item2);

            for (var i = 0; i < stackedItem.Items.Count; ++i)
                stackedItem.Items[i].DoPostProcessing(ribbonItems[i]);//?

            return this;
        }
        #endregion //Create the stacked item

        #region Create the pulldonwbutton
        public CustomPanel CreatePullDownButton(string name,
                                  string text,
                                  Action<CustomPulldownButton> action)
        {
            var pulldownButton = new CustomPulldownButton(name, text);

            action?.Invoke(pulldownButton);
            var pulldownButtonData = pulldownButton.GetItemData();
            RvtPulldownButton = _panel.AddItem(pulldownButtonData) as PulldownButton;
            pulldownButton.BuildButtons(RvtPulldownButton);
            pulldownButton.RibbonItem = RvtPulldownButton;
            return this;
        }

        #endregion

        public CustomPanel CreateSplitButton(string name, string text, Action<CustomStackedItem> itemsAction)
        {
            var buttonControl = new CustomSplitButton(this, name, text);

            var splitButton = buttonControl.Create();

            var stackedItem = new CustomStackedItem(this);

            itemsAction.Invoke(stackedItem);

            var pushButtons = stackedItem
                .Items
                .Select(x => x.GetItemData())
                .Cast<PushButtonData>()
                .Select(x => splitButton.AddPushButton(x))
                .ToList();

            splitButton.CurrentButton = pushButtons[stackedItem.GetDefaultButtonIndex()];

            return this;
        }

        public CustomPanel CreateTextBox(string name, Action<CustomTextBox> action)
        {
            var txt = new CustomTextBox(name);
            action?.Invoke(txt);
            var txtData = txt.GetItemData();
            _panel.AddItem(txtData);
            return this;
        }

        public CustomPanel CreateSeparator()
        {
            _panel.AddSeparator();
            return this;
        }

        public override RibbonItemData GetItemData()
        {
            return null;
        }

        public RibbonItem Find<TExternalCommandClass>()
            where TExternalCommandClass : class, IExternalCommand
        {
          
            var itemName = typeof(TExternalCommandClass).ToString();
            return Find(itemName);
        }

        public RibbonItem Find(string itemName)
        {
            return RvtPanel.GetItems().FirstOrDefault(x => x.Name == itemName);
        }

        public void MoveToSystemTab<TExternalCommandClass>(string systemTabId, string systemPanelId)
            where TExternalCommandClass : class, IExternalCommand
        {
            var application = Tab.Ribbon.ControlledApplication;

            if (application == null)
                throw new InvalidOperationException("can't move to system tab, ribbon must be created from controlledApplication");

            application.ControlledApplication.ApplicationInitialized += (sender, e) =>
            {
                var ribbonControl = Autodesk.Windows.ComponentManager.Ribbon;

                var destTab = ribbonControl.Tabs.Single(x => x.Id == systemTabId);
                var destPanel = destTab.Panels.Single(x => x.Source.Id == systemPanelId);

                var sourceTab = ribbonControl.Tabs.Single(x => x.Id == Tab.Title);
                var sourcePanel = sourceTab.Panels.Single(x => x.Source.Name == Name);

                var sourceCommandId = $"CustomCtrl_%CustomCtrl_%{Tab.Title}%{Name}%{Find<TExternalCommandClass>().Name}";

                var sourceItem = sourcePanel.Source.Items.Single(x => x.Id == sourceCommandId);

                destPanel.Source.Items.Add(sourceItem);

                sourcePanel.Source.Items.Remove(sourceItem);

                if (!sourcePanel.Source.Items.Any())
                    sourceTab.Panels.Remove(sourcePanel);

                if (!sourceTab.Panels.Any())
                    ribbonControl.Tabs.Remove(sourceTab);
            };
        }

    }
}
