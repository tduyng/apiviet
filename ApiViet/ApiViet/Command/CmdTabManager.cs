#region Namespaces

using Autodesk.Revit.UI.Events;

#endregion

namespace ApiViet
{
    public class CmdTabManager
    {
        private void DisableTab(string name)
        {
            foreach (Autodesk.Windows.RibbonTab tab in Autodesk.Windows.ComponentManager.Ribbon.Tabs)
            {
                if (tab.Title == name)
                {
                    tab.IsVisible = false;
                }
            }
        }
        private void Application_ViewActivated(object sender, ViewActivatedEventArgs e)
        {
            DisableTab("Architecture");
        }
    }
}
