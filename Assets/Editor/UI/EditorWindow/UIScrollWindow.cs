using System;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Window
{
    [Flags]
    public enum ScrollType : byte
    {
        None = 0,
        AlwaysShowHorizontal = 1 << 0,
        AlwaysShowVertical = 1 << 1,
        AlwaysShowHorizontalAndVertical = 1 << 2
    }
    
    public abstract class UIScrollWindow : UIEditorWindow
    {
        protected UIScrollWindow()
        {
            ScrollType = ScrollType.AlwaysShowHorizontalAndVertical;
        }

        protected Vector2 _scrollPosition = Vector2.zero;
        public ScrollType ScrollType { get; set; }

        public GUILayoutOption HorizontalScrollbarOption { get { return GUILayout.Height(position.height); } }
        public GUILayoutOption VerticalScrollbarOption { get { return GUILayout.Width(position.width); } }

        public override void Draw()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, ScrollType.HasFlag(ScrollType.AlwaysShowHorizontal), ScrollType.HasFlag(ScrollType.AlwaysShowVertical), HorizontalScrollbarOption, VerticalScrollbarOption);
            base.Draw();
            EditorGUILayout.EndScrollView();
        }
    }

#if UNITY_2017
    //2017의 .net버전을 낮게했을때 MissingHelper가 없기때문에 억지로 작성
    public static class EnumHelperFor2017
    {
        public static bool HasFlag(this ScrollType self, ScrollType flag)
        {
            return (self & flag) != 0;
        }
    }
#endif
}