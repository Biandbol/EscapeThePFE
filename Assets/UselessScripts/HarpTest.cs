using UnityEngine;

public class HarpTest : MonoBehaviour
{
    [Header("Settings")]
    public string note; // Set this in Inspector (e.g., "Do", "Re")
    public AudioClip noteSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        PlayNote();
    }

    public void PlayNote()
    {
        _audioSource.PlayOneShot(noteSound);
        FindObjectOfType<harpPuzzleManager>().PlayNote(note); // Now matches!
        Debug.Log($"[String] Played note: {note}");
    }
}
