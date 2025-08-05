using System;
using System.Collections.Generic;
using UnityEngine;

namespace lAnTool
{
    // 创建障碍物用的
    public class OtherCreate : MonoBehaviour
    {
        public GameObject[] prefabs;//障碍物
        public GameObject Road; //路

        string remoral = "Remora";
        public int count = 10; //创建数量
        List<GameObject> objs = new();
        System.Random random = new System.Random();


        void Start()
        {
            Road = GameObject.Find("Road");
            var meshSize = Road.GetComponent<MeshFilter>().sharedMesh.bounds.size;
            var sca = Road.transform.localScale;
            var len = meshSize.x * sca.x;

            count = Mathf.FloorToInt(len) / 5;

            var re = GameObject.Find(remoral);
            if (re == null)
            {
                re = new GameObject(remoral);
            }
            Vector3 pos = new();
            for (var i = 0; i < count; i++)
            {
                var z = random.Next(0, (int)len);
                var x = UnityEngine.Random.Range(-meshSize.z * 0.5f, meshSize.z);
                pos.x = x;
                pos.z = z;
                var key = random.Next(0, prefabs.Length);

                var c = Instantiate(prefabs[key], pos, default);
                c.transform.parent = re.transform;
                var r = c.AddComponent<Rigidbody>();
                r.mass = 0.2f;
                objs.Add(c);
            }
        }
        float time = 0;
        void Update()
        {
            if (time < 1)
            {
                time += Time.deltaTime;
            }
            else
            {
                time = 0;
                for (var i = 0; i < objs.Count; i++)
                {
                    var obj = objs[i];
                    if (obj.transform.position.y < -15)
                    {
                        Destroy(obj);
                        objs.Remove(obj);
                    }
                }
            }


        }
    }
}