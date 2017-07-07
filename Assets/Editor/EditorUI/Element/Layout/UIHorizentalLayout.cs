
















































using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace GGM.Editor.UI.Element.Layout
{
    public class UIHorizentalLayout: UIList
    {
        protected override void Content()
        {
            EditorGUILayout.BeginHorizontal(GUIStyle.none);
            base.Content();
            EditorGUILayout.EndVertical();

        }
    }
}
