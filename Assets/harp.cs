using UnityEngine;

public class harp : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        
            audioSource.Play();
        
    }
}


