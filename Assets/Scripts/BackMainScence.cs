using UnityEngine;

public class BackMainScence : MonoBehaviour
{
    public Font font;
    GUIStyle style;
    void OnGUI()
    {
        if (style == null)
        {
            style = new GUIStyle();
            style.font = font;
            style.fontSize = 16;
            style.normal.textColor = Color.white;

            // 创建一个白色背景
            Texture2D background = new Texture2D(1, 1);
            background.SetPixel(0, 0, Color.gray); // 灰色背景
            background.Apply();
            style.normal.background = background;

            // 可选：设置边框、内边距
            style.padding = new RectOffset(15, 15, 5, 5);
            style.alignment = TextAnchor.MiddleCenter;
            style.wordWrap = false;
        }

        float buttonWidth = 100f;
        float buttonHeight = 30f;
        float x = Screen.width - buttonWidth - 10f;
        float y = Screen.height - buttonHeight - 10f;
        if (GUI.Button(new Rect(x, y, buttonWidth, buttonHeight), "返回主场景", style))
        {
            SelfSceneManager.Instance.ReturnToMainScene();
        }
    }
}
