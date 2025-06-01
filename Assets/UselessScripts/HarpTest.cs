using UnityEngine;
using System.Collections.Generic;

public class HarpTest : MonoBehaviour
{
    [Header("String Settings")]
    public string note; // e.g., "do", "ré"
    public AudioClip noteSound;
    public harpPuzzleManager puzzleManager;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /*private void OnMouseDown()
    {
        PlayNote();
    }*/

    public void PlayNote()
    {
        if (noteSound != null)
            _audioSource.PlayOneShot(noteSound);

        if (puzzleManager != null)
        {
            puzzleManager.RegisterNote(note);
        }

        Debug.Log($"[String] Played note: {note}");
    }
}
