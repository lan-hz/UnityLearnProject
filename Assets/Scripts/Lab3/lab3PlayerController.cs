using UnityEngine;

public class lab3PlayerController : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    public float moveSpeed = 10.0f;
    Rigidbody rb;
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    Vector3 movement;
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement.x = moveHorizontal;
        movement.y = 0.0f;
        movement.z = moveVertical;

        rb.AddForce(movement.normalized * moveSpeed);
    }
}
