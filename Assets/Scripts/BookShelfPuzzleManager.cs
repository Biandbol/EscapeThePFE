using UnityEngine;

public class BookShelfPuzzleManager : MonoBehaviour
{
    public Transform[] bookSlots; 
    public Animator hole; 

    public void CheckBooks()
    {
        bool isCorrect = true;

        
        string[] correctTags = { "book1", "book4", "book3", "book2" };

        for (int i = 0; i < bookSlots.Length; i++)
        {
            if (bookSlots[i].childCount == 0)
            {
                isCorrect = false;
                break;
            }

            GameObject snappedBook = bookSlots[i].GetChild(0).gameObject;

            if (snappedBook.tag != correctTags[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            PuzzleSolved();
        }
    }

    private void PuzzleSolved()
    {
        Debug.Log("Puzzle Solved! Secret Door Opens!");

        // Play door animation
        if (hole != null)
        {
            hole.SetTrigger("Open");
        }
    }
}

