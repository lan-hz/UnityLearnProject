using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{

    public GameObject prefab;
    public float speed = 10;
    public float delay = 5;
    float time = 0;
    float x = 45;
    void Start()
    {

    }

    void Update()
    {
        if (Type3PlayerController.Instance.gameOver)
            return;
        if (time < delay)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            GameObject obj = Spawn();
            var pos = Vector3.zero;
            pos.x = x;
            obj.transform.position = pos;
        }
        for (var i = 0; i < poolList.Count; i++)
        {
            var obj = poolList[i];
            if (obj.activeSelf == false)
                continue;
            var pos = obj.transform.position;

            if (pos.x < -5f)
                obj.SetActive(false);
            else
            {
                pos.x -= speed * Time.deltaTime;
                obj.transform.position = pos;
            }
        }
    }
    List<GameObject> poolList = new List<GameObject>();

    GameObject Spawn()
    {
        if (poolList.Count > 0)
            for (var i = 0; i < poolList.Count; i++)
            {
                var obj = poolList[i];
                if (obj.activeSelf == false)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

        GameObject go = Instantiate(prefab);
        go.transform.parent = transform;
        poolList.Add(go);
        return go;
    }
}
