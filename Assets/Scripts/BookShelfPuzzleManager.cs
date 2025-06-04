using UnityEngine;
using UnityEngine.Audio;

public class BookShelfPuzzleManager : MonoBehaviour
{
    public bookSlot[] slots; // Make sure this is "BookSlot" (capital B)
    public Transform secretDoor;
    public float moveDistance = 2f;
    public AudioSource audioSource;
    public AudioClip stoneSlideSound;

    private Vector3 doorStartPosition;
    private bool isOpen = false;

    void Start()
    {
        doorStartPosition = secretDoor.position;
    }

    public void CheckIfPuzzleSolved()
    {
        foreach (bookSlot slot in slots)
        {
            Collider[] colliders = Physics.OverlapBox(
                slot.transform.position,
                Vector3.one * 0.1f
            );

            bool hasCorrectBook = false;
            foreach (Collider col in colliders)
            {
                if (col.CompareTag(slot.requiredTag))
                {
                    hasCorrectBook = true;
                    break;
                }
            }

            if (!hasCorrectBook) return;
        }

        OpenSecretDoor();
    }

    void OpenSecretDoor()
    {
        if (!isOpen)
        {
            // Move on Z-axis (forward/backward)
            secretDoor.position = doorStartPosition + new Vector3(0, 0, moveDistance);

            // Play sound
            if (audioSource != null && stoneSlideSound != null)
            {
                audioSource.PlayOneShot(stoneSlideSound);
            }

            isOpen = true;
            Debug.Log("Door moved on Z-axis!");
        }
    }
    /*public bookSlot[] slots; // Assign all 4 slots in Inspector
    public Transform secretDoor;
    public float moveDistance = 2f;
    public AudioSource audioSource;
    public AudioClip stoneSlideSound;


    private Vector3 doorStartPosition;
    private bool isOpen = false;

    void Start()
    {
        doorStartPosition = secretDoor.position;
    }

    public void CheckIfPuzzleSolved()
    {
        // Check all slots
        foreach (bookSlot slot in slots)
        {
            Collider[] colliders = Physics.OverlapBox(slot.transform.position, Vector3.one * 0.1f);
            bool hasCorrectBook = false;

            foreach (Collider col in colliders)
            {
                if (col.CompareTag(slot.requiredTag))
                {
                    hasCorrectBook = true;
                    break;
                }
            }

            if (!hasCorrectBook) return;
        }

        // If we get here, all slots are correct!
        OpenSecretDoor();
    }

    void OpenSecretDoor()
    {
        if (!isOpen)
        {
            secretDoor.position = doorStartPosition + new Vector3(0, 0, moveDistance);
            isOpen = true;
            audioSource.clip = stoneSlideSound;
            audioSource.Play();

        }
    }*/
}
