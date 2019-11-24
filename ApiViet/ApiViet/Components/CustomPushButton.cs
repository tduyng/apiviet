/* 
 * Learn solution of Victor Chekalin
 * 

 */
#region Namespaces
using System;
using System.Drawing;
using System.Windows.Media;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ApiViet.Helpers;
#endregion

namespace ApiViet.Ribbon
{
    public class CustomPushButton : CustomRibbonItem
    {
        protected readonly string _name;
        protected readonly string _text;
        protected string _className;
        private string _AvailabilityClassName;
        protected ImageSource _largeImage;
        protected ImageSource _smallImage;
        protected ImageSource _toolTipsImage;
        protected string _toolTips;
        protected string _description;
        protected string _assemblyLocation;
        protected ContextualHelp _contextualHelp;
        public PushButton ConvertToPushButton { get; set; }
        public bool IsDefault { get; private set; }


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
        public CustomPushButton SetAvailability<T>() where T : IExternalCommandAvailability
        {
            var availabilityCommandType = typeof(T);

            if (availabilityCommandType.Assembly.Location != _assemblyLocation)
                throw new InvalidOperationException("Command and CommandAvailability classes must be located in the same assembly");

            _AvailabilityClassName = availabilityCommandType.FullName;

            return this;
        }

        #region Set large image
        public CustomPushButton SetLargeImage(ImageSource largeImage)
        {
            _largeImage = largeImage;
            return this;
        }

        public CustomPushButton SetLargeImage(Bitmap largeImage)
        {
            _largeImage = ImageUtils.ConvertFromBitmap(largeImage);
            return this;
        }
        public CustomPushButton SetLargeImage(Icon largeImage)
        {
            _largeImage = ImageUtils.ConvertFromBitmap(largeImage);
            return this;
        }
        public CustomPushButton SetLargeImage(string largeImageFullName)
        {
            _largeImage = ImageUtils.GetEmbededImageFromSource(largeImageFullName);
            return this;
        }

        #endregion //Set large image

        #region Set small image
        //Set small Image
        public CustomPushButton SetSmallImage(ImageSource smallImage)
        {
            _smallImage = smallImage;
            return this;
        }
        public CustomPushButton SetSmallImage(Bitmap smallImage)
        {
            _smallImage = ImageUtils.ConvertFromBitmap(smallImage);
            return this;
        }
        public CustomPushButton SetSmallImage(Icon smallImage)
        {
            _smallImage = ImageUtils.ConvertFromBitmap(smallImage);
            return this;
        }
        public CustomPushButton SetSmallImage(string smallImageFullName)
        {
            _smallImage = ImageUtils.GetEmbededImageFromSource(smallImageFullName);
            return this;
        }

        #endregion //Set small image

        #region Set tooltip Image, description, help
        //Set ToolTipImage
        public CustomPushButton SetToolTipsImage(ImageSource toolTipsImage)
        {
            _toolTipsImage = toolTipsImage;
            return this;
        }
        public CustomPushButton SetToolTipsImage(Bitmap toolTipsImage)
        {
            _toolTipsImage = ImageUtils.ConvertFromBitmap(toolTipsImage);
            return this;
        }
        public CustomPushButton SetToolTipsImage(Icon toolTipsImage)
        {
            _toolTipsImage = ImageUtils.ConvertFromBitmap(toolTipsImage);
            return this;
        }
        public CustomPushButton SetToolTipsImage(string toolTipsImageFullName)
        {
            _toolTipsImage = ImageUtils.GetEmbededImageFromSource(toolTipsImageFullName);
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
        #endregion //Set tooltip Image

        //Set button defaut in panel
        public CustomPushButton SetDefault()
        {
            IsDefault = true;
            return this;
        }


        //return button data
        public override RibbonItemData GetItemData()
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
            if (_toolTipsImage != null)
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
            if (_contextualHelp != null)
            {
                pushButtonData.SetContextualHelp(_contextualHelp);
            }
            if (!string.IsNullOrEmpty(_AvailabilityClassName))
                pushButtonData.AvailabilityClassName = _AvailabilityClassName;
            return pushButtonData;
        }
    }
}
