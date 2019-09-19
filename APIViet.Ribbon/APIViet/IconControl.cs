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
using Autodesk.Revit.UI;

#endregion

namespace APIViet.Ribbon
{
    /// <summary>
    /// Get images(png, ico, jpeg, bmp) in ImgSources
    /// </summary>
    /// 

    public class IconControl
    {
        public BitmapImage NewBitMapImage(string imageName)
        {
            try
            {
                string imageFolderName = "ImgSource";
                string dirAddIn = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string imageFolder = FindFolderParents(dirAddIn, imageFolderName);

                if (null == imageFolder || Directory.Exists(imageFolder))
                {
                    TaskDialog.Show("UIRibbon", $"No image folder named {imageFolderName} found in the parent directories of {dirAddIn}");
                    return null;
                }

                return new BitmapImage(new Uri(Path.Combine(imageFolder, imageName)));

            }
            catch
            {
                return null;
            }
                
        }

        private string FindFolderParents(string path, string target)
        {
            Debug.Assert(Directory.Exists(path), "expected an existing directory to start search in ");
            string s;
            do
            {
                s = Path.Combine(path, target);
                if (Directory.Exists(s))
                {
                    return s;
                }
                path = Path.GetDirectoryName(path);

            } while (null != path);
            return null;

        }

        static BitmapSource GetEmbeddedImage(string name)
        {
            try
            {
                Assembly a = Assembly.GetExecutingAssembly();
                Stream s = a.GetManifestResourceStream(name);
                return BitmapFrame.Create(s);
            }
            catch
            {
                return null;
            }
        }

        private static ImageSource ImgSource(string imgFullName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imgFullName);
            PngBitmapDecoder img = new System.Windows.Media.Imaging.PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return img.Frames[0];
        }
        private static System.Windows.Media.ImageSource PngImageSource(string nomImage, object objet)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(nomImage);
            var decoder = new System.Windows.Media.Imaging.PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }
    }
}



