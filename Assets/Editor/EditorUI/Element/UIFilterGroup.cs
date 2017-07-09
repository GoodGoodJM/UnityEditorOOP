using GGM.Editor.Example;

namespace GGM.Editor.UI.Element
{
    public abstract class UIFilterGroup<T> : UIElementGroup<T>
    {
        public string FilterText { get; set; }

        protected override bool CheckCanDraw(ElementView elementView)
        {
            return FilterText.IsNullOrEmpty();
        }
    }
}