using System.Collections.Generic;
using UnityEngine;

public class harpPuzzleManager : MonoBehaviour
{
    public string[] targetTune = { "do", "ré", "mi", "fa", "sol" }; // Target melody
    private List<string> playerInput = new List<string>();

    [Header("Reward/Penalty Objects")]
    public GameObject rewardPrefab; // Assign in Inspector (e.g., treasure chest)
    public GameObject penaltyPrefab; // Assign in Inspector (e.g., lock icon)
    public Transform spawnPoint; // Where objects will appear

    [Header("Audio")]
    public AudioClip successSound;
    public AudioClip failSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Called when a harp string is plucked
    public void PlayNote(string note)
    {
        playerInput.Add(note);
        CheckProgress();
    }

    private void CheckProgress()
    {
        if (playerInput.Count >= targetTune.Length)
        {
            bool isCorrect = true;
            for (int i = 0; i < targetTune.Length; i++)
            {
                if (playerInput[playerInput.Count - targetTune.Length + i] != targetTune[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                SpawnReward();
                playerInput.Clear();
            }
            else if (playerInput.Count > targetTune.Length * 2)
            {
                SpawnPenalty();
                playerInput.Clear();
            }
        }
    }

    private void SpawnReward()
    {
        if (rewardPrefab != null && spawnPoint != null)
        {
            Instantiate(rewardPrefab, spawnPoint.position, Quaternion.identity);
            audioSource.PlayOneShot(successSound);
            Debug.Log("Correct! Reward spawned.");
        }
    }

    private void SpawnPenalty()
    {
        if (penaltyPrefab != null && spawnPoint != null)
        {
            Instantiate(penaltyPrefab, spawnPoint.position, Quaternion.identity);
            audioSource.PlayOneShot(failSound);
            Debug.Log("Wrong! Penalty spawned.");
        }
    }
}
