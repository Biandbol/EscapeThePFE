using UnityEngine;
using static OVRPlugin;

public class bookSlot : MonoBehaviour
{
    public string requiredTag; // Set to "Book1", "Book2" etc. in Inspector
    public BookShelfPuzzleManager manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            // Snap book into place
            other.transform.position = transform.position;
            manager.CheckIfPuzzleSolved();
        }
        else if (other.GetComponent<bookSlotID>() != null)
        {
            // Return wrong book
            other.GetComponent<bookSlotID>().ReturnToStart();
        }
    }

}
