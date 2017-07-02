using System;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public class UIButton : UIElement
    {
        public string Text { get; set; }

        public Action OnButtonClick { get; set; }

        public UIButton()
        {
            Style = EditorStyles.miniButton;
        }

        public UIButton(string text)
        {
            Style = EditorStyles.miniButton;
            Text = text;
        }

        public UIButton(GUIStyle style)
        {
            Style = style;
        }

        public UIButton(string text, GUIStyle style)
        {
            Text = text;
            Style = style;
        }


        protected override void Content()
        {
            Rect rect = EditorGUILayout.BeginHorizontal(Style);
            if (GUI.Button(rect, GUIContent.none))
                OnButtonClick.Execute();
            GUILayout.Label(Text);
            EditorGUILayout.EndHorizontal();
        }
    }
}