using System;
using UnityEditor;

namespace GGM.Editor.UI.Element
{
    public class UITextArea : UITextElement
    {
        public UITextArea()
        {
            ContentStyle = EditorStyles.textArea;
            IsAllowRichText = true;
        }

        public UITextArea(string text)
        {
            ContentStyle = EditorStyles.textArea;
            IsAllowRichText = true;
            Text = text;
        }

        public Action<UITextArea> OnTextChange { get; set; }

        protected override void Content()
        {
            var beforeText = Text;
            Text = EditorGUILayout.TextArea(Text, ContentStyle);
            if (beforeText != Text)
                OnTextChange(this);
        }
    }
}