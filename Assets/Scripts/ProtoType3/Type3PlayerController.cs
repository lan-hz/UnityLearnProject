using Unity.VisualScripting;
using UnityEngine;

public class Type3PlayerController : MonoBehaviour
{

    public Transform Player;
    Rigidbody PlayerRB;
    public float JumpForce = 2f;
    public float gravityModfier;
    public bool isOnGround = true;
    Animator animator;
    public AudioClip[] audios;
    AudioSource audioSource;

    public bool gameOver = false;
    public static Type3PlayerController Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PlayerRB = Player.GetComponent<Rigidbody>();
        Physics.gravity *= gravityModfier;

        animator = Player.GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        DoRun();

    }

    private void DoRun()
    {
        animator.SetFloat("Speed_f", 1.0f);
        animator.SetBool("Static_b", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && isOnGround)
        {
            PlayerRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            ParticleManeger.Instance.StopDirtSplatter();
            audioSource.PlayOneShot(audios[1], 1.0f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            ParticleManeger.Instance.StartDirtSplatter();
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("gameOver");
            gameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            ParticleManeger.Instance.StartSmoke();
            ParticleManeger.Instance.StopDirtSplatter();
            audioSource.PlayOneShot(audios[2], 1.0f);
        }
    }
}
