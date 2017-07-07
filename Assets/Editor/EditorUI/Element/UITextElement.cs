using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public abstract class UITextElement : UIElement
    {
        protected GUIStyle ContentStyle;
        public Color FontColor { get { return ContentStyle.normal.textColor; } set { ContentStyle.normal.textColor = value; } }
        public string Text { get; set; }
    }
}