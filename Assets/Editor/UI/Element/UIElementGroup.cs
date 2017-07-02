using System.Collections;
using System.Collections.Generic;

namespace GGM.Editor.UI.Element
{
    public abstract class UIElementGroup : UIElement, ICollection<UIElement>
    {
        private readonly List<UIElement> _children = new List<UIElement>();
        public List<UIElement> Children { get { return _children; } }
        
        #region ICollection<T>

        //TODO: 의미 좀더 확인해 볼 것.
        public bool IsReadOnly { get { return false; } }
        public int Count { get { return _children.Count; } }

        #region Enumerator

        public IEnumerator<UIElement> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public void Add(UIElement item)
        {
            _children.Add(item);
        }

        public void Clear()
        {
            _children.Clear();
        }

        public bool Contains(UIElement item)
        {
            return _children.Contains(item);
        }

        public void CopyTo(UIElement[] array, int arrayIndex)
        {
            _children.CopyTo(array, arrayIndex);
        }

        public bool Remove(UIElement item)
        {
            return _children.Remove(item);
        }

        #endregion

    }
}