using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    //TODO: 이름이 비 직관적임. 추후 수정할 것.
    /// <summary>
    /// UIElement들을 리스트로 가지며 그려주는 클래스입니다.
    /// </summary>
    public class UIList : UIElementGroup
    {
        private const int SPACE_SIZE = 16;
        public int SpaceSize { get; set; }

        public UIList()
        {
            SpaceSize = SPACE_SIZE;
            Style = EditorStyles.textArea;
        }

        protected override void Content()
        {
            foreach (UIElement child in Children)
            {
                child.Draw();
                GUILayout.Space(SpaceSize);
            }
        }
    }
}