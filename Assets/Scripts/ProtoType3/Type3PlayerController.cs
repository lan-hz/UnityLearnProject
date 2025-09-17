using UnityEngine;

public class Type3PlayerController : MonoBehaviour
{

    Rigidbody PlayerRB;
    public float JumpForce = 2f;
    public float gravityModfier;
    public bool isOnGround = true;



    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModfier;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}
