using UnityEngine;

public class VRcycle : MonoBehaviour
{
    public CycleLetter letterS;
    public CycleGameObjects syke;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        
            if (Input.GetKeyDown(KeyCode.UpArrow))
        {
             syke.NextObject();
        }
        
    }
    public void next(){
         letterS.NextLetter();
        
    }
    
}
