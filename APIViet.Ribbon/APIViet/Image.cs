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

namespace APIViet.Ribbon
{
    /// <summary>
    /// Get image
    /// </summary>

    public class Image
    {
        public static ImageSource ImageSource(string embededImageName)
        {

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededImageName);
            string imageExtension = Path.GetExtension(embededImageName);
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

        public static  ImageSource PngImageSource(string embededImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }
        }
        public static ImageSource BmpImageSource(string embededImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }
            
        }
        public static ImageSource JpegImageSource(string embededImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }
            
        }
        public static ImageSource IcoImageSource (string embededImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededImageName);
                var decorder = new IconBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }
            
        }
        public static ImageSource TiffImageSource(string embededImageName)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededImageName);
                var decorder = new TiffBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                return decorder.Frames[0];
            }
            catch { return null; }
            
        }


        public static BitmapImage GetIconFromAFolder( string imageFolder,string imageName)
        {
            try
            {
                return new BitmapImage(new Uri(Path.Combine(imageFolder, imageName)));
            }
            catch
            {
                return null;
            }
        }

    }


 }
