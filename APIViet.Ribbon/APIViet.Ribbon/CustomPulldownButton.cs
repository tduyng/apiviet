//Learn the solution of Victor 

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
    public class CustomPulldownButton : CustomPushButton
    {
            private readonly IList<CustomPushButton> _buttons = new List<CustomPushButton>();

            public CustomPulldownButton(string name, string text) :
                base(name, text, null)
            {
            }

            internal override ButtonData Finish()
            {
                PulldownButtonData pulldownButtonData =
                    new PulldownButtonData(_name,
                        _text);


                if (_largeImage != null)
                {
                    pulldownButtonData.LargeImage = _largeImage;
                }

                if (_smallImage != null)
                {
                    pulldownButtonData.Image = _smallImage;
                }

                if (_description != null)
                {
                    pulldownButtonData.LongDescription = _description;
                }

                if (_contextualHelp != null)
                {
                    pulldownButtonData.SetContextualHelp(_contextualHelp);
                }

                //pulldownButtonData.

                //_panel.Source.AddItem(pushButtonData);

                return pulldownButtonData;
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

            //public PulldownButton CreateSeparator()
            //{
            //    return this;
            //}

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
                    pulldownButton.AddPushButton(button.Finish() as PushButtonData);
                }
            }


        //public CustomPulldownButton() {}
        //public static PushButton NewButton(RibbonPanel panel, PulldownButton pulldownBtn, string btnName, string btnText,string assemblyName, string className, string largeImageName = "", string btnTooltip = "")
        //{
        //    try
        //    {
        //        PushButtonData btnData = CustomPushButtonData.GetButtonData(btnName, btnText, assemblyName, className, largeImageName, btnTooltip);
        //        PushButton btn = pulldownBtn.AddPushButton(btnData);
        //        return btn;
        //    }
        //    catch(Exception)
        //    {
        //        return null;
        //        throw;
        //    }

        //}
    }
}
