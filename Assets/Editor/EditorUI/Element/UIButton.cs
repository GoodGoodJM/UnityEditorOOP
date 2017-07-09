using System;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    //개발 진행중입니다.
    public class UIButton : UIElement
    {
        public UIButton()
        {
        }

        public UIButton(string text)
        {
            Text = text;
        }

        public UIButton(GUIStyle style)
        {
            LayoutStyle = style;
        }

        public UIButton(string text, GUIStyle style)
        {
            Text = text;
            LayoutStyle = style;
        }

        public string Text { get; set; }

        public Action OnButtonClick { get; set; }


        protected override void Content()
        {
            if (GUILayout.Button(Text))
                OnButtonClick.Execute();
        }
    }
}