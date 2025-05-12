using UnityEngine;

public class BookShelfPuzzleManager : MonoBehaviour
{
    public Transform[] bookSlots;
    //public Animator hole; 
    private GameObject hole;

    public void CheckBooks()
    {
        bool isCorrect = true;

        
        string[] correctTags = { "Book10", "Book9", "Book8", "Book7", "Book6", "Book5", "Book4", "Book3", "Book2", "Book1" };

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
        /*if (hole != null)
        {
            hole.SetTrigger("Open");
        }*/
        hole.transform.position += new Vector3 (2f, 0, 0);
    }
}

