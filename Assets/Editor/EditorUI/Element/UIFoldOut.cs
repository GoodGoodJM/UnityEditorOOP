using System;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element
{
    public class UIFoldOut : UIElement
    {
        public GUIStyle ContentStyle { get; set; }
        public Color FontColor { get { return ContentStyle.normal.textColor; } set { ContentStyle.normal.textColor = value; } }

        public virtual string ContentLabel { get; set; }
        public virtual bool IsFoldOpened { get; set; }
        public virtual IUIElement ContentElement { get; set; }

        public Action<bool> OnFoldStateChange { get; set; }

        public UIFoldOut()
        {
            LayoutStyle = EditorStyles.textArea;
            ContentStyle = EditorStyles.foldout;
        }

        public UIFoldOut(string contentLabel, UIElement contentElement, bool isFoldOpened = false)
        {
            LayoutStyle = EditorStyles.textArea;
            ContentStyle = EditorStyles.foldout;
            SetContents(contentLabel, contentElement, isFoldOpened);
        }

        public void SetContents(string contentLabel, UIElement contentElement, bool isFoldOpened)
        {
            ContentLabel = contentLabel;
            ContentElement = contentElement;
            IsFoldOpened = isFoldOpened;
        }

        protected override void Content()
        {
            bool beforeState = IsFoldOpened;
            IsFoldOpened = EditorGUILayout.Foldout(IsFoldOpened, ContentLabel, ContentStyle);

            if (beforeState != IsFoldOpened)
                OnFoldStateChange.Execute(IsFoldOpened);

            if (IsFoldOpened)
                FoldOpened();
            else
                FoldClosed();

        }

        protected virtual void FoldOpened()
        {
            if(ContentElement != null)
                ContentElement.Draw();
        }

        protected virtual void FoldClosed() { }
    }
}