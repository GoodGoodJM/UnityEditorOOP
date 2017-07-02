using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public abstract class UIElement : IUIElement
    {
        public GUIStyle Style { get; set; }

        public void Draw()
        {
            EditorGUILayout.BeginVertical(Style);
            EditorGUI.indentLevel++;
            Content();
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();

        }

        protected abstract void Content();
    }
}
