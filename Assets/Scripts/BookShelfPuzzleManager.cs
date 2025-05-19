using UnityEngine;

public class BookShelfPuzzleManager : MonoBehaviour
{
    public Transform[] bookSlots;         // Assign these in the Inspector
    public GameObject hole;               // Assign the door or moving object here

    private void Start()
    {
        // Optional: delay check to give time for scene setup or testing
        Invoke("CheckBooks", 2f);
    }

    public void CheckBooks()
    {
        bool isCorrect = true;

        string[] correctTags = { "Book10", "Book9", "Book8", "Book6", "Book5", "Book4", "Book3", "Book2", "Book1" };

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
    }
}

