using System;
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
        public Rect LayoutRect { get; set; }
        public Action OnSizeChange { get; set; }

        public void Draw()
        {
            var previousColor = GUI.backgroundColor;

            GUI.backgroundColor = BackgroundColor;
            EditorGUILayout.BeginVertical(LayoutStyle);
            GUI.backgroundColor = previousColor;
            Content();
            GUI.backgroundColor = BackgroundColor;
            EditorGUILayout.EndVertical();
            if (Event.current.type == EventType.Repaint)
            {
                var privious = LayoutRect;
                LayoutRect = GUILayoutUtility.GetLastRect();
                if (privious != default(Rect) && privious.size != LayoutRect.size)
                        OnSizeChange.Execute();
                
            }
            GUI.backgroundColor = previousColor;
        }

        protected abstract void Content();
    }
}