using UnityEngine;
using static OVRPlugin;

public class bookSlot : MonoBehaviour
{
    [Header("Configuration")]
    public int slotIndex; // 0, 1, 2, etc. (matches order in BookPuzzleManager)
    public int expectedBookID; // Unique ID for the correct book

    [Header("References")]
    public BookShelfPuzzleManager puzzleManager;

    public bookSlotID currentBook; // Currently placed book (if any)

    private void OnTriggerEnter(Collider other)
    {
        bookSlotID book = other.GetComponent<bookSlotID>();
        if (book != null)
        {
            currentBook = book;
            puzzleManager?.ReportBookPlaced(slotIndex, book.bookID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bookSlotID book = other.GetComponent<bookSlotID>();
        if (book != null && book == currentBook)
        {
            currentBook = null;
            puzzleManager?.ReportBookRemoved(slotIndex);
        }
    }
}
