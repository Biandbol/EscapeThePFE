using UnityEngine;

public class LightManager : MonoBehaviour
{
    public GameObject lightSource;
    public ParticleSystem particles;
    private bool isActivated = false;
    public AudioSource fire;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("Lighter"))
        {
            Activate();
        }
    }

    private void Activate()
    {
        isActivated = true;

        if (lightSource != null)

            lightSource.SetActive(true);
        fire.Play();

        if (particles != null && !particles.isPlaying)
            particles.Play();
    }
}
