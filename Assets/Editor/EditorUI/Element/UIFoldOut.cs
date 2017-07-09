using System;
using UnityEditor;

namespace GGM.Editor.UI.Element
{
    public class UIFoldOut : UITextElement
    {
        public UIFoldOut()
        {
            LayoutStyle = EditorStyles.textArea;
            ContentStyle = EditorStyles.foldout;
            IsAllowRichText = true;
        }

        public UIFoldOut(string contentLabel, UIElement contentElement, bool isFoldOpened = false)
        {
            LayoutStyle = EditorStyles.textArea;
            ContentStyle = EditorStyles.foldout;
            IsAllowRichText = true;
            SetContents(contentLabel, contentElement, isFoldOpened);
        }

        public virtual bool IsFoldOpened { get; set; }
        public virtual IUIElement ContentElement { get; set; }

        public Action<bool> OnFoldStateChange { get; set; }

        public void SetContents(string text, UIElement contentElement, bool isFoldOpened)
        {
            Text = text;
            ContentElement = contentElement;
            IsFoldOpened = isFoldOpened;
        }

        protected override void Content()
        {
            var beforeState = IsFoldOpened;

            var foldoutStyle = EditorStyles.foldout;
            foldoutStyle.richText = true;
            IsFoldOpened = EditorGUILayout.Foldout(IsFoldOpened, Text, ContentStyle);

            if (beforeState != IsFoldOpened)
                OnFoldStateChange.Execute(IsFoldOpened);

            if (IsFoldOpened)
                FoldOpened();
            else
                FoldClosed();
        }

        protected virtual void FoldOpened()
        {
            if (ContentElement != null)
                ContentElement.Draw();
        }

        protected virtual void FoldClosed()
        {
        }
    }
}