//Learn the solution of Victor Chekalin

#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using System.ComponentModel;
#endregion

namespace APIViet.Ribbon
{
    public class CustomPulldownButton : CustomPushButton
    {
        private readonly IList<CustomPushButton> _buttons = new List<CustomPushButton>();

        public CustomPulldownButton(string name, string text) :
            base(name, text, null)
        {
        }
        internal override ButtonData GetButtonData()
        {
            PulldownButtonData pulldownButtonData =
                new PulldownButtonData(_name,
                    _text);
            if (_largeImage !=  null)
            {
                pulldownButtonData.LargeImage = _largeImage;
            }

            if (_smallImage != null)
            {
                pulldownButtonData.Image = _smallImage;
            }
            if (_toolTipsImage != null)
            {
                pulldownButtonData.ToolTipImage = _toolTipsImage;
            }
            if (!string.IsNullOrWhiteSpace(_toolTips))
            {
                pulldownButtonData.ToolTip = _toolTips;
            }
            if (!string.IsNullOrWhiteSpace(_description))
            {
                pulldownButtonData.LongDescription = _description;
            }
            if (_contextualHelp != null)
            {
                pulldownButtonData.SetContextualHelp(_contextualHelp);
            }
            return pulldownButtonData;
        }

        //Action: delegate for method of buton, eg: SetLargeImage, SetTooltips....
        public CustomPulldownButton CreateButton(string name,
                                   string text,
                                   Type externalCommandType,
                                   Action<CustomPushButton> action)
        {

            var button = new CustomPushButton(name,
                              text,
                              externalCommandType);
            if (action != null)
            {
                action.Invoke(button); 
            }
            Buttons.Add(button);

            return this;
        }

        public CustomPulldownButton CreateButton<TExternalCommandClass>(string name,
                          string text)
                        where TExternalCommandClass : class, IExternalCommand
        {
            var commandClassType = typeof(TExternalCommandClass);
            return CreateButton(name, text, commandClassType, null);
        }

        public CustomPulldownButton CreateButton<TExternalCommandClass>(string name,
                                  string text,
                                  Action<CustomPushButton> action)
            where TExternalCommandClass : class, IExternalCommand
        {
            var commandClassType = typeof(TExternalCommandClass);
            return CreateButton(name, text, commandClassType, action);
        }

        public CustomPulldownButton CreateButton(string name,
                                  string text,
                                  Type externalCommandType)
        {
            return CreateButton(name, text, externalCommandType, null);
        }


        public int ItemsCount
        {
            get { return Buttons.Count; }
        }

        public IList<CustomPushButton> Buttons
        {
            get { return _buttons; }
        }

        internal void BuildButtons(Autodesk.Revit.UI.PulldownButton pulldownButton)
        {
            foreach (var button in Buttons)
            {
                pulldownButton.AddPushButton(button.GetButtonData() as PushButtonData);
            }
        }

    }
}
