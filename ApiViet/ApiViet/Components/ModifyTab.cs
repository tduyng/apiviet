//Solution learn by https://github.com/CADBIMDeveloper

using System.Linq;
using Autodesk.Windows;
using UIFramework;

namespace ApiViet.Ribbon
{
    public class ModifyTab
    {
        private readonly RibbonTab tab;

        private ModifyTab(RibbonTab tab)
        {
            this.tab = tab;
        }

        public static ModifyTab Instance => new ModifyTab(ContextualTabHelper.ModifyTab);

        public bool IsActive
        {
            get { return tab.IsActive; }
            set { tab.IsActive = value; }
        }

        public void SetPanelVisibility(string panelId, bool visibility)
        {
            var panel = tab
                .Panels
                .FirstOrDefault(x => x.Source.Id == panelId);

            if (panel == null) return;

            panel.IsVisible = visibility;

            SetPanelItemsVisibility(panel.Source, visibility);
        }

        private static void SetPanelItemsVisibility(RibbonPanelSource panelSource, bool visibility)
        {
            foreach (var item in panelSource.Items)
                item.IsVisible = visibility;
        }
    }
}