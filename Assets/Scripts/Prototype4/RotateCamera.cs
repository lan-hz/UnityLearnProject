using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public GameObject FocalPoint;
    public float rotateSpeed = 10.0f;
    void Start()
    {

    }

    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        FocalPoint.transform.Rotate(Vector3.up, moveHorizontal * rotateSpeed * Time.deltaTime);
    }
}
