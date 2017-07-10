using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public abstract class UIElement : IUIElement
    {
        protected UIElement()
        {
            LayoutStyle = GUIStyle.none;
            BackgroundColor = Color.white;
        }

        public Color BackgroundColor { get; set; }
        public GUIStyle LayoutStyle { get; set; }

        public void Draw()
        {
            var previousColor = GUI.backgroundColor;

            GUI.backgroundColor = BackgroundColor;
            EditorGUILayout.BeginVertical(LayoutStyle);
            GUI.backgroundColor = previousColor;
            Content();
            GUI.backgroundColor = BackgroundColor;
            EditorGUILayout.EndVertical();
            GUI.backgroundColor = previousColor;
        }

        protected abstract void Content();
    }
}