using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        // anima = GetComponent<Animator>();
    }

    Animator anima;
    float Horizontal;
    float Vertical;
    public float speed = 10;
    public float jumpforce = 10;
    Vector3 left = new();
    Vector3 right = new();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.SpawnFood(transform.position);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
             Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            // anima.Play("Run");
            Horizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Horizontal * speed * Time.deltaTime);
        }
        if (transform.position.x > jumpforce)
        {
            right.x = jumpforce;
            right.y = transform.position.y;
            right.z = transform.position.z;
            transform.position = right;
        }
        if (transform.position.x < -jumpforce)
        {
            left.x = -jumpforce;
            left.y = transform.position.y;
            left.z = transform.position.z;
            transform.position = left;
        }

    }
}
