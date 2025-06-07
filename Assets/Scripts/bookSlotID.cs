using UnityEngine;

public class bookSlotID : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void ReturnToStart()
    {
        transform.position = startPosition;
    }
}
