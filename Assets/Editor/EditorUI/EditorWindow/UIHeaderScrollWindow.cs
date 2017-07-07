using GGM.Editor.UI.Element;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Window
{
    public abstract class UIHeaderScrollWindow : UIScrollWindow
    {
        public IUIElement HeaderElement { get; set; }
        public GUIStyle HeaderElementStyle { get; set; }
        public override void Draw()
        {
            if(HeaderElement != null)
                HeaderElement.Draw();
            base.Draw();
        }
    }
}