using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GGM.Editor.UI.Element;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.Example
{
    class GGMTest : UI.Window.UIScrollWindow
    {
        [MenuItem("Test/TestEditor")]
        public static void GGMTestEditor()
        {
            var window = GetWindow<GGMTest>();
            window.Show();
        }

        UIList _list = new UIList();

        protected override void Awake()
        {
            Debug.Log("On Awake");
            for (int i = 0; i < 30; i++)
            {
                var button = new UIButton("asdasd" + i);
                button.OnButtonClick += () => Debug.Log(button.Text);
                var foldOut = new UIFoldOut(button.Text+" : Fold out", button);
                foldOut.OnFoldStateChange += isOpen => Debug.Log(isOpen);
                _list.Add(foldOut);
            }


        }
        
        protected override void OnDestroy()
        {
            Debug.Log("On Destory");
        }

        protected override void Content()
        {
            _list.Draw();
        }
    }
}
