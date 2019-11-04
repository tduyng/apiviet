using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace ApiViet.SelectByParameter
{

    class SelectionFilter : ISelectionFilter

    {
        public Type FilteredType { get; set; }
        public Category FilteredCategory{ get; set; }


        public SelectionFilter(Type type)
        {
            FilteredType = type;
            FilteredCategory = null;
        }

        public SelectionFilter(Category category)
        {
            FilteredType = null;
            FilteredCategory = category;
        }

        public SelectionFilter(Type type, Category category)
        {
            FilteredType = type;
            FilteredCategory = category;
        }

        public bool AllowElement(Element elem)
        {
            if (FilteredType is null && FilteredCategory is null)
                return true;

            if (FilteredType is null)
            {
                if (elem.Category.Name == FilteredCategory.Name)
                    return true;
            }
            if (FilteredCategory is null)
            {
                if (((object)elem).GetType() == FilteredType)
                    return true;
            }
            return false;
        }

        public bool AllowReference(Reference refer, XYZ pos)
        {
            return true;
        }
    }
}

