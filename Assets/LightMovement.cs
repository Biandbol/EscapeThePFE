using UnityEngine;

public class SunMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float rotationSpeed = 10f;  // Speed of sun rotation
    public KeyCode moveUpKey = KeyCode.UpArrow;    // Key to move sun "up"
    public KeyCode moveDownKey = KeyCode.DownArrow; // Key to move sun "down"

    void Update()
    {
        // Rotate around X axis (up/down movement)
        if (Input.GetKey(moveUpKey))
        {
            // Rotate "up" - makes the sun appear to rise
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(moveDownKey))
        {
            // Rotate "down" - makes the sun appear to set
            transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
        }
    }
}