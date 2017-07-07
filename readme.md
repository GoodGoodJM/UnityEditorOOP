# UnityEditorOOP
UnityEditorOOP는 다음과 같은 목적을 가진 소규모 프레임워크입니다.
- Unity의 Editor용 GUI을 좀더 OOP하게 구현해보자.
  - 기존의 EditorGUI는 OOP하지 못하였습니다.
- 코드를 깔끔하게 하자.
  - 기존의 EditorGUI는 너무 많은 중복코드와 임시코드를 만들게 하였습니다.
- 일관적인 UI를 만들게 하자.
  - EditorGUILayout, EditorGUI, EGUI, GUILayout등 사용자가 알기에 너무 많은 종류의 GUI를 그리는 방법이 있었습니다.
- 재사용성 좋게 만들자.
  - 기존의 EditorGUI는 재사용성 좋게 만들기 힘들었습니다.


프로젝트의 "Assets/Editor/Example/GGMTest.cs"에 예제가 있습니다.
```cs
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

public static class StringHelper
{
    public static bool IsNullOrEmpty(this string self)
    {
        return self == null || self == string.Empty;
    }
}
```
