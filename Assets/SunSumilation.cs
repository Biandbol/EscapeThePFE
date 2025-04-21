using UnityEngine;

public class PointLightMover : MonoBehaviour
{
    public Transform centerPoint; // The center of the arc (e.g., the center of your scene or sky)
    public float radius = 10f;
    public float angleSpeed = 30f; // Degrees per second

    private float currentAngle = 0f;

    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveLeftKey = KeyCode.LeftArrow;

    void Start()
    {
        if (centerPoint == null)
        {
            // Default to world origin if not set
            GameObject center = new GameObject("LightArcCenter");
            center.transform.position = Vector3.zero;
            centerPoint = center.transform;
        }
    }

    void Update()
    {
        if (Input.GetKey(moveRightKey))
        {
            currentAngle += angleSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(moveLeftKey))
        {
            currentAngle -= angleSpeed * Time.deltaTime;
        }

        // Keep angle in 0–360 range
        currentAngle = currentAngle % 360f;

        // Convert angle to radians for Mathf trig functions
        float rad = currentAngle * Mathf.Deg2Rad;

        // Calculate new position along arc
        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;
        transform.position = centerPoint.position + offset;
    }
}
