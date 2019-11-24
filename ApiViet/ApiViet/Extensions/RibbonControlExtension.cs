using System.Linq;
using Autodesk.Windows;

//solution of https://github.com/CADBIMDeveloper
namespace ApiViet.Ribbon.Extensions
{
    public static class RibbonControlExtensions
    {
        public static RibbonTab FindTabByTitle(this RibbonControl ribbonControl, string title)
        {
            return ribbonControl.Tabs.FirstOrDefault(x => x.Title == title);
        }
    }
}