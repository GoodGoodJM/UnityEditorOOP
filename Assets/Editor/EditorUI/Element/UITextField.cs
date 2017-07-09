using System;
using UnityEditor;

namespace GGM.Editor.UI.Element
{
    public class UITextField : UITextElement
    {
        public UITextField()
        {
            ContentStyle = EditorStyles.textField;
        }

        public Action<string> OnTextChange { get; set; }

        protected override void Content()
        {
            var beforeText = Text;
            Text = EditorGUILayout.TextField(Text, ContentStyle);
            if (beforeText != Text)
                OnTextChange(Text);
        }
    }
}