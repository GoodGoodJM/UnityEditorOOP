using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public abstract class UIElement : IUIElement
    {
        protected UIElement()
        {
            LayoutStyle = GUIStyle.none;
        }

        public Texture2D BackgroundTexture
        {
            get { return LayoutStyle.normal.background; }
            set { LayoutStyle.normal.background = value; }
        }

        public Color BackgroundColor { get; set; }
        public GUIStyle LayoutStyle { get; set; }

        public void Draw()
        {
            var previousColor = GUI.backgroundColor;

            GUI.backgroundColor = BackgroundColor;
            EditorGUILayout.BeginVertical(LayoutStyle);
            Content();
            EditorGUILayout.EndVertical();
            GUI.backgroundColor = previousColor;
        }

        protected abstract void Content();
    }
}