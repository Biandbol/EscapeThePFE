using System.Collections.Generic;
using UnityEngine;

public class harpPuzzleManager : MonoBehaviour
{
    [Header("Target Sequence")]
    public string[] targetTune = { "do", "ré", "mi", "fa", "sol" }; // Note names must match tags

    [Header("Reward/Penalty")]
    public GameObject rewardPrefab;
    public GameObject penaltyPrefab;
    public Transform spawnPoint;

    private List<string> _playerInput = new List<string>();

    // Renamed from RegisterNote to PlayNote for consistency
    public void PlayNote(string note)
    {
        _playerInput.Add(note);
        Debug.Log($"[Puzzle] Received note: {note}");

        CheckProgress();
    }

    private void CheckProgress()
    {
        if (_playerInput.Count >= targetTune.Length)
        {
            bool isCorrect = true;
            for (int i = 0; i < targetTune.Length; i++)
            {
                if (_playerInput[_playerInput.Count - targetTune.Length + i] != targetTune[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect) SpawnReward();
            else if (_playerInput.Count > targetTune.Length * 2) SpawnPenalty();
        }
    }

    private void SpawnReward()
    {
        Instantiate(rewardPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("[Puzzle] Correct! Reward spawned.");
    }

    private void SpawnPenalty()
    {
        Instantiate(penaltyPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("[Puzzle] Wrong sequence! Penalty spawned.");
    }
}
