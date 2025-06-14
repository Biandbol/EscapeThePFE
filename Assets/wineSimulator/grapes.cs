using UnityEngine;
using System.Collections;

public class grapes : MonoBehaviour
{
    public ParticleSystem juiceParticles;
    public MeshRenderer wineRenderer;
    //public Collider wineCollider;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("pestle")) // Tag pestle instead
        {
            juiceParticles.Play();
            juiceParticles.Emit(10);

            Destroy(gameObject, 0.5f);
            if (wineRenderer != null)
                wineRenderer.enabled = true;
            //wineCollider.enabled = true;
        }
    }

    public void Crush()
    {
        Debug.Log("Crush called"); // Check if method runs

        if (juiceParticles == null)
            Debug.LogError("Particle System not assigned!");
        else
        {
            juiceParticles.Play();
            Debug.Log("Particles should play now");
        }

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 20f);
    }
}