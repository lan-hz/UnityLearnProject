using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    Transform Bg0, Bg1;
    Vector2 size;
    Vector3 pos;

    float speed = 10f;

    void Start()
    {
        size = Bg0.GetComponent<SpriteRenderer>().bounds.size;

        pos.z = 4;
        pos.x = size.x * 0.5f - 10;
        pos.y = size.y * 0.5f;
        Bg0.position = pos;

        pos.x = size.x * 1.5f - 10;
        Bg1.position = pos;
    }
    void Update()
    {
        if (Type3PlayerController.Instance.gameOver)
            return;

        pos = Bg0.position;
        pos.x -= speed * Time.deltaTime;
        Bg0.position = pos;

        pos = Bg1.position;
        pos.x -= speed * Time.deltaTime;
        Bg1.position = pos;

        if (Bg0.position.x < -size.x * 0.5f - 10)
        {
            pos = Bg1.position;
            pos.x += size.x;
            Bg0.position = pos;
        }


        if (Bg1.position.x < -size.x * 0.5f - 10)
        {
            pos = Bg0.position;
            pos.x += size.x;
            Bg1.position = pos;
        }


    }
}