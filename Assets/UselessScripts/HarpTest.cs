using UnityEngine;
using System.Collections.Generic;

public class HarpTest : MonoBehaviour
{
    /*[Header("Settings")]
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
    }*/
    [Header("String Settings")]
    public string note; // e.g., "do", "r�"
    public AudioClip noteSound;
    public harpPuzzleManager puzzleManager;

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
        if (noteSound != null)
            _audioSource.PlayOneShot(noteSound);

        if (puzzleManager != null)
        {
            puzzleManager.RegisterNote(note);
        }

        Debug.Log($"[String] Played note: {note}");
    }
}
