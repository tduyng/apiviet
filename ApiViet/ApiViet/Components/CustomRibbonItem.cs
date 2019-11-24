using Autodesk.Revit.UI;

namespace ApiViet.Ribbon
{
    public abstract class CustomRibbonItem
    {
        public RibbonItem RibbonItem { get; set; }
        public virtual bool IsVisible { get; set; }
        public abstract RibbonItemData GetItemData();
        public virtual void DoPostProcessing(RibbonItem ribbonItem)
        {
        }
    }
}