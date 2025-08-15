using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager _instance;
    public static GameManager Instance => _instance;
    public GameObject[] food;
    public List<FoodCmd> foodList = new();
    public List<FoodCmd> foodTemp = new();
    public List<AnimalCmd> animalList = new();
    public List<AnimalCmd> animalTemp = new();

    public float Distance = Screen.height;
    public float foodspeed = 10;
    public GameObject[] animal;
    GameObject foodPool;
    GameObject animalPool;
    bool start = false;

    void Start()
    {
        _instance = this;
        Distance = 20;
        foodPool = new GameObject("foodPool");
        animalPool = new GameObject("animalPool");
    }

    public FoodCmd SpawnFood(Vector3 point)
    {
        if (!start) return null;

        for (var i = 0; i < foodList.Count; i++)
        {
            var cmd = foodList[i];
            if (!cmd.enable)
            {
                cmd.enable = true;
                cmd.obj.transform.position = point;
                foodTemp.Add(cmd);
                cmd.obj.SetActive(true);
                return cmd;
            }
        }

        var index = Random.Range(0, foodList.Count - 1);
        var obj = Instantiate(food[index], point, default);
        obj.transform.parent = foodPool.transform;
        var meshfilter = obj.GetComponent<MeshFilter>();
        var box = obj.AddComponent<BoxCollider>();
        box.size = meshfilter.sharedMesh.bounds.size;
        box.center = meshfilter.sharedMesh.bounds.center;
        var body = obj.AddComponent<Rigidbody>();
        body.useGravity = false;
        var cmd0 = new FoodCmd() { enable = true, obj = obj };
        foodList.Add(cmd0);
        foodTemp.Add(cmd0);
        return cmd0;
    }
    public AnimalCmd SpawnAnimal(Vector3 point)
    {
        if (!start) return null;

        for (var i = 0; i < animalList.Count; i++)
        {
            var cmd = animalList[i];
            if (!cmd.enable)
            {
                cmd.enable = true;
                animalTemp.Add(cmd);
                cmd.obj.transform.position = point;
                cmd.obj.SetActive(true);
                return cmd;
            }
        }

        var index = Random.Range(0, animalList.Count - 1);
        var obj = Instantiate(animal[index], point, new Quaternion(0, 180, 0, 0));
        obj.transform.parent = animalPool.transform;
        var Collections = obj.AddComponent<AnimalCollision>();
        var bounds = GetBounds(obj);
        var body = obj.AddComponent<BoxCollider>();
        body.size = bounds.size;
        body.center = Vector3.zero;
        body.isTrigger = true;

        var s = Random.Range(5, 10f);
        var cmd0 = new AnimalCmd() { enable = true, obj = obj, MoveSpeed = s };
        animalList.Add(cmd0);
        animalTemp.Add(cmd0);
        return cmd0;
    }
    Bounds GetBounds(GameObject obj)
    {
        Bounds combinedBounds = new Bounds();
        bool isFirstBounds = true;

        // 获取所有子节点的渲染器组件
        SkinnedMeshRenderer[] renderers = obj.GetComponentsInChildren<SkinnedMeshRenderer>(true);
        foreach (SkinnedMeshRenderer renderer in renderers)
        {
            Bounds rendererBounds = renderer.bounds;
            // 对包围盒的 min 和 max 坐标进行舍入操作，精度到 0.001
            rendererBounds.min = new Vector3(
                (float)System.Math.Round(rendererBounds.min.x, 3),
                (float)System.Math.Round(rendererBounds.min.y, 3),
                (float)System.Math.Round(rendererBounds.min.z, 3)
            );
            rendererBounds.max = new Vector3(
                (float)System.Math.Round(rendererBounds.max.x, 3),
                (float)System.Math.Round(rendererBounds.max.y, 3),
                (float)System.Math.Round(rendererBounds.max.z, 3)
            );

            if (isFirstBounds)
            {
                combinedBounds = rendererBounds;
                isFirstBounds = false;
            }
            else
            {
                // 合并包围盒
                combinedBounds.Encapsulate(rendererBounds);
            }
        }
        return combinedBounds;
    }

    float time = 0;
    float RandomTime = 1;
    Vector3 animalPoint = new();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            start = !start;
        }
        if (!start) return;

        if (time < RandomTime)
        { time += Time.deltaTime; }
        else
        {
            RandomTime = Random.Range(0.1f, 2);
            time = 0;
            animalPoint.x = Random.Range(-10, 10);
            animalPoint.z = 20;
            SpawnAnimal(animalPoint);
        }


        for (var i = 0; i < foodTemp.Count; i++)
        {
            var cmd = foodTemp[i];
            if (cmd.enable && cmd.obj.transform.position.z > Distance)
            {
                cmd.enable = false;
                foodTemp.Remove(cmd);
            }
            else
            {
                cmd.obj.transform.position += Vector3.forward * foodspeed * Time.deltaTime;
            }
        }

        for (var i = 0; i < animalTemp.Count; i++)
        {
            var cmd = animalTemp[i];
            if (cmd.enable && cmd.obj.transform.position.z < -4)
            {
                cmd.enable = false;
                animalTemp.Remove(cmd);
                Debug.Log("Game Over");
            }
            else
            {
                cmd.obj.transform.position -= Vector3.forward * cmd.MoveSpeed * Time.deltaTime;
            }
        }
    }

    GUIStyle style;
    public Font font;
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
            background.SetPixel(0, 0, Color.gray); // 蓝色背景
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
        float y = Screen.height - buttonHeight - 50f;
        if (GUI.Button(new Rect(x, y, buttonWidth, buttonHeight), "S 键 开始/暂停", style))
        {
            start = !start;
        }
    }

}

public class AnimalCmd
{
    public bool enable;
    public GameObject obj;
    public float MoveSpeed;
}

public class FoodCmd
{
    public bool enable;
    public GameObject obj;
}
