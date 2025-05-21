using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class wineAnimation : MonoBehaviour
{
    public MeshRenderer wineRenderer;
    public string pestleTag = "pestle";
    public string grapeTag = "grape";

    void Start()
    {
        wineRenderer.enabled = false; // Start hidden
    }

    // Simple collision check
    void OnCollisionEnter(Collision collision)
    {
        // Check if collision involves both pestle and grape
        bool pestleHit = collision.gameObject.CompareTag(pestleTag);
        bool grapeHit = collision.gameObject.CompareTag(grapeTag);

        if (pestleHit || grapeHit)
        {
            // Find the other object in the collision pair
            GameObject otherObject = pestleHit ?
                collision.contacts[0].otherCollider.gameObject :
                collision.gameObject;

            // Check if it's the counterpart tag
            if ((pestleHit && otherObject.CompareTag(grapeTag)) ||
                (grapeHit && otherObject.CompareTag(pestleTag)))
            {
                wineRenderer.enabled = true; // Make wine visible

                // Optional: Destroy the grape
                if (grapeHit) Destroy(collision.gameObject);
                else Destroy(otherObject);
            }
        }
    }
}
