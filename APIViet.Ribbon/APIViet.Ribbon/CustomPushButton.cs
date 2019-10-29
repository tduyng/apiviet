/* 
 * Learn solution of Victor Chekalin
 * 
 * THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
 * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 * PARTICULAR PURPOSE.
 * 
 */
#region Namespaces
using System;
using System.Drawing;
using System.Windows.Media;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using APIViet.Ribbon.Helpers;
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
        protected ImageSource _toolTipsImage;
        protected string _toolTips;
        protected string _description;
        private string _assemblyLocation;
        protected ContextualHelp _contextualHelp;

        public CustomPushButton(string name,
                      string text,
                      Type externalCommandType)
        {
            _name = name;
            _text = text;

            if (externalCommandType == null) return;
            _className = externalCommandType.FullName;
            _assemblyLocation = externalCommandType.Assembly.Location;
        }


        public CustomPushButton SetLargeImage(ImageSource largeImage)
        {
            _largeImage = largeImage;
            return this;
        }

        public CustomPushButton SetLargeImage(Bitmap largeImage)
        {
            _largeImage = BitmapSourceConverter.ConvertFromBitmap(largeImage);
            return this;
        }
        public CustomPushButton SetLargeImage(Icon largeImage)
        {
            _largeImage = BitmapSourceConverter.ConvertFromIcon(largeImage);
            return this;
        }
        public CustomPushButton SetLargeImage(string largeImageFullName)
        {
            _largeImage = IconRibbon.GetEmbededImageFromSource(largeImageFullName);
            return this;
        }

        //Set small Image
        public CustomPushButton SetSmallImage(ImageSource smallImage)
        {
            _smallImage = smallImage;
            return this;
        }
        public CustomPushButton SetSmallImage(Bitmap smallImage)
        {
            _smallImage = BitmapSourceConverter.ConvertFromBitmap(smallImage);
            return this;
        }
        public CustomPushButton SetSmallImage(Icon smallImage)
        {
            _smallImage = BitmapSourceConverter.ConvertFromIcon(smallImage);
            return this;
        }
        public CustomPushButton SetSmallImage(string smallImageFullName)
        {
            _smallImage = IconRibbon.GetEmbededImageFromSource(smallImageFullName);
            return this;
        }

        //Set ToolTipImage
        public CustomPushButton SetToolTipsImage(ImageSource toolTipsImage)
        {
            _toolTipsImage = toolTipsImage;
            return this;
        }
        public CustomPushButton SetToolTipsImage(Bitmap toolTipsImage)
        {
            _toolTipsImage = BitmapSourceConverter.ConvertFromBitmap(toolTipsImage);
            return this;
        }
        public CustomPushButton SetToolTipsImage(Icon toolTipsImage)
        {
            _toolTipsImage = BitmapSourceConverter.ConvertFromIcon(toolTipsImage);
            return this;
        }
        public CustomPushButton SetToolTipsImage(string toolTipsImageFullName)
        {
            _toolTipsImage = IconRibbon.GetEmbededImageFromSource(toolTipsImageFullName);
            return this;
        }


        public CustomPushButton SetToolTips(string toolTips)
        {
            _description = toolTips;
            return this;
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

        //PushButtonData
        internal virtual ButtonData GetButtonData()
        {
            PushButtonData pushButtonData =
                 new PushButtonData(_name,
                                    _text,
                                    _assemblyLocation,
                                    _className);

            if (_largeImage  != null)
            {
                pushButtonData.LargeImage = _largeImage;
            }

            if (_smallImage != null)
            {
                pushButtonData.Image = _smallImage;
            }
            if (_toolTipsImage !=  null)
            {
                pushButtonData.ToolTipImage = _toolTipsImage;
            }
            if (!string.IsNullOrWhiteSpace(_toolTips))
            {
                pushButtonData.ToolTip = _toolTips;
            }
            if (!string.IsNullOrWhiteSpace(_description))
            {
                pushButtonData.LongDescription = _description;
            }
            if (_contextualHelp !=  null)
            {
                pushButtonData.SetContextualHelp(_contextualHelp);
            }
            return pushButtonData;
        }
    }
}
