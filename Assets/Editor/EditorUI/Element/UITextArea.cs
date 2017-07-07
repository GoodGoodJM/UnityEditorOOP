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
        }

        public UITextArea(string text)
        {
            Text = text;
            ContentStyle = EditorStyles.textArea;
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