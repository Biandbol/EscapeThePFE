using UnityEngine;

public class BookShelfPuzzleManager : MonoBehaviour
{
    /*public Transform[] bookSlots;         // Assign these in the Inspector
    public GameObject hole;               // Assign the door or moving object here

    private void Start()
    {
        // Optional: delay check to give time for scene setup or testing
        Invoke("CheckBooks", 2f);
    }

    public void CheckBooks()
    {
        bool isCorrect = true;

        string[] correctTags = { "cannae", "trasimane", "trebia", "zama" };

        for (int i = 0; i < bookSlots.Length; i++)
        {
            if (bookSlots[i].childCount == 0)
            {
                Debug.Log($"Slot {i} is empty.");
                isCorrect = false;
                break;
            }

            GameObject snappedBook = bookSlots[i].GetChild(0).gameObject;

            if (snappedBook.tag != correctTags[i])
            {
                Debug.Log($"Slot {i}: Expected {correctTags[i]}, found {snappedBook.tag}");
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            PuzzleSolved();
        }
        else
        {
            Debug.Log("Books are in the wrong order.");
        }
    }

    private void PuzzleSolved()
    {
        Debug.Log("Puzzle Solved! Secret Door Opens!");
        if (hole != null)
        {
            hole.transform.position += new Vector3(2f, 0, 0);
        }
        else
        {
            Debug.LogWarning("Hole object not assigned in inspector.");
        }
    }*/
    [System.Serializable]
    public struct SlotRequirement
    {
        public int slotIndex;
        public int requiredBookID;
    }

    [Header("Configuration")]
    public SlotRequirement[] slotRequirements; // Defines correct book for each slot

    [Header("References")]
    public GameObject secretDoor; // The object to move on success

    private int[] currentSlotStates; // Tracks which books are placed

    private void Start()
    {
        currentSlotStates = new int[slotRequirements.Length];
        for (int i = 0; i < currentSlotStates.Length; i++)
        {
            currentSlotStates[i] = -1; // -1 means empty
        }
    }

    public void ReportBookPlaced(int slotIndex, int bookID)
    {
        currentSlotStates[slotIndex] = bookID;
        CheckPuzzleSolution();
    }

    public void ReportBookRemoved(int slotIndex)
    {
        currentSlotStates[slotIndex] = -1;
    }

    private void CheckPuzzleSolution()
    {
        for (int i = 0; i < slotRequirements.Length; i++)
        {
            if (currentSlotStates[slotRequirements[i].slotIndex] != slotRequirements[i].requiredBookID)
            {
                return; // At least one slot is incorrect
            }
        }
        PuzzleSolved();
    }

    private void PuzzleSolved()
    {
        Debug.Log("✅ All books placed correctly!");
    }
    }
