using System.Collections.Generic;
using UnityEngine;

public class harpPuzzleManager : MonoBehaviour
{
    [Header("Target Sequence")]
    public string[] targetTune = { "do", "ré", "mi", "fa", "sol" };

    [Header("Reward")]
    public GameObject rewardPrefab;
    public Transform spawnPoint;

    private List<string> _playerInput = new List<string>();
    private bool _rewardSpawned; // Tracks if reward was already given

    public void RegisterNote(string note)
    {
        if (_rewardSpawned) return; // Ignore input after solving

        _playerInput.Add(note);
        Debug.Log($"[Puzzle] Received note: {note}");

        CheckProgress();
    }

    private void CheckProgress()
    {
        if (_playerInput.Count >= targetTune.Length)
        {
            bool isCorrect = true;

            int start = _playerInput.Count - targetTune.Length;
            for (int i = 0; i < targetTune.Length; i++)
            {
                if (_playerInput[start + i] != targetTune[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect && !_rewardSpawned)
            {
                SpawnReward();
                _rewardSpawned = true; // Mark as completed
                _playerInput.Clear();
            }
            else if (_playerInput.Count > targetTune.Length * 2)
            {
                _playerInput.Clear(); // Reset attempts without penalty
            }
        }
    }

    private void SpawnReward()
    {
        if (rewardPrefab && spawnPoint)
        {
            Instantiate(rewardPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("[Puzzle] Correct! Reward spawned.");
        }
    }

    // Call this if you want to reset the puzzle
    public void ResetPuzzle()
    {
        _rewardSpawned = false;
        _playerInput.Clear();
    }
}
