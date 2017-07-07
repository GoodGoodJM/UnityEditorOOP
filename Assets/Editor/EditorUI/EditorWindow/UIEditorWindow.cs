using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Window
{
    /// <summary>
    /// 실제 에디터를 띄우는 클래스입니다. 상속받는 모든 클래스는 반드시 부모클래스의 생성자를 호출해주어야 합니다.
    /// </summary>
    public abstract class UIEditorWindow : EditorWindow
    {
        public virtual GUIStyle Style { get; set; }

        protected UIEditorWindow()
        {
            Style = EditorStyles.textArea;
        }

        public virtual void Draw()
        {
            EditorGUILayout.BeginVertical(Style);
            Content();
            EditorGUILayout.EndVertical();
        }

        protected abstract void Awake();

        protected virtual void OnGUI() { Draw(); }

        protected abstract void OnDestroy();

        protected abstract void Content();
    }
}