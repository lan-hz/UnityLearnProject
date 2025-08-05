using UnityEngine;

namespace lAnTool
{
    public class PlayerController : MonoBehaviour
    {

        void Start()
        {
            body = GetComponent<Rigidbody>();
            if (body == null)
            {
                body = gameObject.AddComponent<Rigidbody>();
            }

        }
        Rigidbody body;
        public float LineSpeed = 10;
        public float RotateSpeed = 10;
        public float horizontalInput;
        public float verticalInput;
        void Update()
        {

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            transform.Translate(transform.forward * LineSpeed * Time.deltaTime * verticalInput);

            transform.Rotate(transform.up * RotateSpeed * Time.deltaTime * horizontalInput);


        }
    }

}