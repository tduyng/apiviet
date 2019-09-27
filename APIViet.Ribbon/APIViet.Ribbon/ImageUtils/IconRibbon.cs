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

    public class IconRibbon
    {
        public static ImageSource GetEmbededImageFromSource(string embededlargeImageName)
        {

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededlargeImageName);
            string imageExtension = Path.GetExtension(embededlargeImageName);
            if (imageExtension.Equals(".png",StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    PngBitmapDecoder img = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];
                }
                catch { return null; }

            }

            if (imageExtension.Equals(".bmp", StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    BmpBitmapDecoder img = new BmpBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];
                }
                 catch{return null;}

            }

            if (imageExtension.Equals(".jpeg", StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    JpegBitmapDecoder img = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];
                }
                catch { return null; }
                
            }

            if (imageExtension.Equals(".tiff", StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    TiffBitmapDecoder img = new TiffBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];
                }
                catch { return null; }
                
            }

            if (imageExtension.Equals(".ico", StringComparison.CurrentCultureIgnoreCase))
            {
                try
                {
                    IconBitmapDecoder img = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    return img.Frames[0];
                }
                catch { return null; }
                
            }

            return null;
        }

        public static  ImageSource GetPngImageFromSource(string embededlargeImageName)
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
        public static ImageSource GetIcoImageFromSource (string embededlargeImageName)
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


        public static BitmapImage GetIconFromAFolder( string imageFolder,string imageFullName)
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
