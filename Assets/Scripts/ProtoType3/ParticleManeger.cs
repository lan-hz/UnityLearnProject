using UnityEngine;


public class ParticleManeger : MonoBehaviour
{
    public ParticleSystem Smoke;
    public ParticleSystem DirtSplatter;

    public static ParticleManeger Instance;
    void Awake()
    {
        Instance = this;
    }
    public void StartSmoke()
    {
        Smoke.Play();
    }
    public void StartDirtSplatter()
    {
        DirtSplatter.Play();
    }
    public void StopSmoke()
    {
        Smoke.Stop();
    }
    public void StopDirtSplatter()
    {
        DirtSplatter.Stop();
    }

}
