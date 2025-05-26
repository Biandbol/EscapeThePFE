using Unity.VisualScripting;
using UnityEngine;

public class LightManagerr : MonoBehaviour
{
    
   
    public float rayDistance = 50f;
    public string targetTag = "lights"; // Change this tag as needed

    void Update()
    {
        // Cast a ray from the center of the screen
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Check if the hit object has the target tag
            if (hit.collider.CompareTag(targetTag))
            {
                transform.Find("FlamesParticleEffect").gameObject.SetActive(true);
                //hit.collider.gameObject.SetActive(true);
                Debug.Log("activated: " + hit.collider.gameObject.name);
            }
        }
    }
    }

