using Unity.VisualScripting;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public Transform sun; // Assign your Directional Light
    public Transform pivotPoint; // Center of sundial
    public float rotationSpeed = 10f; // Degrees per second
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
 public void RotateRight() {

        sun.RotateAround(pivotPoint.position, Vector3.right, rotationSpeed * Time.deltaTime);
        sun.LookAt(pivotPoint.position);

    }
    public void RotateLedt()
    {

        sun.RotateAround(pivotPoint.position, Vector3.right, -rotationSpeed * Time.deltaTime);
        sun.LookAt(pivotPoint.position);

    }

}
