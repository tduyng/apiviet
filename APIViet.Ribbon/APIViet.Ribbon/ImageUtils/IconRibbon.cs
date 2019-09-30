#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Media;
#endregion

namespace APIViet.Ribbon.ImageUtils
{
    /// <summary>
    /// Get image
    /// </summary>

    public static class IconRibbon
    {
        // Case: when we dont bother the extention of image input and return an imagsesource of Image
        public static ImageSource GetEmbededImageFromSource(string embededlargeImageName)
        {
            try
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededlargeImageName);
                string imageExtension = Path.GetExtension(embededlargeImageName);

                if (imageExtension.Equals(".png", StringComparison.CurrentCultureIgnoreCase))
                {
                    PngBitmapDecoder img = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];
                }

                if (imageExtension.Equals(".bmp", StringComparison.CurrentCultureIgnoreCase))
                {
                    BmpBitmapDecoder img = new BmpBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];

                }

                if (imageExtension.Equals(".jpeg", StringComparison.CurrentCultureIgnoreCase))
                {
                    JpegBitmapDecoder img = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];

                }

                if (imageExtension.Equals(".tiff", StringComparison.CurrentCultureIgnoreCase))
                {
                    TiffBitmapDecoder img = new TiffBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];

                }

                if (imageExtension.Equals(".ico", StringComparison.CurrentCultureIgnoreCase))
                {
                    IconBitmapDecoder img = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];
                }
            }
            catch { return null; }
            return null;
        }

        //Case specific for each type of image input
        public static ImageSource GetPngImageFromSource(string embededlargeImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededlargeImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }
        }
        public static ImageSource GetBmpImageFromSource(string embededlargeImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededlargeImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }

        }
        public static ImageSource GetJpegImageFromSource(string embededlargeImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededlargeImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }

        }
        public static ImageSource GetIcoImageFromSource(string embededlargeImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededlargeImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }

        }
        public static ImageSource GetTiffImageFromSource(string embededlargeImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededlargeImageName);
                var decorder = new TiffBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }

        }


        public static BitmapImage GetIconFromAFolder(string imageFolder, string imageFullName)
        {
            try
            {
                return new BitmapImage(new Uri(Path.Combine(imageFolder, imageFullName)));
            }
            catch
            {
                return null;
            }
        }

    }


}
