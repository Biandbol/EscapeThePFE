using UnityEngine;

public class LightManger : MonoBehaviour
{
    public GameObject fire;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {

            fire.SetActive(true);
            
        }
    }
}
