#region Namespaces
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using APIViet.Ribbon.ImageUtils;
#endregion

namespace APIViet.Ribbon
{
    public class CustomPushButton : CustomRibbonItem
    {
        protected readonly string _name;
        protected readonly string _text;
        private readonly string _className;
        protected ImageSource _largeImage;
        protected ImageSource _smallImage;
        protected string _description;
        private string _assemblyLocation;
        protected ContextualHelp _contextualHelp;

        public CustomPushButton(string name,
                      string text,
                      Type externalCommandType)
        {
            _name = name;
            _text = text;

            if (externalCommandType != null)
            {
                _className = externalCommandType.FullName;
                _assemblyLocation = externalCommandType.Assembly.Location;
            }
        }


        public CustomPushButton SetLargeImage(ImageSource largeImage)
        {
            _largeImage = largeImage;
            return this;
        }

        public CustomPushButton SetLargeImage(Bitmap largeImage)
        {
            _largeImage = BitmapSourceConverter.ConvertFromImage(largeImage);
            return this;
        }

        public CustomPushButton SetSmallImage(ImageSource smallImage)
        {
            _smallImage = smallImage;
            return this;
        }

        public CustomPushButton SetSmallImage(Bitmap smallImage)
        {
            _smallImage = BitmapSourceConverter.ConvertFromImage(smallImage);
            return this;
        }

        internal virtual ButtonData Finish()
        {
            PushButtonData pushButtonData =
                 new PushButtonData(_name,
                                    _text,
                                    _assemblyLocation,
                                    _className);

            if (_largeImage != null)
            {
                pushButtonData.LargeImage = _largeImage;
            }

            if (_smallImage != null)
            {
                pushButtonData.Image = _smallImage;
            }

            if (_description != null)
            {
                pushButtonData.LongDescription = _description;
            }

            if (_contextualHelp != null)
            {
                pushButtonData.SetContextualHelp(_contextualHelp);
            }

            //_panel.Source.AddItem(pushButtonData);

            return pushButtonData;
        }

        public CustomPushButton SetLongDescription(string description)
        {
            _description = description;

            return this;
        }

        public CustomPushButton SetContextualHelp(ContextualHelpType contextualHelpType, string helpPath)
        {
            _contextualHelp = new ContextualHelp(contextualHelpType, helpPath);

            return this;
        }

        public CustomPushButton SetHelpUrl(string url)
        {
            _contextualHelp = new ContextualHelp(ContextualHelpType.Url, url);

            return this;
        }


        //public CustomPushButton() {}
        //public static PushButton NewButton(RibbonPanel panel, string btnName,string btnText, string assemblyName, string className, string largeImageName ="", string btnTooltip ="")
        //{
        //    try
        //    {
        //        PushButtonData btnData = new PushButtonData(btnName, btnText, assemblyName, className);

        //        btnData.ToolTip = btnTooltip;
        //        ContextualHelp help = new ContextualHelp(ContextualHelpType.Url, "https://help.autodesk.com");
        //        btnData.SetContextualHelp(help);
        //        btnData.Image = ImageIcon.ImageSource(largeImageName);

        //        //Add buton to panel
        //        PushButton btn = panel.AddItem(btnData) as PushButton;
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
