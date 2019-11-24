//Learn the solution of Victor Chekalin

#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using System.ComponentModel;
#endregion

namespace ApiViet.Ribbon
{
    //Split button,we dont care the image, name, text
    public class CustomSplitButton :CustomRibbonItem
    {
        private readonly string name;
        private readonly CustomPanel panel;
        private readonly string text;

        public  CustomSplitButton(CustomPanel panel, string name, string text)
        {
            this.panel = panel;
            this.name = name;
            this.text = text;
        }

        public SplitButton Create()
        {
            var splitButton = panel.RvtPanel.GetItems()
                .OfType<SplitButton>()
                .FirstOrDefault(x => x.Name == name);

            if (splitButton != null) return splitButton;

            var splitButtonData = new SplitButtonData(name, text);

            return panel.RvtPanel.AddItem(splitButtonData) as SplitButton;
        }

        public override RibbonItemData GetItemData()
        {
            return null;
        }
    }
    
}
