using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GhostSoul.Editor.EnhancedLogConsole.Elements;
using Global.Constants;
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
        public Rect ViewRect { get; set; }

        public bool IsRefreshed { get; set; }

        protected override void Content()
        {
            var filterdElements = Elements.Where(CheckCanDraw).ToList();

            if (ViewRect == default(Rect))
            {
                foreach (var child in filterdElements)
                {
                    child.Draw();
                    GUILayout.Space(SpaceSize);
                }
            }
            else
            {
                if (!IsRefreshed)
                    DrawForRefresh(filterdElements);
                else
                    DrawCulling(filterdElements);
            }
        }

        private void DrawForRefresh(List<ElementView> filterdElements)
        {
            foreach (var child in filterdElements)
            {
                child.Draw();
                if (Event.current.type != EventType.Repaint)
                    child.LayoutRect = default(Rect);
                GUILayout.Space(SpaceSize);
            }
            if (Event.current.type == EventType.Repaint)
                IsRefreshed = true;
        }

        private void DrawCulling(List<ElementView> filterdElements)
        {
            float topSpaceHeight = 0;
            float bottomSpaceHeight = 0;
            var showedElements = new List<ElementView>();
            UIElement lastShowedElement = null;
            foreach (var element in filterdElements)
            {
                if (element.LayoutRect.yMax < ViewRect.y)
                    topSpaceHeight = element.LayoutRect.yMax;
                else if (element.LayoutRect.yMax > ViewRect.y && element.LayoutRect.y < ViewRect.yMax)
                    showedElements.Add(element);
                else
                    bottomSpaceHeight = element.LayoutRect.yMax;
            }

            GUILayout.Space(topSpaceHeight);
            foreach (var element in showedElements)
            {
                element.Draw();
                GUILayout.Space(SpaceSize);
                lastShowedElement = element;
            }
            if (lastShowedElement != null)
            {
                float bottomSpace = bottomSpaceHeight - lastShowedElement.LayoutRect.yMax;
                if (bottomSpace > 0f)
                    GUILayout.Space(bottomSpace);
            }
        }

        protected virtual bool CheckCanDraw(ElementView elementView)
        {
            return true;
        }

        public void SetElements(List<T> elementDataList)
        {
            Elements.Clear();
            foreach (var data in elementDataList)
            {
                var view = CreateChild(data);
                Debugs.Assert(view != null);
                Elements.Add(view);
                view.OnSizeChange += () => IsRefreshed = false;
            }

            IsRefreshed = false;
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
}