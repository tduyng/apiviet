#region Bibliothèque par défaut

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

#region Bibliothèque ajoutée de Revit

#endregion

#region Autres Bibliothèques ajoutées

using System.Windows.Media;                 // Pour l'utilisation des images
using System.Windows.Media.Imaging;         // Pour l'utilisation des images
using System.IO;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;                 // Pour les commentaires
using System.Drawing;
using System.Drawing.Drawing2D;             // zone de comment
using System.Diagnostics;

#endregion

namespace APIViet.Ribbon
{
    /// <summary>
    /// Get images(png, ico, jpeg, bmp) in ImgSources
    /// </summary>
    /// 

    public class Image
    {
        const string _imageFolderName = "ImgSource";
        string addInPath;
        string imageFolder;

        public string FindFolderInParents(string path, string target)
        {
            Debug.Assert(Directory.Exists(path),"expedted an existing directory to start search in");
            string pathCombine;
            do
            {
                pathCombine = Path.Combine(path, target);
                if (Directory.Exists(pathCombine))
                {
                    return pathCombine;
                }
                path = Path.GetDirectoryName(path);
            }
            while (null != path);
            return null;
        }
        BitmapImage NewBitMapImage(string imageName)
        {
            return new BitmapImage(new Uri(Path.Combine(imageFolder, imageName)));
        }

        public static ImageSource ImgSource(string imgFullName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imgFullName);
            PngBitmapDecoder img = new System.Windows.Media.Imaging.PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return img.Frames[0];
        }
        public static System.Windows.Media.ImageSource PngImageSource(string nomImage, object objet)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(nomImage);
            var decoder = new System.Windows.Media.Imaging.PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }

    }
}
