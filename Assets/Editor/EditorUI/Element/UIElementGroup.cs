using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public abstract class UIElementGroup<T> : UIElement
    {
        protected UIElementGroup()
        {
            Elements = new List<ElementView>();
            LayoutStyle = EditorStyles.textArea;
            SpaceSize = 8;
        }

        public int SpaceSize { get; set; }
        public List<ElementView> Elements { get; private set; }

        protected override void Content()
        {
            foreach (var child in Elements)
                if (CheckCanDraw(child))
                {
                    child.Draw();
                    GUILayout.Space(SpaceSize);
                }
        }

        protected virtual bool CheckCanDraw(ElementView elementView)
        {
            return true;
        }

        /// <summary>
        ///     List 데이터를 넣어줌으로서 view를 지정합니다.
        ///     이전의 모델과 비교해서 추가, 제거된 부분만 적용합니다.
        ///     만일 형식 매개변수 T가 value타입일 경우에는 반드시 Equals를 오버라이딩 해주어야 합니다. 만일 그렇지 않으면 대량의 GC가 발생할 수 있습니다.
        /// </summary>
        /// <param name="elementDataList"></param>
        public void SetElements(List<T> elementDataList)
        {
            foreach (var element in Elements)
                if (!elementDataList.Contains(element.Data))
                    Elements.Remove(element);

            foreach (var elememtData in elementDataList)
                if (!Elements.IsContains(elememtData))
                    Elements.Add(CreateChild(elememtData));
        }

        /// <summary>
        ///     Children에 들어갈 ElementView를 생성합니다. 사용자는 반드시 이 메소드를 상속받아 구현하여야합니다.
        /// </summary>
        /// <param name="Data">element에 들어갈 데이터</param>
        /// <returns></returns>
        protected abstract ElementView CreateChild(T data);

        public abstract class ElementView : UIElement
        {
            public T Data { get; set; }
        }
    }

    public static class ElementViewHelper
    {
        public static bool IsContains<T>(this List<UIElementGroup<T>.ElementView> self, T data)
        {
            foreach (var elementView in self)
                if (elementView.Data.Equals(data))
                    return true;

            return false;
        }
    }
}