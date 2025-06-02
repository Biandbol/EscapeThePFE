using System.Collections.Generic;
using UnityEngine;

public class harpPuzzleManager : MonoBehaviour
{
    [Header("Target Sequence")]
    public string[] targetTune = { "do", "ré", "mi", "fa", "sol" };

    [Header("Reward/Penalty")]
    public GameObject rewardPrefab;
    public GameObject penaltyPrefab;
    public Transform spawnPoint;

    private List<string> _playerInput = new List<string>();

    public void RegisterNote(string note)
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

            int start = _playerInput.Count - targetTune.Length;
            for (int i = 0; i < targetTune.Length; i++)
            {
                if (_playerInput[start + i] != targetTune[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                SpawnReward();
                _playerInput.Clear(); // reset after success
            }
            else if (_playerInput.Count > targetTune.Length * 2)
            {
                SpawnPenalty();
                _playerInput.Clear(); // reset after fail
            }
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
