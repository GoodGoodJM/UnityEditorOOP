using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public abstract class UIElement : IUIElement
    {
        public GUIStyle LayoutStyle { get; set; }

        public UIElement()
        {
            LayoutStyle = GUIStyle.none;
        }

        public void Draw()
        {
            EditorGUILayout.BeginVertical(LayoutStyle);
            Content();
            EditorGUILayout.EndVertical();

        }

        protected abstract void Content();
    }
}
