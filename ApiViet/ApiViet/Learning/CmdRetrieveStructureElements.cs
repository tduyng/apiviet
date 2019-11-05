using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;

namespace ApiViet.Learning
{
    [Transaction(TransactionMode.Manual)]
    class CmdRetrieveStructureElements :IExternalCommand
    {
        
        FilteredElementCollector GetStructuralElements(
            Document doc)
        {
            // what categories of family instances
            // are we interested in?

            BuiltInCategory[] bics = new BuiltInCategory[] {
                BuiltInCategory.OST_StructuralColumns,
                BuiltInCategory.OST_StructuralFraming,
                BuiltInCategory.OST_StructuralFoundation
            };

            IList<ElementFilter> a
                = new List<ElementFilter>(bics.Count());

            foreach (BuiltInCategory bic in bics)
            {
                a.Add(new ElementCategoryFilter(bic));
            }

            LogicalOrFilter categoryFilter
                = new LogicalOrFilter(a);

            LogicalAndFilter familyInstanceFilter
                = new LogicalAndFilter(categoryFilter,
                    new ElementClassFilter(
                        typeof(FamilyInstance)));

            IList<ElementFilter> b
                = new List<ElementFilter>(6);

            b.Add(new ElementClassFilter(
                typeof(Wall)));

            b.Add(new ElementClassFilter(
                typeof(Floor)));

            //b.Add(new ElementClassFilter(
            //    typeof(ContFooting)));

            b.Add(new ElementClassFilter(
                typeof(PointLoad)));

            b.Add(new ElementClassFilter(
                typeof(LineLoad)));

            b.Add(new ElementClassFilter(
                typeof(AreaLoad)));

            b.Add(familyInstanceFilter);

            LogicalOrFilter classFilter
                = new LogicalOrFilter(b);

            FilteredElementCollector collector
                = new FilteredElementCollector(doc);

            collector.WherePasses(classFilter);

            return collector;
        }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            throw new NotImplementedException();
        }
    }
}
