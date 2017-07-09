using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GGM.Editor.UI.Element
{
    public static class ElementViewHelper
    {
        public static bool IsContains<T>(this List<UIElementGroup<T>.ElementView> self, T data)
        {
            foreach (var elementView in self)
                if (elementView.Data.Equals(data))
                    return true;

            return false;
        }
    }
}
