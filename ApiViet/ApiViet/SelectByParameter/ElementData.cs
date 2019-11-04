using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace ApiViet.SelectByParameter
{
    class ElementData : IEquatable<ElementData>, IComparable<ElementData>
    {
        public List<ElementData> Children { get; } = new List<ElementData>();
        public Category Category { get; set; }
        public Level Level { get; set; }
        public double Elevation { get; set; }
        public Family Family { get; set; }
        public Type RevitType { get; set; }
        public Parameter Parameter { get; set; }
        public string ParameterValue { get; set; }
        public Element ExElement { get; set; }
        public bool IsFamilyInstance { get; set; }
        public string FamilyInstanceTypeName { get; set; }
        public string FamilyName { get; set; }


        public string Name
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(FamilyInstanceTypeName))
                    {
                        if (!string.IsNullOrEmpty(FamilyName) && FamilyName != FamilyInstanceTypeName)
                        {
                            return FamilyName + "-" + FamilyInstanceTypeName;
                        }
                        return FamilyInstanceTypeName;
                    }
                    if (!string.IsNullOrEmpty(FamilyName))
                    {
                        return FamilyName;
                    }
                    if (!string.IsNullOrEmpty(ParameterValue))
                    {
                        return ParameterValue;
                    }
                    if (Parameter != null)
                    {
                        return Parameter.Definition.Name;
                    }
                    if (Category != null)
                    {
                        return Category.Name;
                    }
                    if (RevitType != null)
                    {
                        return RevitType.Name;
                    }
                    return "Family";
                }
                catch
                {
                    return "Family";
                }
            }
        }

        public ElementData()
            : this(isFamilyInstance: false, null, null, null)
        {
        }

        public ElementData(bool isFamilyInstance, Category category)
            : this(isFamilyInstance, category, null, null)
        {
        }

        public ElementData(bool isFamilyInstance, Type type)
            : this(isFamilyInstance, null, type, null)
        {
        }

        public ElementData(bool isFamilyInstance, Category category, Type type, Parameter parameter)
        {
            Category = category;
            Parameter = parameter;
            IsFamilyInstance = isFamilyInstance;
            RevitType = type;
        }

        public bool Equals(ElementData compareObject)
        {
            if (compareObject != null && Name == compareObject.Name)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(ElementData compareObject)
        {
            return String.CompareOrdinal(Name, compareObject.Name);
        }
    }
}
