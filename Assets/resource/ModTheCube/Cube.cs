using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        Material material = Renderer.sharedMaterial;

        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }

    float x = 1;
    float y = 1;
    float z = 1;
    float w = 1;
    float speed;

    float time = 0;

    Vector3 size = new();
    Color color = new();
    void Update()
    {



        if (time < 5)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            size.x = x;
            size.y = y;
            size.z = z;
            transform.localScale = size;
            x = Random.Range(-5.0f, 5.0f);
            y = Random.Range(-5.0f, 5.0f);
            z = Random.Range(-5.0f, 5.0f);
            size.x = x;
            size.y = y;
            size.z = z;
            transform.position = size;

            x = Random.Range(0f, 1f);
            y = Random.Range(0f, 1f);
            z = Random.Range(0f, 1f);
            w = Random.Range(0f, 1f);
            color.r = x;
            color.g = y;
            color.b = z;
            color.a = w;
            Renderer.sharedMaterial.color = color;

            x = Random.Range(-5f, 5.0f);
            y = Random.Range(-5f, 5.0f);
            z = Random.Range(-5f, 5.0f);

        }

        speed = Random.Range(0, 10f);
        transform.Rotate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, z * speed * Time.deltaTime);


    }
}
