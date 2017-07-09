using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GGM.Editor.UI;
using GGM.Editor.UI.Element;
using GGM.Editor.UI.Window;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

namespace GGM.Editor.Example
{
    class GGMTest : UIHeaderScrollWindow
    {
        public const string LabelFormat = "<color=#008000ff>{0}</color>  Test";

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
            for(int i = 0; i < 40; i++)
                _testDataList.Add(new TestData() { A = string.Format(LabelFormat, i) });
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
            private readonly UILabel _label = new UILabel();

            public TestVeiw(TestData data)
            {
                if(UnityEngine.Random.Range(0, 3) == 1)
                    BackgroundColor = Color.red;
                LayoutStyle = EditorStyles.textArea;
                Data = data;
                _label.Text = Data.A;
            }

            protected override void Content()
            {
                _label.Draw();
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
