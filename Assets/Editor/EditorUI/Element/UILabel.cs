using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public class UILabel : UITextElement
    {
        public UILabel()
        {
            ContentStyle = EditorStyles.label;
            IsAllowRichText = true;
        }

        public UILabel(string text)
        {
            ContentStyle = EditorStyles.label;
            IsAllowRichText = true;
            Text = text;
        }

        protected override void Content()
        {
            EditorGUILayout.LabelField(Text, ContentStyle);
        }
    }
}