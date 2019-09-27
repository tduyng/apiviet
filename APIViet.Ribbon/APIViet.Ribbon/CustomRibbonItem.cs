using Autodesk.Revit.UI;

namespace APIViet.Ribbon
{
    public abstract class CustomRibbonItem
    {
        internal RibbonItem RibbonItem { get; set; }
        public bool IsVisible { get; set; }
    }
}