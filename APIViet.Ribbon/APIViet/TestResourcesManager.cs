using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APIViet.Ribbon
{
    class TestResourcesManager
    {
        public static void Main()
        {
            string[] all = System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceNames();

            foreach (string one in all)
            {
                MessageBox.Show(one);
            }
        }
    }
}
