using System;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public class UITextArea : UITextElement
    {
        public Action<UITextArea> OnTextChange { get; set; }

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

        protected override void Content()
        {
            string beforeText = Text;
            Text = EditorGUILayout.TextArea(Text, ContentStyle);
            if (beforeText != Text)
                OnTextChange(this);
        }
    }
}