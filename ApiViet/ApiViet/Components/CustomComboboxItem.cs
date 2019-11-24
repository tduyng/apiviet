using ApiViet.Helpers;
using System.Drawing;
using System.Windows.Media;

namespace ApiViet.Ribbon
{
    public class CustomComboBoxItem
    {
        public CustomComboBoxItem(string name, string text, bool isDefault = false)
        {
            Name = name;
            Text = text;
            IsDefault = isDefault;
        }

        public string Name { get; }

        public string Text { get; }

        public bool IsDefault { get; }

        public ImageSource Image { get; private set; }

        public CustomComboBoxItem SetImage(ImageSource img)
        {
            Image = img;
            return this;
        }
        public CustomComboBoxItem SetImage(Bitmap img)
        {
            Image = ImageUtils.ConvertFromBitmap(img);
            return this;
        }
        public CustomComboBoxItem SetImage(Icon img)
        {
            Image = ImageUtils.ConvertFromBitmap(img);
            return this;
        }
    }
}
