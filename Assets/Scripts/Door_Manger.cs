using System.IO.Compression;
using UnityEngine;

public class Door_Manger : MonoBehaviour
{
    public Transform door1;
    public Transform leftnob;
    public Transform rightnob;
    public Transform door2;
    public float x1rotation;
    public float x2rotation;
    private float totalYRotation;
    private float totalYRotation2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x1rotation= leftnob.eulerAngles.x;
        x2rotation= rightnob.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        door();
    }

    public void door()
    {
        float currentXRotation = leftnob.eulerAngles.x;
        float currentXRotation2 = rightnob.eulerAngles.x;

        if (Mathf.Abs(currentXRotation - x1rotation) > 10f)
        {
            if (totalYRotation < 100f)
            {
                float rotationAmount = 1f;

                // Prevent over-rotating beyond 100°
                if (totalYRotation + rotationAmount > 100f)
                    rotationAmount = 100f - totalYRotation;

                door1.Rotate(0f, -rotationAmount, 0f);
                totalYRotation += rotationAmount;
            }

            x1rotation = currentXRotation;
        }


        //Door2 




        if (Mathf.Abs(currentXRotation2 - x2rotation) > 10f)
        {
            if (totalYRotation2 < 100f)
            {
                float rotationAmount = -1f;

                // Prevent over-rotating beyond 100°
                if (totalYRotation2 + rotationAmount > 100f)
                    rotationAmount = 100f - totalYRotation2;

                door2.Rotate(0f, -rotationAmount, 0f);
                totalYRotation += rotationAmount;
            }

            x2rotation = currentXRotation2;
        }
        


    }
}
