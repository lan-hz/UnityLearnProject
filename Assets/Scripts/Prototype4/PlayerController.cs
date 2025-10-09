using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject player;
    public GameObject FocalPoint;
    Rigidbody rb;
    public float speed = 10.0f;
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    Vector3 move;
    void Update()
    {
        var moveVertical = Input.GetAxis("Vertical");

        // var moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(FocalPoint.transform.forward * speed * moveVertical);
    }
}
