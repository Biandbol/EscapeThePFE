using UnityEngine;

public class ParticleTester : MonoBehaviour
{
    public ParticleSystem testParticles;
    void Start()
    {
        testParticles.Play();
        Debug.Log("Particles should be visible NOW");
    }
}
