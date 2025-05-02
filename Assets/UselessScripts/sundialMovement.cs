using UnityEngine;

public class sundialMovement : MonoBehaviour
{
    public GameObject sundial;
    public float speed=0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Right();
         Leftt();
    }



    public void Right(){
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sundial.transform.Rotate(0,speed,0);
        }




    }
     public void Leftt(){
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sundial.transform.Rotate(0,-speed,0);
        }




    }
}
