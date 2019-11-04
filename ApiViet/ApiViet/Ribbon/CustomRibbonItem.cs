using Autodesk.Revit.UI;

namespace ApiViet.Ribbon
{
    public abstract class CustomRibbonItem
    {
        internal RibbonItem RibbonItem { get; set; }
        public bool IsVisible { get; set; }
    }
}