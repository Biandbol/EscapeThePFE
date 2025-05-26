using Unity.VisualScripting;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    
    private bool isInitialized = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
      private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("lights"))
        {
            
            
       
            other.gameObject.SetActive(true); 
        }
    }
}
