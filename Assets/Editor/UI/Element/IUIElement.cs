using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public interface IUIElement
    {
        /// <summary>
        /// Element의 LayoutStyle을 설정합니다.(좌/우 정렬 등이 아닌 UI의 모양)
        /// </summary>
        GUIStyle Style { get; set; }

        /// <summary>
        /// 상위 Element혹은 UIEdiorWindow에 의해 매 OnDraw마다 호출되는 메소드입니다.
        /// UIElement를 그립니다.
        /// </summary>
        void Draw();
    }
}
