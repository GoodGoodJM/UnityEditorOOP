using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public abstract class UITextElement : UIElement
    {
        protected GUIStyle ContentStyle;
        public Color FontColor { get { return ContentStyle.normal.textColor; } set { ContentStyle.normal.textColor = value; } }
        /// <summary>
        /// 색상코드를 입력한 RichText의 색을 표시해 줄 것인가.
        /// </summary>
        public bool IsAllowRichText { get { return ContentStyle.richText; } set { ContentStyle.richText = value; } }
        public string Text { get; set; }

        protected UITextElement()
        {
            Text = "";
        }
    }
}