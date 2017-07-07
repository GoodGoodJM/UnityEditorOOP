using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GGM.Editor.UI.Element;
using GGM.Editor.UI.Window;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

namespace GGM.Editor.Example
{
    class GGMTest : UIHeaderScrollWindow
    {
        [MenuItem("Test/TestEditor")]
        public static void GGMTestEditor()
        {
            var window = GetWindow<GGMTest>();
            window.ScrollType = ScrollType.AlwaysShowHorizontalAndVertical;
            window.Show();
        }

        UIList _list = new UIList();
        List<TestData> _testDataList = new List<TestData>();
        UITextField _filterTextField = new UITextField();

        protected override void Awake()
        {
            HeaderElement = _filterTextField;
            _filterTextField.OnTextChange += text => _list.FilterText = text;
            for(int i = 0; i < 20; i++)
                _testDataList.Add(new TestData() { A = i.ToString() });
            _list.SetElements(_testDataList);
            Profiler.EndSample();
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

    public class TestData
    {
        public string A { get; set; }
    }

    public class UIList : UIFilterGroup<TestData>
    {
        protected override ElementView CreateChild(TestData data)
        {
            return new TestVeiw(data);
        }

        protected override bool CheckCanDraw(ElementView elementView)
        {
            return base.CheckCanDraw(elementView) || elementView.Data.A.Contains(FilterText);
        }

        public class TestVeiw : ElementView
        {
            public TestVeiw(TestData data)
            {
                LayoutStyle = EditorStyles.textArea;
                Data = data;
            }

            protected override void Content()
            {
                EditorGUILayout.LabelField(Data.A);
            }
        }
    }
#if !GHOSTSOUL
    public static class StringHelper
    {
        public static bool IsNullOrEmpty(this string self)
        {
            return self == null || self == string.Empty;
        }
    }
#endif
}
