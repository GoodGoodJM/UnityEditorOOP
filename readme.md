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
```
