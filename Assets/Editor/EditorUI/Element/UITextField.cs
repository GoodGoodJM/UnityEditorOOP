using System;
using UnityEditor;

namespace GGM.Editor.UI.Element
{
    public class UITextField : UITextElement
    {
        public Action<string> OnTextChange { get; set; }

        protected override void Content()
        {
            string beforeText = Text;
            Text = EditorGUILayout.TextField(Text);
            if (beforeText != Text)
                OnTextChange(Text);
        }
    }
}