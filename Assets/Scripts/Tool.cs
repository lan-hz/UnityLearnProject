#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Tool : MonoBehaviour
{
    [ContextMenu("Get Scene Names")]
    void GetScenceNames()
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        var ins = SelfSceneManager.Instance;
        ins.SceneNames = new string[scenes.Length - 1];

        int index = 0;
        for (int i = 0; i < scenes.Length; i++)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(scenes[i].path);
            if (name == "Main") // 排除主场景
                continue;
            ins.SceneNames[index] = name;
            index++;
        }
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
    }
}

#endif