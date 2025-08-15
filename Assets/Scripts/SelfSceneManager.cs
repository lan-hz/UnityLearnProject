using UnityEngine;


using UnityEngine.SceneManagement;

public class SelfSceneManager : MonoBehaviour
{
    public static SelfSceneManager Instance;
    public string[] SceneNames;
    public Font font;
    GUIStyle style;
    void Start()
    {
        Instance = this;
    }

    void OnGUI()
    {
        if (SceneNames == null || SceneNames.Length == 0)
            return;

        if (style == null)
        {
            style = new GUIStyle();
            style.font = font;
            style.fontSize = 24;
            style.normal.textColor = Color.white;

            // 创建一个白色背景
            Texture2D background = new Texture2D(1, 1);
            background.SetPixel(0, 0, Color.gray); // 蓝色背景
            background.Apply();
            style.normal.background = background;

            // 可选：设置边框、内边距
            style.padding = new RectOffset(15, 15, 5, 5);
            style.alignment = TextAnchor.MiddleCenter;
            style.wordWrap = false;
        }

        int buttonWidth = 200;
        int buttonHeight = 40;
        int spacing = 10;
        int totalHeight = SceneNames.Length * buttonHeight + (SceneNames.Length - 1) * spacing;
        int startY = (Screen.height - totalHeight) / 2;
        int startX = (Screen.width - buttonWidth) / 2;

        for (int i = 0; i < SceneNames.Length; i++)
        {
            if (GUI.Button(new Rect(startX, startY + i * (buttonHeight + spacing), buttonWidth, buttonHeight), SceneNames[i], style))
            {
                SwitchToScene(SceneNames[i]);
            }
        }
    }

    // 切换到指定场景 资源
    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 返回主场景（假设主场景名为 "MainScene"）
    public void ReturnToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}