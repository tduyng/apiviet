/* 
 * Lear solution of Victor Chekalin
 */


using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace APIViet.Ribbon.Helpers
{
    public static class BitmapSourceConverter
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")] //Creates a GDI bitmap object from a GDI+
        private static extern bool DeleteObject(IntPtr hObject);

        public static BitmapSource ConvertFromBitmap(Bitmap image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            //Intptr: A handle to the GDI bitmap object that this method creates.
            IntPtr hBitmap = image.GetHbitmap();
            try
            {
                //Returns a managed BitmapSource, based on the provided pointer to an unmanaged bitmap and palette information
                var bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                return bs;
            }
            finally
            {
                DeleteObject(hBitmap);
            }
        }
        public static BitmapSource ConvertFromIcon(Icon icon)
        {
            try
            {
                //Returns a managed BitmapSource, based on the provided pointer to an unmanaged icon image.
                var bs = Imaging
                    .CreateBitmapSourceFromHIcon(icon.Handle,
                                                 new Int32Rect(0, 0, icon.Width, icon.Height),
                                                 BitmapSizeOptions.FromWidthAndHeight(icon.Width,icon.Height));
                return bs;
            }
            finally
            {
                DeleteObject(icon.Handle);
            }
        }
    }
}